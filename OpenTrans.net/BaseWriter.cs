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
using System.Xml;

namespace OpenTrans.net
{
    internal class BaseWriter
    {
        internal XmlTextWriter Writer;


        internal void _writeParty(XmlTextWriter writer, Party party)
        {
            Writer.WriteStartElement("PARTY");
            _writeOptionalElementString(Writer, "bmecat:PARTY_ID", party.Id, new Dictionary<string, string>() { { "type", "PredefinedOrCustomType" } });
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
            _writeOptionalElementString(writer, "bmecat:STATE", party.State);
            _writeOptionalElementString(writer, "bmecat:COUNTRY", Countries.GetCountry(party.CountryCode));
            _writeOptionalElementString(writer, "bmecat:COUNTRY_CODED", party.CountryCode.EnumToString());
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


        internal void _writeOrderItem(XmlTextWriter writer, OrderItem item, string startElementName = "ORDER_ITEM")
        {
            Writer.WriteStartElement(startElementName);
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


        internal void _writeProductId(XmlTextWriter writer, ProductId productId)
        {
            Writer.WriteStartElement("PRODUCT_ID");
            _writeOptionalElementString(Writer, "bmecat:SUPPLIER_PID", productId.SupplierPId, new Dictionary<string, string>() { { "type", "" } });
            _writeOptionalElementString(Writer, "bmecat:SUPPLIER_IDREF", productId.SupplierIdRef, new Dictionary<string, string> { { "type", "" } });
            _writeOptionalElementString(Writer, "bmecat:DESCRIPTION_SHORT", productId.DescriptionShort, new Dictionary<string, string> { { "lang", "deu" } });
            _writeOptionalElementString(Writer, "bmecat:DESCRIPTION_LONG", productId.DescriptionLong, new Dictionary<string, string> { { "lang", "deu" } });
            Writer.WriteEndElement(); // !PRODUCT_ID
        } // !_writeProductId()


        internal void _writeDateTime(XmlTextWriter writer, string nodeName, DateTime dt)
        {
            Writer.WriteElementString(nodeName, dt.ToString("yyyy-MM-ddThh:mm:sszzz"));
        } // !_writeDateTime()


        internal void _writeOptionalElementString(XmlTextWriter writer, string tagName, string value, Dictionary<string, string> attributes = null)
        {
            if (!String.IsNullOrEmpty(value))
            {
                writer.WriteStartElement(tagName);

                if (attributes != null)
                {
                    foreach (KeyValuePair<string, string> kv in attributes)
                    {
                        writer.WriteAttributeString(kv.Key, kv.Value);
                    }
                }

                Writer.WriteValue(value);
                Writer.WriteEndElement();
            }
        } // !_writeOptionalElementString()


        internal void _writeAmount(XmlTextWriter writer, string tagName, int value)
        {
            writer.WriteStartElement(tagName);
            writer.WriteValue(value);
            writer.WriteEndElement(); // !tagName
        } // !_writeOptionalAmount()


        internal void _writeAmount(XmlTextWriter writer, string tagName, decimal value, int numDecimals = 2)
        {
            writer.WriteStartElement(tagName);
            writer.WriteValue(_formatDecimal(value, numDecimals));
            writer.WriteEndElement(); // !tagName
        } // !_writeOptionalAmount()


        internal string _formatDecimal(decimal value, int numDecimals = 2)
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