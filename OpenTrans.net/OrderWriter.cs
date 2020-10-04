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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace OpenTrans.net
{
    internal class OrderWriter : BaseWriter
    {
        internal XmlTextWriter Writer;


        public void Save(Order order, string filename, string generatorInfo = null)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            Save(order, fs, generatorInfo);
            fs.Flush();
            fs.Close();
        } // !Save()


        public void Save(Order order, Stream stream, string generatorInfo = null)
        {
            if (!stream.CanWrite || !stream.CanSeek)
            {
                throw new IllegalStreamException("Cannot write to stream");
            }

            long streamPosition = stream.Position;

            this.Writer = new XmlTextWriter(stream, Encoding.UTF8);
            Writer.Formatting = Formatting.Indented;
            Writer.WriteStartDocument();
            Writer.WriteStartElement("ORDER");
            Writer.WriteAttributeString("type", "standard");
            Writer.WriteAttributeString("version", "2.1");
            Writer.WriteAttributeString("xmlns", "http://www.opentrans.org/XMLSchema/2.1");
            Writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            Writer.WriteAttributeString("xsi:schemaLocation", "http://www.opentrans.org/XMLSchema/2.1 opentrans_2_1.xsd");
            Writer.WriteAttributeString("xmlns:bmecat", "http://www.bmecat.org/bmecat/2005");
            Writer.WriteAttributeString("xmlns:xmime", "http://www.w3.org/2005/05/xmlmime");
            Writer.WriteAttributeString("xmlns:xsig", "http://www.w3.org/2000/09/xmldsig#");

            Writer.WriteStartElement("ORDER_HEADER");
            Writer.WriteStartElement("CONTROL_INFO");
            _writeDateTime(Writer, "GENERATION_DATE", DateTime.Now);
            _writeOptionalElementString(Writer, "GENERATOR_INFO", generatorInfo);
            Writer.WriteEndElement(); // !CONTROL_INFO
            Writer.WriteStartElement("SOURCING_INFO");
            Writer.WriteEndElement(); // !SOURCING_INFO
            Writer.WriteStartElement("ORDER_INFO");
            Writer.WriteElementString("ORDER_ID", order.Id);

            if (order.OrderDate.HasValue)
            {
                _writeDateTime(Writer, "ORDER_DATE", order.OrderDate.Value);
            }
            Writer.WriteStartElement("DELIVERY_DATE");
            _writeDateTime(Writer, "DELIVERY_START_DATE", order.DesiredDeliveryDateStart);
            _writeDateTime(Writer, "DELIVERY_END_DATE", order.DesiredDeliveryDateEnd);
            Writer.WriteEndElement(); // !DELIVERY_DATE

            Writer.WriteStartElement("PARTIES");
            foreach (Party party in order.Parties)
            {
                _writeParty(Writer, party);
            }
            Writer.WriteEndElement(); // !PARTIES
            _writeCustomerOrderReference(Writer, order.CustomerOrderReference);
            _writeOrderPartiesReference(Writer, order.OrderPartiesReference);
            _writeOptionalElementString(Writer, "bmecat:CURRENCY", order.Currency);
            _writeOptionalElementString(Writer, "PARTIAL_SHIPMENT_ALLOWED", order.PartialShipmentAllowed? "TRUE": "FALSE");
            Writer.WriteEndElement(); // !ORDER_INFO
            Writer.WriteEndElement(); // !ORDER_HEADER

            Writer.WriteStartElement("ORDER_ITEM_LIST");
            foreach (OrderItem _item in order.OrderItems)
            {
                _writeOrderItem(Writer, _item);
            }
            Writer.WriteEndElement(); // !ORDER_ITEM_LIST

            Writer.WriteStartElement("ORDER_SUMMARY");
            _writeAmount(Writer, "TOTAL_ITEM_NUM", order.OrderItems.Count);
            _writeOptionalAmount(Writer, "TOTAL_AMOUNT ", order.OrderSummary.TotalAmount);
            Writer.WriteEndElement(); // !ORDER_SUMMARY
            
            Writer.WriteEndElement(); // !ORDER
            Writer.WriteEndDocument();
            Writer.Flush();

            stream.Seek(streamPosition, SeekOrigin.Begin);
        } // !Save()
    }
}