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
    internal class OrderResponseReader : BaseReader
    {
        public OrderResponseReader()
        {
        }


        internal OrderResponse Load(string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                throw new FileNotFoundException();
            }

            return Load(new FileStream(filename, FileMode.Open, FileAccess.Read));
        } // !Load()


        internal OrderResponse Load(Stream stream)
        {
            if (!stream.CanRead)
            {
                throw new IllegalStreamException("Cannot read from stream");
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.DocumentElement.OwnerDocument.NameTable);
            nsmgr.AddNamespace("openTrans", "http://www.opentrans.org/XMLSchema/2.1");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgr.AddNamespace("bmecat", "http://www.bmecat.org/bmecat/2005");
            nsmgr.AddNamespace("xmime", "http://www.w3.org/2005/05/xmlmime");
            nsmgr.AddNamespace("xsig", "http://www.w3.org/2000/09/xmldsig#");

            OrderResponse retval = new OrderResponse();

            XmlNode headerNode = doc.SelectSingleNode("//*[local-name()='ORDERRESPONSE_HEADER']", nsmgr);
            if (headerNode != null)
            {
                DateTime? generationDate = _nodeAsDateTime(headerNode, "./*[local-name()='CONTROL_INFO']/*[local-name()='GENERATION_DATE']", nsmgr);
                retval.OrderId = XmlUtils.NodeAsString(headerNode, "./*[local-name()='ORDERRESPONSE_INFO']/*[local-name()='ORDER_ID']", nsmgr);
                retval.SupplierOrderId = XmlUtils.NodeAsString(headerNode, "./*[local-name()='ORDERRESPONSE_INFO']/*[local-name()='SUPPLIER_ORDER_ID']", nsmgr);
                retval.OrderDate = _nodeAsDateTime(headerNode, "./*[local-name()='ORDERRESPONSE_INFO']/*[local-name()='ORDER_DATE']", nsmgr);
                retval.OrderChangeSequenceId = XmlUtils.NodeAsInt(headerNode, "./*[local-name()='ORDERRESPONSE_INFO']/*[local-name()='ORDERCHANGE_SEQUENCE_ID']", nsmgr);

                XmlNodeList partyNodes = headerNode.SelectNodes(".//*[local-name()='PARTIES']/*[local-name()='PARTY']", nsmgr);
                foreach (XmlNode partyNode in partyNodes)
                {
                    Party p = _readParty(partyNode, nsmgr);
                    retval.Parties.Add(p);
                }
            }

            XmlNodeList itemNodes = doc.SelectNodes("//*[local-name()='ORDERRESPONSE_ITEM_LIST']/*[local-name()='ORDERRESPONSE_ITEM']", nsmgr);
            foreach (XmlNode itemNode in itemNodes)
            {
                retval.OrderItems.Add(_readItem(itemNode, nsmgr));
            }


            return retval;
        } // !Load()        
    }
}