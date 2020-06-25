using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace OpenTrans.net
{
    internal class ReaderBase
    {
        protected DateTime? _nodeAsDateTime(XmlNode node, string xpath, XmlNamespaceManager nsmgr = null)
        {
            string _temp = XmlUtils.NodeAsString(node, xpath, nsmgr);

            if (_temp.Length == 8)
            {
                if (DateTime.TryParseExact(_temp, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime retval))
                {
                    return retval;
                }
            }
            else
            {
                if (DateTime.TryParseExact(_temp, "yyyy-MM-ddThh:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime retval))
                {
                    return retval;
                }

                if (DateTime.TryParseExact(_temp, "yyyy-MM-ddThh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out retval))
                {
                    return retval;
                }
            }

            return null;
        } // !_readDateTime()


        protected OrderItem _readItem(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }

            List<string> remarks = new List<string>();
            foreach (XmlNode remarkNode in node.SelectNodes("./*[local-name()='REMARKS']", nsmgr))
            {
                remarks.Add(XmlUtils.NodeAsString(remarkNode, ".", nsmgr));
            }

            OrderItem item = new OrderItem()
            {
                LineItemId = XmlUtils.NodeAsString(node, "./*[local-name()='LINE_ITEM_ID']", nsmgr),
                ProductId = _readProductId(node.SelectSingleNode("./*[local-name()='PRODUCT_ID']", nsmgr), nsmgr),
                Quantity = XmlUtils.NodeAsDecimal(node, "./*[local-name()='QUANTITY']", nsmgr),
                OrderUnit = default(QuantityCodes).FromString(XmlUtils.NodeAsString(node, "./*[local-name()='ORDER_UNIT']", nsmgr)),
                LineAmount = XmlUtils.NodeAsDecimal(node, "./*[local-name()='PRICE_LINE_AMOUNT']", nsmgr),
                Remarks = remarks
            };

            return item;
        } // !_readItem()


        private ProductId _readProductId(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }

            ProductId id = new ProductId()
            {
                SupplierPId = XmlUtils.NodeAsString(node, "./*[local-name()='SUPPLIER_PID']", nsmgr),
                SupplierIdRef = XmlUtils.NodeAsString(node, "./*[local-name()='SUPPLIER_IDREF']", nsmgr),
                DescriptionShort = XmlUtils.NodeAsString(node, "./*[local-name()='DESCRIPTION_SHORT']", nsmgr),
                DescriptionLong = XmlUtils.NodeAsString(node, "./*[local-name()='DESCRIPTION_LONG']", nsmgr)
            };

            return id;
        } // !_readProductId() 


        protected Party _readParty(XmlNode node, XmlNamespaceManager nsmgr = null)
        {
            if (node == null)
            {
                return null;
            }

            List<PartyRoles> roles = new List<PartyRoles>();
            foreach (XmlNode roleNode in node.SelectNodes("./*[local-name()='PARTY_ROLE']", nsmgr))
            {
                roles.Add(default(PartyRoles).FromString(XmlUtils.NodeAsString(roleNode, ".", nsmgr)));
            }

            Party retval = new Party()
            {
                Roles = roles,
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
                CountryCode = default(CountryCodes).FromString(XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='COUNTRY']", nsmgr)),
                VATId = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='VAT_ID']", nsmgr),
                TaxNumber = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='TAX_NUMBER']", nsmgr),
                FaxNo = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='FAX']", nsmgr),
                PhoneNo = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='PHONE']", nsmgr),
                Url = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='URL']", nsmgr),
            };

            foreach (XmlNode idNode in node.SelectNodes("./*[local-name()='PARTY_ID']", nsmgr))
            {
                retval.Ids.Add(new PartyId()
                {
                    Id = idNode.InnerText,
                    Type = default(PartyIdTypes).FromString(XmlUtils.AttributeText(idNode, "type"))
                });
            }


            // email field can me used in single mode and multi address mode
            XmlNodeList emailAddressNodes = node.SelectNodes("./*[local-name()='ADDRESS']/*[local-name()='EMAILS']/*[local-name()='EMAIL']", nsmgr);
            if (emailAddressNodes.Count > 0)
            {
                foreach (XmlNode emailAddressNode in emailAddressNodes)
                {
                    retval.EmailAddresses.Add(XmlUtils.NodeAsString(emailAddressNode, ".", nsmgr));
                }
            }
            else
            {
                string _emailAddress = XmlUtils.NodeAsString(node, "./*[local-name()='ADDRESS']/*[local-name()='EMAIL']", nsmgr);
                if (!String.IsNullOrEmpty(_emailAddress))
                {
                    retval.EmailAddresses.Add(_emailAddress);
                }
            }

            XmlNode contactNode = node.SelectSingleNode("./*[local-name()='ADDRESS']/*[local-name()='CONTACT_DETAILS']", nsmgr);
            if (contactNode != null)
            {
                List<string> _roles = new List<string>();
                List<string> _emailAddresses = new List<string>();

                foreach (XmlNode roleNode in contactNode.SelectNodes("./*[local-name()='CONTACT_ROLE']", nsmgr))
                {
                    _roles.Add(XmlUtils.NodeAsString(roleNode, ".", nsmgr));
                }

                XmlNodeList contactEmailAddressNodes = contactNode.SelectNodes("./*[local-name()='EMAILS']/*[local-name()='EMAIL']", nsmgr);
                if (contactEmailAddressNodes.Count > 0)
                {
                    foreach (XmlNode emailAddressNode in contactEmailAddressNodes)
                    {
                        _emailAddresses.Add(XmlUtils.NodeAsString(emailAddressNode, ".", nsmgr));
                    }
                }
                else
                {
                    string _emailAddress = XmlUtils.NodeAsString(node, "./*[local-name()='EMAIL']", nsmgr);
                    if (!String.IsNullOrEmpty(_emailAddress))
                    {
                        retval.EmailAddresses.Add(_emailAddress);
                    }
                }

                retval.ContactDetails = new Contact()
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
                    Roles = _roles,
                    EmailAddresses = _emailAddresses
                };
            }

            return retval;
        } // !_readParty()
    }
}
