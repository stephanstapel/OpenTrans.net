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
using System.Xml;

namespace OpenTrans.net
{
    /// <summary>
    /// This class contains base functionality that is useable by readers for all OpenTrans message types
    /// </summary>
    internal class BaseReader
    {
        protected DateTime? _nodeAsDateTime(XmlNode node, string xpath, XmlNamespaceManager nsmgr = null)
        {
            string _temp = XmlUtils.NodeAsString(node, xpath, nsmgr);
            
            try
            { 
                return XmlConvert.ToDateTime(_temp, XmlDateTimeSerializationMode.RoundtripKind);              
            }
            catch (FormatException) 
            {
            }

            // for compatibility
            if (DateTime.TryParseExact(_temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime retval))
            {
                return retval;
            }

            return null;
        } // !_readDateTime()


        protected OrderItem _readItem(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }

            OrderItem item = new OrderItem();
            
            XmlNodeList featureNodes = node.SelectNodes("./*[local-name()='PRODUCT_FEATURES']/*[local-name()='FEATURE']", nsmgr);
            if (featureNodes != null) {
                foreach (XmlNode featureNode in featureNodes)
                {
                    item.ProductFeatures.Add(_readFeature(featureNode, nsmgr));
                }
            } // !featureNodes
            
            XmlNodeList remarkNodes = node.SelectNodes("./*[local-name()='REMARKS']", nsmgr);
            if (remarkNodes != null)
            {
                foreach (XmlNode remarkNode in remarkNodes)
                {
                    Remark remark = new Remark
                    {
                        Value = XmlUtils.NodeAsString(remarkNode, ".", nsmgr),
                        Type = XmlUtils.AttributeText(remarkNode, "type"),
                        Lang = XmlUtils.AttributeText(remarkNode, "lang")
                    };
                    item.Remarks.Add(remark);
                }
            } // !remarkNodes
            
            XmlNode deliveryDateRefNode = node.SelectSingleNode("./*[local-name()='DELIVERY_DATE']", nsmgr);
            if (deliveryDateRefNode != null)
            {
                DeliveryDate deliveryDate = new DeliveryDate
                {
                    StartDate = _nodeAsDateTime(deliveryDateRefNode, "./*[local-name()='DELIVERY_START_DATE']", nsmgr),
                    EndDate = _nodeAsDateTime(deliveryDateRefNode, "./*[local-name()='DELIVERY_END_DATE']", nsmgr),
                    Type = default(DeliveryDateTypes).FromString(XmlUtils.AttributeText(deliveryDateRefNode, "type"))
                };
                item.DeliveryDate = deliveryDate;
            } // !deliveryDateRefNode

            item.LineItemId = XmlUtils.NodeAsString(node, "./*[local-name()='LINE_ITEM_ID']", nsmgr);
            item.ProductId = _readProductId(node.SelectSingleNode("./*[local-name()='PRODUCT_ID']", nsmgr), nsmgr);
            item.Quantity = XmlUtils.NodeAsDecimal(node, "./*[local-name()='QUANTITY']", nsmgr);
            item.OrderUnit = default(QuantityCodes).FromString(XmlUtils.NodeAsString(node, "./*[local-name()='ORDER_UNIT']", nsmgr));
            item.LineAmount = XmlUtils.NodeAsDecimal(node, "./*[local-name()='PRICE_LINE_AMOUNT']", nsmgr);
            item.ProductPriceFix = _readProductPriceFix(node.SelectSingleNode("./*[local-name()='PRODUCT_PRICE_FIX']", nsmgr), nsmgr);

            return item;
        } // !_readItem()


        private Feature _readFeature(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }

            return new Feature
            {
                Name = XmlUtils.NodeAsString(node, "./*[local-name()='FNAME']", nsmgr),
                Value = XmlUtils.NodeAsString(node, "./*[local-name()='FVALUE']", nsmgr),
                ValueDetails = XmlUtils.NodeAsString(node, "./*[local-name()='FVALUE_DETAILS']", nsmgr),
                Description = XmlUtils.NodeAsString(node, "./*[local-name()='FDESCR']", nsmgr),
                Order = XmlUtils.NodeAsString(node, "./*[local-name()='FORDER']", nsmgr),
                Template = XmlUtils.NodeAsString(node, "./*[local-name()='FTEMPLATE']", nsmgr),
                Unit = default(QuantityCodes).FromString(XmlUtils.NodeAsString(node, "./*[local-name()='FUNIT']", nsmgr)),
                ValueType = XmlUtils.NodeAsEnum<ValueTypes>(node, "./*[local-name()='FVALUE_TYPE']", nsmgr),
            };
        } // !_readFeature()


        private ProductId _readProductId(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }
            
            SupplierProductId supplierPId = default;
            XmlNode supplierPIdNode = node.SelectSingleNode("./*[local-name()='SUPPLIER_PID']", nsmgr);
            if (supplierPIdNode != null)
            {
                supplierPId = new SupplierProductId
                {
                    Id = supplierPIdNode.InnerText,
                    Type = default(SupplierProductIdTypes).FromString(XmlUtils.AttributeText(supplierPIdNode, "type"))
                };
            } // !supplierPIdNode
            
            PartyId supplierIdRef = default;
            XmlNode supplierIdRefNode = node.SelectSingleNode("./*[local-name()='SUPPLIER_IDREF']", nsmgr);
            if (supplierIdRefNode != null)
            {
                supplierIdRef = new PartyId
                {
                    Id = supplierIdRefNode.InnerText,
                    Type = default(PartyIdTypes).FromString(XmlUtils.AttributeText(supplierIdRefNode, "type"))
                };
            } // !supplierIdRefNode
            
            return new ProductId
            {
                SupplierPId = supplierPId,
                SupplierIdRef = supplierIdRef,
                DescriptionShort = XmlUtils.NodeAsString(node, "./*[local-name()='DESCRIPTION_SHORT']", nsmgr),
                DescriptionLong = XmlUtils.NodeAsString(node, "./*[local-name()='DESCRIPTION_LONG']", nsmgr)
            };
        } // !_readProductId() 


        private ProductPriceFix _readProductPriceFix(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }

            ProductPriceFix productPriceFix = new ProductPriceFix();
            
            XmlNode priceBaseFixRefNode = node.SelectSingleNode("./*[local-name()='PRICE_BASE_FIX']", nsmgr);
            if (priceBaseFixRefNode != null)
            {
                productPriceFix.PriceBaseFix = new PriceBaseFix
                {
                    PriceUnitValue = XmlUtils.NodeAsDecimal(priceBaseFixRefNode, "./*[local-name()='PRICE_UNIT_VALUE']", nsmgr) ?? 0,
                    PriceUnit = default(QuantityCodes).FromString(XmlUtils.NodeAsString(priceBaseFixRefNode, "./*[local-name()='PRICE_UNIT']", nsmgr)),
                    PriceUnitFactor = XmlUtils.NodeAsDecimal(priceBaseFixRefNode, "./*[local-name()='PRICE_UNIT_FACTOR']", nsmgr),
                };
            } // !priceBaseFixRefNode

            productPriceFix.PriceAmount = XmlUtils.NodeAsDecimal(node, "./*[local-name()='PRICE_AMOUNT']", nsmgr) ?? 0;
            productPriceFix.PriceQuantity = XmlUtils.NodeAsDecimal(node, "./*[local-name()='PRICE_QUANTITY']", nsmgr);

            return productPriceFix;
        } // !_readProductId()


        protected Party _readParty(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }

            List<PartyRoles> partyRoles = new List<PartyRoles>();
            List<string> partyRolesCustom = new List<string>();
            XmlNodeList partyRoleNodes = node.SelectNodes("./*[local-name()='PARTY_ROLE']", nsmgr);
            if (partyRoleNodes != null)
            {
                foreach (XmlNode roleNode in partyRoleNodes)
                {
                    string stringValue = XmlUtils.NodeAsString(roleNode, ".", nsmgr);
                    PartyRoles v = default(PartyRoles).FromString(stringValue);
                    if (v != PartyRoles.Unknown) 
                    { 
                        partyRoles.Add(v);
                    }
                    else
                    { 
                        partyRolesCustom.Add(stringValue);
                    }
                }
            } // !roleNodes

            Party party = new Party
            {
                Roles = partyRoles,
                RolesCustom = partyRolesCustom,
                Name = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='NAME']", nsmgr),
                Name2 = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='NAME2']", nsmgr),
                Name3 = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='NAME3']", nsmgr),
                Department = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='DEPARTMENT']", nsmgr),
                Street = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='STREET']", nsmgr),
                Zip = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='ZIP']", nsmgr),
                BoxNo = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='BOXNO']", nsmgr),
                ZipBox = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='ZIPBOX']", nsmgr),
                City = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='CITY']", nsmgr),
                State = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='STATE']", nsmgr),
                Country = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='COUNTRY']", nsmgr),
                CountryCode = default(CountryCodes).FromString(XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='COUNTRY_CODED']", nsmgr)),
                VATId = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='VAT_ID']", nsmgr),
                TaxNumber = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='TAX_NUMBER']", nsmgr),
                FaxNo = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='FAX']", nsmgr),
                PhoneNo = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='PHONE']", nsmgr),
                Url = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='URL']", nsmgr),
            };

            XmlNodeList idNodes = node.SelectNodes("./*[local-name()='PARTY_ID']", nsmgr);
            if (idNodes != null)
            {
                foreach (XmlNode idNode in idNodes)
                {
                    party.Ids.Add(new PartyId
                    {
                        Id = idNode.InnerText,
                        Type = default(PartyIdTypes).FromString(XmlUtils.AttributeText(idNode, "type"))
                    });
                }
            } // !idNodes

            string email = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='EMAIL']", nsmgr);
            if (!string.IsNullOrEmpty(email))
            {
                party.EmailAddress = email;
            }

            XmlNode contactNode = node.SelectSingleNode("./*[local-name()='ADDRESS']/*[local-name()='CONTACT_DETAILS']", nsmgr);
            if (contactNode != null)
            {
                List<string> contactRoles = new List<string>();
                List<string> contactEmailAddresses = new List<string>();

                XmlNodeList contactRoleNodes = contactNode.SelectNodes("./*[local-name()='CONTACT_ROLE']", nsmgr);
                if (contactRoleNodes != null)
                {
                    foreach (XmlNode roleNode in contactRoleNodes)
                    {
                        contactRoles.Add(XmlUtils.NodeAsString(roleNode, ".", nsmgr));
                    }
                } // !contactRoleNodes

                XmlNodeList contactEmailAddressNodes = contactNode.SelectNodes("./*[local-name()='EMAILS']/*[local-name()='EMAIL']", nsmgr);
                if (contactEmailAddressNodes != null && 0 < contactEmailAddressNodes.Count)
                {
                    foreach (XmlNode emailAddressNode in contactEmailAddressNodes)
                    {
                        contactEmailAddresses.Add(XmlUtils.NodeAsString(emailAddressNode, ".", nsmgr));
                    }
                }
                else
                {
                    string contactEmailAddress = XmlUtils.NodeAsString(node, "./*[local-name()='EMAIL']", nsmgr);
                    if (!String.IsNullOrEmpty(contactEmailAddress))
                    {
                        contactEmailAddresses.Add(contactEmailAddress);
                    }
                } // !contactEmailAddressNodes

                party.ContactDetails = new Contact
                {
                    Id = XmlUtils.NodeAsString(contactNode, "./*[local-name()='CONTACT_ID']", nsmgr),
                    Name = XmlUtils.NodeAsString(contactNode, "./*[local-name()='CONTACT_NAME']", nsmgr),
                    FirstName = XmlUtils.NodeAsString(contactNode, "./*[local-name()='FIRST_NAME']", nsmgr),
                    Title = XmlUtils.NodeAsString(contactNode, "./*[local-name()='TITLE']", nsmgr),
                    AcademicTitle = XmlUtils.NodeAsString(contactNode, "./*[local-name()='ACADEMIC_TITLE']", nsmgr),
                    Description = XmlUtils.NodeAsString(contactNode, "./*[local-name()='CONTACT_DESCR']", nsmgr),
                    Url = XmlUtils.NodeAsString(contactNode, "./*[local-name()='URL']", nsmgr),
                    PhoneNo = XmlUtils.NodeAsString(contactNode, "./*[local-name()='PHONE']", nsmgr),
                    FaxNo = XmlUtils.NodeAsString(contactNode, "./*[local-name()='FAX']", nsmgr),
                    Authentification = XmlUtils.NodeAsString(contactNode, "./*[local-name()='AUTHENTIFICATION']", nsmgr),
                    Roles = contactRoles,
                    EmailAddresses = contactEmailAddresses
                };
            }

            return party;
        } // !_readParty()
    }
}
