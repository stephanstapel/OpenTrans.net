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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace OpenTrans.net
{
    /// <summary>
    /// This class contains base functionality that is useable by writers for all OpenTrans message types
    /// </summary>
    internal class BaseWriter
    {
        /// <summary>
        /// Buffer size used when copying the generated document into the target stream
        /// </summary>
        private const int CopyBufferSize = 81920;

        /// <summary>
        /// Maximum scale of System.Decimal
        /// </summary>
        private const int MaxDecimals = 28;

        /// <summary>
        /// Format strings indexed by the minimum number of decimal places, e.g. "0.00##..." for two decimals
        /// </summary>
        private static readonly string[] _DecimalFormats = Enumerable.Range(0, MaxDecimals + 1)
            .Select(i => "0." + new string('0', i) + new string('#', MaxDecimals - i))
            .ToArray();

        /// <summary>
        /// Generates the document in memory using the synchronous save function and copies it asynchronously
        /// into the target stream. The stream position is reset to the original position afterwards, just like
        /// in the synchronous variant.
        /// </summary>
        protected async Task _saveAsync(Stream stream, Action<Stream> save, CancellationToken cancellationToken)
        {
            if (!stream.CanWrite || !stream.CanSeek)
            {
                throw new IllegalStreamException("Cannot write to stream.");
            }

            using (MemoryStream buffer = _generate(save, cancellationToken))
            {
                long streamPosition = stream.Position;
                await buffer.CopyToAsync(stream, CopyBufferSize, cancellationToken).ConfigureAwait(false);
                await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
                stream.Seek(streamPosition, SeekOrigin.Begin);
            }
        } // !_saveAsync()


        /// <summary>
        /// Creates the given file and saves the document asynchronously into it.
        ///
        /// The document is generated before the file is opened, so cancellation or errors during generation leave an
        /// existing file untouched. Once the file has been opened, the write is completed to avoid truncated documents.
        /// </summary>
        protected async Task _saveAsync(string fileName, Action<Stream> save, CancellationToken cancellationToken)
        {
            using (MemoryStream buffer = _generate(save, cancellationToken))
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
            {
                await buffer.CopyToAsync(stream, CopyBufferSize, CancellationToken.None).ConfigureAwait(false);
                await stream.FlushAsync(CancellationToken.None).ConfigureAwait(false);
            }
        } // !_saveAsync()


        /// <summary>
        /// Generates the document into a memory buffer which is positioned at its beginning
        /// </summary>
        private MemoryStream _generate(Action<Stream> save, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            MemoryStream buffer = new MemoryStream();
            try
            {
                save(buffer);
                cancellationToken.ThrowIfCancellationRequested();
                return buffer;
            }
            catch
            {
                buffer.Dispose();
                throw;
            }
        } // !_generate()


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
                foreach (string role in party.ContactDetails.Roles ?? Enumerable.Empty<string>())
                {
                    _writeOptionalElementString(writer, "CONTACT_ROLE", role);
                }
                _writeOptionalElementString(writer, "bmecat:CONTACT_DESCR", party.ContactDetails.Description);
                _writePhoneNumbers(writer, "bmecat:PHONE", party.ContactDetails.PhoneNo);
                _writePhoneNumbers(writer, "bmecat:FAX", party.ContactDetails.FaxNo);
                _writeOptionalElementString(writer, "bmecat:URL", party.ContactDetails.Url);
                if (party.ContactDetails.EmailAddresses?.Any() == true)
                {
                    writer.WriteStartElement("bmecat:EMAILS");
                    foreach (string emailAddress in party.ContactDetails.EmailAddresses)
                    {
                        _writeOptionalElementString(writer, "bmecat:EMAIL", emailAddress);
                    }
                    writer.WriteEndElement(); // !bmecat:EMAILS
                }

                if (!string.IsNullOrEmpty(party.ContactDetails.Authentification))
                {
                    writer.WriteStartElement("bmecat:AUTHENTIFICATION");
                    _writeOptionalElementString(writer, "bmecat:LOGIN", party.ContactDetails.Authentification);
                    _writeOptionalElementString(writer, "bmecat:PASSWORD", party.ContactDetails.AuthentificationPassword);
                    writer.WriteEndElement(); // !bmecat:AUTHENTIFICATION
                }

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
            _writeOptionalElementString(writer, "TAX_NUMBER", party.TaxNumber);
            _writePhoneNumbers(writer, "bmecat:PHONE", party.PhoneNo);
            _writePhoneNumbers(writer, "bmecat:FAX", party.FaxNo);
            _writeOptionalElementString(writer, "bmecat:EMAIL", party.EmailAddress);
            _writeOptionalElementString(writer, "bmecat:URL", party.Url);
            writer.WriteEndElement(); // !ADDRESS

            writer.WriteEndElement(); // !PARTY
        } // !_writeParty()

        /// <summary>
        /// writes the phone numbers as XML elements with the given elementname
        /// </summary>
        private void _writePhoneNumbers(XmlTextWriter writer, string elementName, List<PhoneNo> value) 
        {
            foreach (var phoneNo in value) 
            {
                Dictionary<string, string> typeAttribute = null;
                if (!string.IsNullOrWhiteSpace(phoneNo.Type.EnumToString())) 
                { 
                    typeAttribute = new Dictionary<string, string>() { { "type", phoneNo.Type.EnumToString() } };
                }
                _writeOptionalElementString(writer, elementName, phoneNo.Number, typeAttribute);
            }
        }

        internal void _writeCustomerOrderReference(XmlTextWriter writer, CustomerOrderReference customerOrderReference)
        {
            if (customerOrderReference != null)
            {
                writer.WriteStartElement("CUSTOMER_ORDER_REFERENCE");
                _writeOptionalElementString(writer, "ORDER_ID", customerOrderReference.OrderId);
                writer.WriteEndElement(); // !CUSTOMER_ORDER_REFERENCE
            }
        }  // !_writeCustomerOrderReference()


        /// <summary>
        /// ORDER_PARTIES_REFERENCE is mandatory. If it is not set explicitly, it is derived from the first id of
        /// the first buyer and supplier party.
        /// </summary>
        internal void _writeOrderPartiesReference(XmlTextWriter writer, OrderPartiesReference orderPartiesReference, List<Party> parties)
        {
            _writeOrderPartiesReference(writer, orderPartiesReference ?? _deriveOrderPartiesReference(parties));
        } // !_writeOrderPartiesReference()


        private OrderPartiesReference _deriveOrderPartiesReference(List<Party> parties)
        {
            PartyId buyerId = parties.FirstOrDefault(p => p.Roles.Contains(PartyRoles.Buyer) && p.Ids.Any())?.Ids[0];
            PartyId supplierId = parties.FirstOrDefault(p => p.Roles.Contains(PartyRoles.Supplier) && p.Ids.Any())?.Ids[0];
            if (buyerId == null && supplierId == null)
            {
                return null;
            }

            return new OrderPartiesReference
            {
                BuyerIdRef = buyerId,
                SupplierIdRef = supplierId
            };
        } // !_deriveOrderPartiesReference()


        internal void _writeOrderPartiesReference(XmlTextWriter writer, OrderPartiesReference orderPartiesReference)
        {
            if (orderPartiesReference != null)
            {
                writer.WriteStartElement("ORDER_PARTIES_REFERENCE");
                _writeOptionalElementString(writer, "bmecat:BUYER_IDREF", orderPartiesReference.BuyerIdRef?.Id, new Dictionary<string, string>() { { "type", orderPartiesReference.BuyerIdRef?.Type.EnumToString() } });
                _writeOptionalElementString(writer, "bmecat:SUPPLIER_IDREF", orderPartiesReference.SupplierIdRef?.Id, new Dictionary<string, string>() { { "type", orderPartiesReference.SupplierIdRef?.Type.EnumToString() } });
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
                    writer.WriteStartElement("FEATURE");
                    if (!string.IsNullOrEmpty(feature.Name))
                    {
                        _writeOptionalElementString(writer, "bmecat:FNAME", feature.Name);
                    }
                    else
                    {
                        _writeOptionalElementString(writer, "bmecat:FTEMPLATE", feature.Template);
                    }
                    _writeOptionalElementString(writer, "bmecat:FVALUE", feature.Value);
                    _writeOptionalElementString(writer, "bmecat:FUNIT", feature.Unit.EnumToString());
                    _writeOptionalElementString(writer, "bmecat:FORDER", feature.Order);
                    _writeOptionalElementString(writer, "bmecat:FDESCR", feature.Description, new Dictionary<string, string> { { "lang", "deu" } });
                    _writeOptionalElementString(writer, "bmecat:FVALUE_DETAILS", feature.ValueDetails);
                    _writeOptionalElementString(writer, "bmecat:FVALUE_TYPE", feature.ValueType?.EnumToString());
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
                    _writeOptionalElementString(writer, "bmecat:PRICE_UNIT", item.ProductPriceFix.PriceBaseFix.PriceUnit.EnumToString());
                    _writeOptionalAmount(writer, "bmecat:PRICE_UNIT_FACTOR", item.ProductPriceFix.PriceBaseFix.PriceUnitFactor);
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
            if (deliveryDate == null || (!deliveryDate.StartDate.HasValue && !deliveryDate.EndDate.HasValue))
            {
                return;
            }
            writer.WriteStartElement("DELIVERY_DATE");
            if (deliveryDate.Type != DeliveryDateTypes.Unknown)
            {
                writer.WriteAttributeString("type", deliveryDate.Type.EnumToString());
            }
            // both elements are mandatory, a single date is interpreted as start and end of the delivery period
            _writeDateTime(writer, "DELIVERY_START_DATE", deliveryDate.StartDate ?? deliveryDate.EndDate);
            _writeDateTime(writer, "DELIVERY_END_DATE", deliveryDate.EndDate ?? deliveryDate.StartDate);
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


        /// <summary>
        /// Formats the value with at least numDecimals decimal places. Additional decimal places are kept
        /// so that no precision is lost.
        /// </summary>
        internal string _formatDecimal(decimal value, int numDecimals = 2)
        {
            numDecimals = Math.Max(0, Math.Min(numDecimals, MaxDecimals));
            return value.ToString(_DecimalFormats[numDecimals], CultureInfo.InvariantCulture);
        } // !_formatDecimal()
    }
}