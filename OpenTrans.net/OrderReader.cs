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

                string partialShipmentAllowed = XmlUtils.NodeAsString(orderInfoNode, "./*[local-name()='PARTIAL_SHIPMENT_ALLOWED']", nsmgr);
                if (!string.IsNullOrWhiteSpace(partialShipmentAllowed))
                {
                    partialShipmentAllowed = partialShipmentAllowed.Trim().ToLowerInvariant();
                    order.PartialShipmentAllowed = partialShipmentAllowed == "true" || partialShipmentAllowed == "1";
                }

                XmlNode customerOrderReferenceNode = orderInfoNode?.SelectSingleNode("./*[local-name()='CUSTOMER_ORDER_REFERENCE']", nsmgr);
                if (customerOrderReferenceNode != null)
                {
                    order.CustomerOrderReference = new CustomerOrderReference
                    {
                        OrderId = XmlUtils.NodeAsString(customerOrderReferenceNode, "./*[local-name()='ORDER_ID']", nsmgr)
                    };
                } // !customerOrderReferenceNode

                order.DeliveryDate = _readDeliveryDate(orderInfoNode?.SelectSingleNode("./*[local-name()='DELIVERY_DATE']", nsmgr), nsmgr);

                XmlNodeList partyNodes = orderHeaderNode.SelectNodes(".//*[local-name()='PARTIES']/*[local-name()='PARTY']", nsmgr);
                if (partyNodes != null) {
                    foreach (XmlNode partyNode in partyNodes)
                    {
                        Party party = _readParty(partyNode, nsmgr);
                        order.Parties.Add(party);
                    }
                } // !partyNodes
                
                order.OrderPartiesReference = _readOrderPartiesReference(orderInfoNode?.SelectSingleNode("./*[local-name()='ORDER_PARTIES_REFERENCE']", nsmgr), nsmgr);
                
                order.Remarks.AddRange(_readRemarks(orderInfoNode, nsmgr));
            } // !orderHeaderNode

            XmlNodeList itemNodes = doc.SelectNodes("//*[local-name()='ORDER_ITEM_LIST']/*[local-name()='ORDER_ITEM']", nsmgr);
            if (itemNodes != null)
            {
                foreach (XmlNode itemNode in itemNodes)
                {
                    order.OrderItems.Add(_readItem(itemNode, nsmgr));
                }
            } // !itemNodes

            // ORDER_SUMMARY is always written (TOTAL_ITEM_NUM is mandatory), so only TOTAL_AMOUNT indicates a summary
            decimal? totalAmount = XmlUtils.NodeAsDecimal(doc, "//*[local-name()='ORDER_SUMMARY']/*[local-name()='TOTAL_AMOUNT']", nsmgr);
            if (totalAmount.HasValue)
            {
                order.OrderSummary = new OrderSummary
                {
                    TotalAmount = totalAmount
                };
            } // !totalAmount

            return order;
        } // !Load()
    }
}
