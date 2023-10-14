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
using System.Linq;
using System.Xml;

namespace OpenTrans.net
{
    /// <summary>
    /// This class contains base functionality that is useable by writers for all OpenTrans message types
    /// </summary>
    internal class BaseWriter
    {      
        internal void _writeParty(XmlTextWriter writer, Party party)
        {
            writer.WriteStartElement("PARTY");

            foreach(PartyId id in party.Ids)
            {
                _writeOptionalElementString(writer, "bmecat:PARTY_ID", id.Id, new Dictionary<string, string>() { { "type", id.Type.EnumToString() } });
            }

            foreach (PartyRoles _role in party.Roles)
            {
                writer.WriteElementString("PARTY_ROLE", _role.EnumToString());
            }
            
            foreach (string _role in party.RolesCustom) 
            {
                writer.WriteElementString("PARTY_ROLE", _role);
            }

            writer.WriteStartElement("ADDRESS");
            _writeOptionalElementString(writer, "bmecat:NAME", party.Name);
            _writeOptionalElementString(writer, "bmecat:NAME2", party.Name2);
            _writeOptionalElementString(writer, "bmecat:NAME3", party.Name3);
            _writeOptionalElementString(writer, "bmecat:DEPARTMENT", party.Department);

            if (party.ContactDetails != null)
            {
                writer.WriteStartElement("CONTACT_DETAILS");
                _writeOptionalElementString(writer, "bmecat:CONTACT_ID", party.ContactDetails.Id);
                _writeOptionalElementString(writer, "bmecat:CONTACT_NAME", party.ContactDetails.Name);
                _writeOptionalElementString(writer, "bmecat:FIRST_NAME", party.ContactDetails.FirstName);
                _writeOptionalElementString(writer, "bmecat:TITLE", party.ContactDetails.Title);
                _writeOptionalElementString(writer, "bmecat:ACADEMIC_TITLE", party.ContactDetails.AcademicTitle);
                _writeOptionalElementString(writer, "bmecat:CONTACT_DESCR", party.ContactDetails.Description);
                _writeOptionalElementString(writer, "bmecat:PHONE", party.ContactDetails.PhoneNo);                
                _writeOptionalElementString(writer, "bmecat:FAX", party.ContactDetails.FaxNo);
                _writeOptionalElementString(writer, "bmecat:URL", party.ContactDetails.Url);
                if (party.ContactDetails.EmailAddresses.Any())
                {
                    writer.WriteStartElement("bmecat:EMAILS");
                    foreach (string emailAddress in party.ContactDetails.EmailAddresses)
                    {
                        _writeOptionalElementString(writer, "bmecat:EMAIL", emailAddress);
                    }
                    writer.WriteEndElement(); // !bmecat:EMAILS
                }

                _writeOptionalElementString(writer, "bmecat:AUTHENTIFICATION", party.ContactDetails.Authentification);

                writer.WriteEndElement(); // !CONTACT_DETAILS
            }

            _writeOptionalElementString(writer, "bmecat:STREET", party.Street);
            _writeOptionalElementString(writer, "bmecat:ZIP", party.Zip);
            _writeOptionalElementString(writer, "bmecat:BOXNO", party.BoxNo);
            _writeOptionalElementString(writer, "bmecat:ZIPBOX", party.ZipBox);
            _writeOptionalElementString(writer, "bmecat:CITY", party.City);
            _writeOptionalElementString(writer, "bmecat:STATE", party.State);
            if (party.CountryCode != CountryCodes.Unknown)
            {
                _writeOptionalElementString(writer, "bmecat:COUNTRY", Countries.GetCountry(party.CountryCode));
                _writeOptionalElementString(writer, "bmecat:COUNTRY_CODED", party.CountryCode.EnumToString());
            }
            _writeOptionalElementString(writer, "bmecat:VAT_ID", party.VATId);
            _writeOptionalElementString(writer, "bmecat:TAX_NUMBER", party.TaxNumber);
            _writeOptionalElementString(writer, "bmecat:PHONE", party.PhoneNo);
            _writeOptionalElementString(writer, "bmecat:FAX", party.FaxNo);
            _writeOptionalElementString(writer, "bmecat:EMAIL", party.EmailAddress);
            _writeOptionalElementString(writer, "bmecat:URL", party.Url);
            writer.WriteEndElement(); // !ADDRESS

            writer.WriteEndElement(); // !PARTY
        } // !_writeParty()


        internal void _writeCustomerOrderReference(XmlTextWriter writer, CustomerOrderReference customerOrderReference)
        {
            if (customerOrderReference != null)
            {
                writer.WriteStartElement("CUSTOMER_ORDER_REFERENCE");
                _writeOptionalElementString(writer, "ORDER_ID", customerOrderReference.OrderId);
                writer.WriteEndElement(); // !CUSTOMER_ORDER_REFERENCE
            }
        }  // !_writeCustomerOrderReference()


        internal void _writeOrderPartiesReference(XmlTextWriter writer, OrderPartiesReference orderPartiesReference)
        {
            if (orderPartiesReference != null)
            {
                writer.WriteStartElement("ORDER_PARTIES_REFERENCE");
                _writeOptionalElementString(writer, "bmecat:BUYER_IDREF", orderPartiesReference.BuyerIdRef.Id, new Dictionary<string, string>() { { "type", orderPartiesReference.BuyerIdRef.Type.EnumToString() } });
                _writeOptionalElementString(writer, "bmecat:SUPPLIER_IDREF", orderPartiesReference.SupplierIdRef.Id, new Dictionary<string, string>() { { "type", orderPartiesReference.SupplierIdRef.Type.EnumToString() } });
                if (orderPartiesReference.ShipmentPartiesReference != null)
                {
                    writer.WriteStartElement("SHIPMENT_PARTIES_REFERENCE");
                    _writeOptionalElementString(writer, "DELIVERY_IDREF", orderPartiesReference.ShipmentPartiesReference.DeliveryIdRef);
                    writer.WriteEndElement(); // !SHIPMENT_PARTIES_REFERENCE
                }
                writer.WriteEndElement(); // !ORDER_PARTIES_REFERENCE
            }
        } // !_writeOrderPartiesReference()


        internal void _writeOrderItem(XmlTextWriter writer, OrderItem item, string startElementName = "ORDER_ITEM")
        {
            writer.WriteStartElement(startElementName);
            _writeOptionalElementString(writer, "LINE_ITEM_ID", item.LineItemId);
            if (item.ProductId != null)
            {
                _writeProductId(writer, item.ProductId);
            }
            if (item.ProductFeatures.Any())
            {
                writer.WriteStartElement("PRODUCT_FEATURES");
                foreach (var feature in item.ProductFeatures)
                {
                    writer.WriteStartElement("FEATURE ");
                    _writeOptionalElementString(writer, "bmecat:FNAME", feature.Name);
                    _writeOptionalElementString(writer, "bmecat:FVALUE", feature.Value);
                    _writeOptionalElementString(writer, "bmecat:FVALUE_DETAILS", feature.ValueDetails);
                    _writeOptionalElementString(writer, "bmecat:FDESCR", feature.Description, new Dictionary<string, string> { { "lang", "deu" } });
                    _writeOptionalElementString(writer, "bmecat:FUNIT", feature.Unit.EnumToString());
                    _writeOptionalElementString(writer, "bmecat:FVALUE_TYPE", feature.ValueType?.ToString());
                    writer.WriteEndElement(); // !FEATURE 
                }
                writer.WriteEndElement(); // !PRODUCT_FEATURES
            }

            if (item.Quantity.HasValue)
            {
                _writeOptionalAmount(writer, "QUANTITY", item.Quantity.Value);
            }
            _writeOptionalElementString(writer, "bmecat:ORDER_UNIT", item.OrderUnit.EnumToString());
            if (item.ProductPriceFix != null)
            {
                writer.WriteStartElement("PRODUCT_PRICE_FIX");                
                _writeOptionalAmount(writer, "bmecat:PRICE_AMOUNT", item.ProductPriceFix.PriceAmount);
                _writeOptionalAmount(writer, "bmecat:PRICE_QUANTITY", item.ProductPriceFix.PriceQuantity);

                if (item.ProductPriceFix.PriceBaseFix != null)
                {
                    writer.WriteStartElement("PRICE_BASE_FIX");
                    _writeOptionalAmount(writer, "PRICE_UNIT_VALUE", item.ProductPriceFix.PriceBaseFix.PriceUnitValue);
                    _writeOptionalElementString(writer, "PRICE_UNIT", item.ProductPriceFix.PriceBaseFix.PriceUnit.EnumToString());
                    _writeOptionalAmount(writer, "PRICE_UNIT_FACTOR", item.ProductPriceFix.PriceBaseFix.PriceUnitFactor);
                    writer.WriteEndElement(); // !PRICE_BASE_FIX
                }

                writer.WriteEndElement(); // !PRODUCT_PRICE_FIX
            }
            if (item.LineAmount.HasValue)
            {
                _writeOptionalAmount(writer, "PRICE_LINE_AMOUNT", item.LineAmount.Value);
            }
            
            _writeDeliveryDate(writer, item.DeliveryDate);
            _writeRemarks(writer, item.Remarks);
            writer.WriteEndElement();
        } // !_writeOrderItem()


        internal void _writeProductId(XmlTextWriter writer, ProductId productId)
        {
            writer.WriteStartElement("PRODUCT_ID");
            if (productId != null)
            {
                _writeOptionalElementString(writer, "bmecat:SUPPLIER_PID", productId.SupplierPId?.Id, new Dictionary<string, string>() { { "type", productId.SupplierPId?.Type.EnumToString() } });
                _writeOptionalElementString(writer, "bmecat:SUPPLIER_IDREF", productId.SupplierIdRef?.Id, new Dictionary<string, string> { { "type", productId.SupplierIdRef?.Type.EnumToString() } });
                _writeOptionalElementString(writer, "bmecat:BUYER_PID", productId.BuyerPId?.Id, new Dictionary<string, string> { { "type", productId.BuyerPId?.Type.EnumToString() } });
                _writeOptionalElementString(writer, "bmecat:DESCRIPTION_SHORT", productId.DescriptionShort, new Dictionary<string, string> { { "lang", "deu" } });
                _writeOptionalElementString(writer, "bmecat:DESCRIPTION_LONG", productId.DescriptionLong, new Dictionary<string, string> { { "lang", "deu" } });
            }
            writer.WriteEndElement(); // !PRODUCT_ID
        } // !_writeProductId()
        
        internal void _writeRemarks(XmlTextWriter writer, List<Remark> remarks)
        {
            foreach (Remark remark in remarks)
            {
                if (string.IsNullOrWhiteSpace(remark.Value))
                {
                    continue;
                }
                writer.WriteStartElement("REMARKS");
                if (!string.IsNullOrWhiteSpace(remark.Type))
                {
                    writer.WriteAttributeString("type", remark.Type);
                }
                if (!string.IsNullOrWhiteSpace(remark.Lang))
                {
                    writer.WriteAttributeString("lang", remark.Lang);
                }
                writer.WriteValue(remark.Value);
                writer.WriteEndElement(); // !REMARKS
            }
        } // !_writeRemarks()

        internal void _writeDate(XmlTextWriter writer, string nodeName, DateTime? dt)
        {
            if (dt.HasValue)
            {
                writer.WriteElementString(nodeName, dt.Value.ToString("yyyy-MM-dd"));
            }
        } // !_writeDate()
        
        internal void _writeDateTime(XmlTextWriter writer, string nodeName, DateTime? dt)
        {
            if (dt.HasValue)
            {
                writer.WriteElementString(nodeName, dt.Value.ToString("yyyy-MM-ddTHH:mm:sszzz"));
            }
        } // !_writeDateTime()
        
        internal void _writeDeliveryDate(XmlTextWriter writer, DeliveryDate deliveryDate)
        {
            if (deliveryDate?.EndDate == null || !deliveryDate.StartDate.HasValue)
            {
                return;
            }
            writer.WriteStartElement("DELIVERY_DATE");
            if (deliveryDate.Type != DeliveryDateTypes.Unknown)
            {
                writer.WriteAttributeString("type", deliveryDate.Type.EnumToString());
            }
            _writeDateTime(writer, "DELIVERY_START_DATE", deliveryDate.StartDate);
            _writeDateTime(writer, "DELIVERY_END_DATE", deliveryDate.EndDate);
            writer.WriteEndElement(); // !DELIVERY_DATE
        } // !_writeDeliveryDate()

        internal void _writeOptionalElementString(XmlTextWriter writer, string tagName, string value, Dictionary<string, string> attributes = null)
        {
            if (!String.IsNullOrEmpty(value))
            {
                writer.WriteStartElement(tagName);

                if (attributes != null)
                {
                    foreach (KeyValuePair<string, string> kv in attributes)
                    {
                        if (!string.IsNullOrWhiteSpace(kv.Value))
                        {
                            writer.WriteAttributeString(kv.Key, kv.Value);
                        }
                    }
                }

                writer.WriteValue(value);
                writer.WriteEndElement();
            }
        } // !_writeOptionalElementString()
        
        internal void _writeOptionalElementBool(XmlTextWriter writer, string tagName, bool? value, Dictionary<string, string> attributes = null)
        {
            if (value == null)
            {
                return;
            }
            var boolAsString = value == true ? "TRUE" : "FALSE";
            _writeOptionalElementString(writer, tagName ,boolAsString, attributes);
        } // !_writeOptionalElementBool()

        internal void _writeAmount(XmlTextWriter writer, string tagName, int value)
        {
            writer.WriteStartElement(tagName);
            writer.WriteValue(value);
            writer.WriteEndElement(); // !tagName
        } // !_writeOptionalAmount()


        internal void _writeOptionalAmount(XmlTextWriter writer, string tagName, decimal? value, int numDecimals = 2)
        {
            if (!value.HasValue)
            {
                return;
            }

            writer.WriteStartElement(tagName);
            writer.WriteValue(_formatDecimal(value.Value, numDecimals));
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