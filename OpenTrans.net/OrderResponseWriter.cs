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
using System.Text;
using System.Xml;

namespace OpenTrans.net
{
    internal class OrderResponseWriter : BaseWriter
    {
        internal XmlTextWriter Writer;


        public OrderResponseWriter()
        {
        }

        public void Save(OrderResponse orderResponse, string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            Save(orderResponse, fs);
            fs.Flush();
            fs.Close();
        } //!Save()


        public void Save(OrderResponse orderResponse, Stream stream)
        {
            if (!stream.CanWrite || !stream.CanSeek)
            {
                throw new IllegalStreamException("Cannot write to stream");
            }

            long streamPosition = stream.Position;
            this.Writer = new XmlTextWriter(stream, Encoding.UTF8);
            Writer.Formatting = Formatting.Indented;
            Writer.WriteStartDocument();
            Writer.WriteStartElement("ORDERRESPONSE");
            Writer.WriteAttributeString("type", "standard");
            Writer.WriteAttributeString("version", "2.1");
            Writer.WriteAttributeString("xmlns", "http://www.opentrans.org/XMLSchema/2.1");
            Writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            Writer.WriteAttributeString("xsi:schemaLocation", "http://www.opentrans.org/XMLSchema/2.1 opentrans_2_1.xsd");
            Writer.WriteAttributeString("xmlns:bmecat", "http://www.bmecat.org/bmecat/2005");
            Writer.WriteAttributeString("xmlns:xmime", "http://www.w3.org/2005/05/xmlmime");
            Writer.WriteAttributeString("xmlns:xsig", "http://www.w3.org/2000/09/xmldsig#");

            Writer.WriteStartElement("ORDERRESPONSE_HEADER");
            Writer.WriteStartElement("CONTROL_INFO");
            _writeDateTime(Writer, "GENERATION_DATE", DateTime.Now);
            Writer.WriteEndElement(); // !CONTROL_INFO

            Writer.WriteStartElement("ORDERRESPONSE_INFO");
            if (!String.IsNullOrEmpty(orderResponse.OrderId))
            {
                Writer.WriteElementString("ORDER_ID", orderResponse.OrderId);
            }

            if (!String.IsNullOrEmpty(orderResponse.SupplierOrderId))
            {
                Writer.WriteElementString("SUPPLIER_ORDER_ID", orderResponse.OrderId);
            }
            
            _writeDateTime(Writer, "ORDERRESPONSE_DATE", DateTime.Now);
            if (orderResponse.OrderDate.HasValue)
            {
                _writeDateTime(Writer, "ORDER_DATE", orderResponse.OrderDate.Value);
            }
            _writeAmount(Writer, "ORDERCHANGE_SEQUENCE_ID", orderResponse.OrderChangeSequenceId);
            Writer.WriteStartElement("PARTIES");
            foreach(Party party in orderResponse.Parties)
            {
                _writeParty(Writer, party);
            }
            Writer.WriteEndElement(); // !PARTIES
            Writer.WriteEndElement(); // !ORDERRESPONSE_INFO

            Writer.WriteEndElement(); // !ORDERRESPONSE_HEADER

            Writer.WriteStartElement("ORDERRESPONSE_ITEM_LIST");
            foreach(OrderItem item in orderResponse.OrderItems)
            {
                _writeOrderItem(Writer, item, "ORDERRESPONSE_ITEM");
            }
            Writer.WriteEndElement(); // !ORDERRESPONSE_ITEM_LIST

            Writer.WriteStartElement("ORDERRESPONSE_SUMMARY");
            _writeAmount(Writer, "TOTAL_ITEM_NUM", orderResponse.OrderItems.Count);
            Writer.WriteEndElement(); // !ORDERRESPONSE_SUMMARY

            Writer.WriteEndElement(); // !ORDERRESPONSE
            Writer.WriteEndDocument();

            Writer.Flush();

            stream.Seek(streamPosition, SeekOrigin.Begin);
        } //!Save()
    }
}