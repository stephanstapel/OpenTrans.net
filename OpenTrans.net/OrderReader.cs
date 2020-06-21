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
using System.Xml;

namespace OpenTrans.net
{
    internal class OrderReader
    {
        public Order Load(Stream stream)
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

            Order retval = new Order();

            XmlNode headerNode = doc.SelectSingleNode("//openTrans:ORDER_HEADER", nsmgr);
            if (headerNode != null)
            {
                DateTime? generationDate = _readDateTime(headerNode, "./openTrans:CONTROL_INFO/openTrans:GENERATION_DATE", nsmgr);
                retval.Id = XmlUtils.NodeAsString(headerNode, "./openTrans:ORDER_INFO/openTrans:ORDER_ID", nsmgr);
                retval.OrderDate = _readDateTime(headerNode, "./openTrans:ORDER_INFO/openTrans:ORDER_DATE", nsmgr);

                XmlNodeList partyNodes = headerNode.SelectNodes(".//openTrans:PARTIES/openTrans:PARTY", nsmgr);
                foreach(XmlNode partyNode in partyNodes)
                {
                    Party p = _readParty(partyNode, nsmgr);
                    retval.Parties.Add(p);
                }
            }

            XmlNodeList itemNodes = doc.SelectNodes("//openTrans:ORDER_ITEM_LIST/openTrans:ORDER_ITEM", nsmgr);
            foreach (XmlNode itemNode in itemNodes)
            {
                retval.OrderItems.Add(_readOrderItem(itemNode, nsmgr));
            }

            return retval;
        } // !Load()


        public Order Load(string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                throw new FileNotFoundException();
            }

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            Order retval = Load(fs);
            fs.Close();
            return retval;
        } // !Load()


        private DateTime? _readDateTime(XmlNode node, string xpath, XmlNamespaceManager nsmgr = null)
        {
            string _temp = XmlUtils.NodeAsString(node, xpath, nsmgr);
            if (DateTime.TryParseExact(_temp, "yyyy-MM-ddThh:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime retval))
            {
                return retval;
            }

            if (DateTime.TryParseExact(_temp, "yyyy-MM-ddThh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out retval))
            {
                return retval;
            }

            return null;
        } // !_readDateTime()


        private OrderItem _readOrderItem(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }

            List<string> remarks = new List<string>();
            foreach(XmlNode remarkNode in node.SelectNodes("./openTrans:REMARKS", nsmgr))
            {
                remarks.Add(XmlUtils.NodeAsString(remarkNode, ".", nsmgr));
            }

            OrderItem item = new OrderItem()
            {
                LineItemId = XmlUtils.NodeAsString(node, "./openTrans:LINE_ITEM_ID", nsmgr),
                ProductId = _readProductId(node.SelectSingleNode("./openTrans:PRODUCT_ID", nsmgr), nsmgr),
                Quantity = XmlUtils.NodeAsDecimal(node, "./openTrans:QUANTITY", nsmgr),
                OrderUnit = default(QuantityCodes).FromString(XmlUtils.NodeAsString(node, "./bmecat:ORDER_UNIT", nsmgr)),
                LineAmount = XmlUtils.NodeAsDecimal(node, "./openTrans:PRICE_LINE_AMOUNT", nsmgr),                
                Remarks = remarks
            };

            return item;
        } // !_readOrderItem()


        private ProductId _readProductId(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }

            ProductId id = new ProductId()
            {
                SupplierPId = XmlUtils.NodeAsString(node, "./bmecat:SUPPLIER_PID", nsmgr),
                SupplierIdRef = XmlUtils.NodeAsString(node, "./bmecat:SUPPLIER_IDREF", nsmgr),
                DescriptionShort = XmlUtils.NodeAsString(node, "./bmecat:DESCRIPTION_SHORT", nsmgr),
                DescriptionLong = XmlUtils.NodeAsString(node, "./bmecat:DESCRIPTION_LONG", nsmgr)
            };

            return id;
        } // !_readProductId()


        private Party _readParty(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }

            List<PartyRoles> roles = new List<PartyRoles>();
            foreach(XmlNode roleNode in node.SelectNodes("./openTrans:PARTY_ROLE", nsmgr))
            {
                roles.Add(default(PartyRoles).FromString(XmlUtils.NodeAsString(roleNode, ".", nsmgr)));
            }

            Party retval = new Party()
            {                
                Roles = roles,
                Name = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:NAME", nsmgr),
                Name2 = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:NAME2", nsmgr),
                Name3 = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:NAME3", nsmgr),
                Department = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:DEPARTMENT", nsmgr),
                Street = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:STREET", nsmgr),
                Zip = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:ZIP", nsmgr),
                BoxNo = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:BOXNO", nsmgr),
                ZipBox = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:ZIPBOX", nsmgr),
                City = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:CITY", nsmgr),
                State = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:STATE", nsmgr),
                CountryCode = default(CountryCodes).FromString(XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:COUNTRY", nsmgr)),
                VATId = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:VAT_ID", nsmgr),
                TaxNumber = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:TAX_NUMBER", nsmgr),
                FaxNo = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:FAX", nsmgr),
                PhoneNo = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:PHONE", nsmgr),
                Url = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:URL", nsmgr),
            };

            foreach(XmlNode idNode in node.SelectNodes("./bmecat:PARTY_ID", nsmgr))
            {
                retval.Ids.Add(new PartyId()
                {
                    Id = idNode.InnerText,
                    Type = default(PartyIdTypes).FromString(XmlUtils.AttributeText(idNode, "type"))
                });
            }
            

            // email field can me used in single mode and multi address mode
            XmlNodeList emailAddressNodes = node.SelectNodes("./openTrans:ADDRESS/bmecat:EMAILS/bmecat:EMAIL", nsmgr);
            if (emailAddressNodes.Count > 0)
            {
                foreach (XmlNode emailAddressNode in emailAddressNodes)
                {
                    retval.EmailAddresses.Add(XmlUtils.NodeAsString(emailAddressNode, ".", nsmgr));
                }
            }
            else
            {
                string _emailAddress = XmlUtils.NodeAsString(node, "./openTrans:ADDRESS/bmecat:EMAIL", nsmgr);
                if (!String.IsNullOrEmpty(_emailAddress))
                {
                    retval.EmailAddresses.Add(_emailAddress);
                }
            }
            
            XmlNode contactNode = node.SelectSingleNode("./openTrans:ADDRESS/openTrans:CONTACT_DETAILS", nsmgr);
            if (contactNode != null)
            {
                List<string> _roles = new List<string>();
                List<string> _emailAddresses = new List<string>();

                foreach(XmlNode roleNode in contactNode.SelectNodes("./openTrans:CONTACT_ROLE", nsmgr))
                {
                    _roles.Add(XmlUtils.NodeAsString(roleNode, ".", nsmgr));
                }

                XmlNodeList contactEmailAddressNodes = contactNode.SelectNodes("./bmecat:EMAILS/bmecat:EMAIL", nsmgr);
                if (contactEmailAddressNodes.Count > 0)
                {
                    foreach (XmlNode emailAddressNode in contactEmailAddressNodes)
                    {
                        _emailAddresses.Add(XmlUtils.NodeAsString(emailAddressNode, ".", nsmgr));
                    }
                }
                else
                {
                    string _emailAddress = XmlUtils.NodeAsString(node, "./bmecat:EMAIL", nsmgr);
                    if (!String.IsNullOrEmpty(_emailAddress))
                    {
                        retval.EmailAddresses.Add(_emailAddress);
                    }
                }
                
                retval.ContactDetails = new Contact()
                {
                    Id = XmlUtils.NodeAsString(contactNode, "./bmecat:CONTACT_ID", nsmgr),
                    Name = XmlUtils.NodeAsString(contactNode, "./bmecat:CONTACT_NAME", nsmgr),
                    FirstName = XmlUtils.NodeAsString(contactNode, "./bmecat:FIRST_NAME", nsmgr),
                    Title = XmlUtils.NodeAsString(contactNode, "./bmecat:TITLE", nsmgr),
                    AcademicTitle = XmlUtils.NodeAsString(contactNode, "./bmecat:ACADEMIC_TITLE", nsmgr),
                    Description = XmlUtils.NodeAsString(contactNode, "./bmecat:CONTACT_DESCR", nsmgr),
                    Url = XmlUtils.NodeAsString(contactNode, "./bmecat:URL", nsmgr),
                    PhoneNo = XmlUtils.NodeAsString(contactNode, "./bmecat:PHONE", nsmgr),
                    FaxNo = XmlUtils.NodeAsString(contactNode, "./bmecat:FAX", nsmgr),
                    Authentification = XmlUtils.NodeAsString(contactNode, "./bmecat:AUTHENTIFICATION", nsmgr),
                    Roles = _roles,
                    EmailAddresses = _emailAddresses
                };
            }

            return retval;
        } // !_readParty()
    }
}
 