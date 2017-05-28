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
    internal class OrderWriter
    {
        private XmlTextWriter Writer;
        private Order Order;


        public void Save(Order order, string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            Save(order, fs);
            fs.Flush();
            fs.Close();
        } // !Save()


        public void Save(Order order, Stream stream)
        {
            if (!stream.CanWrite || !stream.CanSeek)
            {
                throw new IllegalStreamException("Cannot write to stream");
            }

            long streamPosition = stream.Position;

            this.Order = order;
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
            Writer.WriteEndElement(); // !CONTROL_INFO
            Writer.WriteStartElement("SOURCING_INFO");
            Writer.WriteEndElement(); // !SOURCING_INFO
            Writer.WriteStartElement("ORDER_INFO");
            Writer.WriteEndElement(); // !ORDER_INFO
            Writer.WriteElementString("ORDER_ID", order.Id);
            _writeDateTime(Writer, "ORDER_DATE", order.OrderDate);
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

            Writer.WriteEndElement(); // !ORDER_INFO
            Writer.WriteEndElement(); // !ORDER_HEADER

            Writer.WriteStartElement("ORDER_ITEM_LIST");
            foreach (OrderItem _item in order.OrderItems)
            {
                _writeOrderItem(Writer, _item);
            }
            Writer.WriteEndElement(); // !ORDER_ITEM_LIST


            Writer.WriteEndElement(); // !ORDER
            Writer.WriteEndDocument();
            Writer.Flush();

            stream.Seek(streamPosition, SeekOrigin.Begin);
        } // !Save()


        private void _writeOrderItem(XmlTextWriter writer, OrderItem item)
        {
            Writer.WriteStartElement("ORDER_ITEM");
            _writeOptionalElementString(Writer, "LINE_ITEM_ID", item.LineItemId);
            if (item.ProductId != null)
            {
                _writeProductId(Writer, item.ProductId);
            }

            if (item.Quantity.HasValue)
            {
                _writeAmount(Writer, "QUANTITY", item.Quantity.Value);
            }
            _writeOptionalElementString(Writer, "bmecat:ORDER_UNIT", item.OrderUnit.EnumToString());
            if (item.LineAmount.HasValue)
            {
                _writeAmount(Writer, "PRICE_LINE_AMOUNT", item.LineAmount.Value);
            }

            foreach (string remark in item.Remarks)
            {
                Writer.WriteStartElement("REMARKS");
                writer.WriteAttributeString("lang", "deu");
                Writer.WriteValue(remark);
                writer.WriteEndElement();
            }

            Writer.WriteEndElement();
        } // !_writeOrderItem()


        private void _writeProductId(XmlTextWriter writer, ProductId productId)
        {
            Writer.WriteStartElement("PRODUCT_ID");
            _writeOptionalElementString(Writer, "bmecat:SUPPLIER_PID", productId.SupplierPId, new Dictionary<string, string>() { { "type", ""} });
            _writeOptionalElementString(Writer, "bmecat:SUPPLIER_IDREF", productId.SupplierIdRef, new Dictionary<string, string> { { "type", "" } });
            _writeOptionalElementString(Writer, "bmecat:DESCRIPTION_SHORT", productId.DescriptionShort, new Dictionary<string, string> { { "lang", "deu" } });
            _writeOptionalElementString(Writer, "bmecat:DESCRIPTION_LONG", productId.DescriptionLong, new Dictionary<string, string> { { "lang", "deu" } });
            Writer.WriteEndElement(); // !PRODUCT_ID
        } // !_writeProductId()


        private void _writeParty(XmlTextWriter writer, Party party)
        {
            Writer.WriteStartElement("PARTY");
            _writeOptionalElementString(Writer, "bmecat:PARTY_ID", party.Id, new Dictionary<string,string>() { { "type", "PredefinedOrCustomType" } });
            foreach (string _role in party.Roles)
            {
                Writer.WriteElementString("PARTY_ROLE", _role);
            }

            writer.WriteStartElement("ADDRESS");
            _writeOptionalElementString(writer, "bmecat:NAME", party.Name);
            _writeOptionalElementString(writer, "bmecat:NAME2", party.Name2);
            _writeOptionalElementString(writer, "bmecat:NAME3", party.Name3);
            _writeOptionalElementString(writer, "bmecat:DEPARTMENT", party.Department);
            _writeOptionalElementString(writer, "bmecat:STREET", party.Street);
            _writeOptionalElementString(writer, "bmecat:ZIP", party.Zip);
            _writeOptionalElementString(writer, "bmecat:BOXNO", party.BoxNo);
            _writeOptionalElementString(writer, "bmecat:ZIPBOX", party.ZipBox);
            _writeOptionalElementString(writer, "bmecat:CITY", party.City);
            _writeOptionalElementString(writer, "bmecat:STATE", party. State);
            _writeOptionalElementString(writer, "bmecat:COUNTRY", _translateCountry(party.CountryCode));
            _writeOptionalElementString(writer, "bmecat:COUNTRY_CODE", party.CountryCode.EnumToString());
            _writeOptionalElementString(writer, "bmecat:VAT_ID", party.VATId);
            _writeOptionalElementString(writer, "bmecat:TAX_NUMBER", party.TaxNumber);

            if (party.ContactDetails != null)
            {
                writer.WriteStartElement("CONTACT_DETAILS");
                _writeOptionalElementString(writer, "CONTACT_ID", party.ContactDetails.Id);
                _writeOptionalElementString(writer, "CONTACT_NAME", party.ContactDetails.Name);
                _writeOptionalElementString(writer, "FIRST_NAME", party.ContactDetails.FirstName);
                _writeOptionalElementString(writer, "TITLE", party.ContactDetails.Title);
                _writeOptionalElementString(writer, "ACADEMIC_TITLE", party.ContactDetails.AcademicTitle);
                _writeOptionalElementString(writer, "CONTACT_DESCR", party.ContactDetails.Description);
                _writeOptionalElementString(writer, "URL", party.ContactDetails.Url);
                _writeOptionalElementString(writer, "AUTHENTIFICATION", party.ContactDetails.Authentification);

                /**
                 * @todo write elements phone, fax, roles, emailAddresses
                 */

                writer.WriteEndElement(); // !CONTACT_DETAILS
            }

            Writer.WriteEndElement(); // !ADDRESS

            Writer.WriteEndElement(); // !PARTY
        } // !_writeParty()


        private string _translateCountry(CountryCodes countryCode)
        {
            switch (countryCode)
            {
                case CountryCodes.DE:
                    return "Deutschland";
                default:
                    return "";
            }
        } // !_translateCountry()


        private void _writeDateTime(XmlTextWriter writer, string nodeName, DateTime dt)
        {
            Writer.WriteElementString(nodeName, dt.ToString("yyyy-MM-ddThh:mm:sszzz"));
        } // !_writeDateTime()


        private void _writeOptionalElementString(XmlTextWriter writer, string tagName, string value, Dictionary<string,string> attributes = null)
        {
            if (!String.IsNullOrEmpty(value))
            {
                writer.WriteStartElement(tagName);

                if (attributes != null)
                {
                    foreach(KeyValuePair<string,string> kv in attributes)
                    {
                        writer.WriteAttributeString(kv.Key, kv.Value);
                    }
                }

                Writer.WriteValue(value);
                Writer.WriteEndElement();
            }
        } // !_writeOptionalElementString()


        private void _writeAmount(XmlTextWriter writer, string tagName, decimal value, int numDecimals = 2)
        {
            writer.WriteStartElement(tagName);
            writer.WriteValue(_formatDecimal(value, numDecimals));
            writer.WriteEndElement(); // !tagName
        } // !_writeOptionalAmount()


        private string _formatDecimal(decimal value, int numDecimals = 2)
        {
            string formatString = "0.";
            for (int i = 0; i < numDecimals; i++)
            {
                formatString += "0";
            }

            return value.ToString(formatString).Replace(",", ".");
        } // !_formatDecimal()
    }
}