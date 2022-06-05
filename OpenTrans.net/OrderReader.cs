/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
using System;
using System.IO;
using System.Xml;

namespace OpenTrans.net
{
    internal class OrderReader : BaseReader
    {
        public Order Load(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            
            Order order;
            
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                order = Load(stream);
            }

            return order;
        } // !Load()       
        
        public Order Load(Stream stream)
        {
            if (!stream.CanRead)
            {
                throw new IllegalStreamException("Cannot read from stream.");
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(stream);

            if (doc.DocumentElement?.OwnerDocument == null)
            {
                throw new Exception("Cannot create XML document.");
            }
            
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.DocumentElement.OwnerDocument.NameTable);
            nsmgr.AddNamespace("openTrans", "http://www.opentrans.org/XMLSchema/2.1");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgr.AddNamespace("bmecat", "http://www.bmecat.org/bmecat/2005");
            nsmgr.AddNamespace("xmime", "http://www.w3.org/2005/05/xmlmime");
            nsmgr.AddNamespace("xsig", "http://www.w3.org/2000/09/xmldsig#");

            Order order = new Order();
            XmlNode orderHeaderNode = doc.SelectSingleNode("//*[local-name()='ORDER_HEADER']", nsmgr);
            if (orderHeaderNode != null)
            {
                XmlNode controlInfoNode = orderHeaderNode.SelectSingleNode("//*[local-name()='CONTROL_INFO']", nsmgr);
                order.GenerationDate = _nodeAsDateTime(controlInfoNode, "./*[local-name()='GENERATION_DATE']", nsmgr);

                XmlNode orderInfoNode = orderHeaderNode.SelectSingleNode("//*[local-name()='ORDER_INFO']", nsmgr);
                order.Id = XmlUtils.NodeAsString(orderInfoNode, "./*[local-name()='ORDER_ID']", nsmgr);
                order.OrderDate = _nodeAsDateTime(orderInfoNode, "./*[local-name()='ORDER_DATE']", nsmgr);
                order.Currency = XmlUtils.NodeAsString(orderInfoNode, "./*[local-name()='CURRENCY']", nsmgr);

                XmlNode deliveryDateRefNode = orderInfoNode?.SelectSingleNode("./*[local-name()='DELIVERY_DATE']", nsmgr);
                if (deliveryDateRefNode != null)
                {
                    DeliveryDate deliveryDate = new DeliveryDate
                    {
                        StartDate = _nodeAsDateTime(deliveryDateRefNode, "./*[local-name()='DELIVERY_START_DATE']", nsmgr),
                        EndDate = _nodeAsDateTime(deliveryDateRefNode, "./*[local-name()='DELIVERY_END_DATE']", nsmgr),
                        Type = default(DeliveryDateTypes).FromString(XmlUtils.AttributeText(deliveryDateRefNode, "type"))
                    };
                    order.DeliveryDate = deliveryDate;
                } // !deliveryDateRefNode

                XmlNodeList partyNodes = orderHeaderNode.SelectNodes(".//*[local-name()='PARTIES']/*[local-name()='PARTY']", nsmgr);
                if (partyNodes != null) {
                    foreach (XmlNode partyNode in partyNodes)
                    {
                        Party party = _readParty(partyNode, nsmgr);
                        order.Parties.Add(party);
                    }
                } // !partyNodes
                
                XmlNode partiesReferenceNode = orderInfoNode?.SelectSingleNode("./*[local-name()='ORDER_PARTIES_REFERENCE']", nsmgr);
                if (partiesReferenceNode != null)
                {
                    order.OrderPartiesReference = new OrderPartiesReference();
                    XmlNode buyerIdRefNode = partiesReferenceNode.SelectSingleNode("./*[local-name()='BUYER_IDREF']", nsmgr);
                    if (buyerIdRefNode != null)
                    {
                        order.OrderPartiesReference.BuyerIdRef = new PartyId
                        {
                            Id = buyerIdRefNode.InnerText,
                            Type = default(PartyIdTypes).FromString(XmlUtils.AttributeText(buyerIdRefNode, "type"))
                        };
                    } // !buyerIdRefNode
                    
                    XmlNode supplierIdRefNode = partiesReferenceNode.SelectSingleNode("./*[local-name()='SUPPLIER_IDREF']", nsmgr);
                    if (supplierIdRefNode != null)
                    {
                        order.OrderPartiesReference.SupplierIdRef = new PartyId
                        {
                            Id = supplierIdRefNode.InnerText,
                            Type = default(PartyIdTypes).FromString(XmlUtils.AttributeText(supplierIdRefNode, "type"))
                        };
                    } // !supplierIdRefNode
                    
                    XmlNode shipmentRefNode = partiesReferenceNode.SelectSingleNode("./*[local-name()='SHIPMENT_PARTIES_REFERENCE']", nsmgr);
                    if (shipmentRefNode != null)
                    {
                        XmlNode deliveryIdRefNode = shipmentRefNode.SelectSingleNode("./*[local-name()='DELIVERY_IDREF']");
                        order.OrderPartiesReference.ShipmentPartiesReference = new ShipmentPartiesReference
                        {
                            DeliveryIdRef = deliveryIdRefNode?.InnerText
                        };
                    } // !shipmentRefNode 
                } // !partiesReferenceNode
                
                XmlNodeList remarkNodes = orderInfoNode?.SelectNodes("./*[local-name()='REMARKS']", nsmgr);
                if (remarkNodes != null)
                {
                    foreach (XmlNode remarkNode in remarkNodes)
                    {
                        Remark remark = new Remark
                        {
                            Value = XmlUtils.NodeAsString(remarkNode, ".", nsmgr),
                            Type = XmlUtils.AttributeText(remarkNode, "type")
                        };
                        order.Remarks.Add(remark);
                    }
                } // !remarkNodes
            } // !orderHeaderNode

            XmlNodeList itemNodes = doc.SelectNodes("//*[local-name()='ORDER_ITEM_LIST']/*[local-name()='ORDER_ITEM']", nsmgr);
            if (itemNodes != null)
            {
                foreach (XmlNode itemNode in itemNodes)
                {
                    order.OrderItems.Add(_readItem(itemNode, nsmgr));
                }
            } // !itemNodes

            return order;
        } // !Load()
    }
}
