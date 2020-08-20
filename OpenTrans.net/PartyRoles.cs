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
using System.Text;

namespace OpenTrans.net
{
    public enum PartyRoles
    {
        /**
         * The business partner is a buyer.
         */
        Buyer,

        /**
         * The business party is a centralized settlement and supports the business of several partners.
         */
        CentralRegulator,

        /**
         * The business party is the customer of the buying company.
         */
        Customer,

        /**
         * The business party is the carrier.
         */
        Deliverer,

        /**
         * The business party is the location of the product shipment or where the service is afforded.
         */
        Delivery,

        /**
         * The business partner is the creator of the document.
         */
        DocumentCreator,

        /**
         * Reference to address and contact of the final recipient.
         * The federal office of export control currently only evaluates on order-header-level. Therefore orders related to exports should not use a party in this element
         * which is different to the header-level element FINAL_DELIVERY_PARTY.
         */
        FinalDelivery,

        /**
         * The business party is an intermediate between product/service provider and benefit recipient.
         */
        Intermediary,

        /**
         * The business party is the invoicing party.
         */
        InvoiceIssuer,

        /**
         * The business party is the invoice receiving party.
         */
        InvoiceRecipient,

        /**
         * The business partner operatores an IPP application.
         */
        IPPOperator,

        /**
         * The business partner is a manufacturer.
         */
        Manufacturer,

        /**
         * The business party runs an electronic market place supporting the processing of procurement and distribution of products and services.
         */
        Marketplace,

        /**
         * The business party is the payer.
         */
        Payer,

        /**
         * The business party is the remittee.
         */
        Remittee,

        /**
         * The business partner is a standardization body. 
         */
        StandardizationBody,

        /**
         * The business partner is a supplier. 
         */
        Supplier,

        /**
         * A trusted instance that e.g. signed and verified the attached digital signature.
         */
        TrustedThirdParty,

        /**
         * If no other role matches this value can be used.
         */
        Other,

        Unknown
    }

    public static class PartyRolesTypesExtensions
    {
        private static readonly List<KeyValuePair<string, PartyRoles>> _Mapping = new List<KeyValuePair<string, PartyRoles>>()
        {
            new KeyValuePair<string, PartyRoles>("buyer", PartyRoles.Buyer),
            new KeyValuePair<string, PartyRoles>("central_regulator", PartyRoles.CentralRegulator),
            new KeyValuePair<string, PartyRoles>("customer", PartyRoles.Customer),
            new KeyValuePair<string, PartyRoles>("deliverer", PartyRoles.Deliverer),
            new KeyValuePair<string, PartyRoles>("delivery", PartyRoles.Delivery),
            new KeyValuePair<string, PartyRoles>("document_creator", PartyRoles.DocumentCreator),
            new KeyValuePair<string, PartyRoles>("final_delivery", PartyRoles.FinalDelivery),
            new KeyValuePair<string, PartyRoles>("intermediary", PartyRoles.Intermediary),
            new KeyValuePair<string, PartyRoles>("invoice_issuer", PartyRoles.InvoiceIssuer),
            new KeyValuePair<string, PartyRoles>("invoice_recipient", PartyRoles.InvoiceRecipient),
            new KeyValuePair<string, PartyRoles>("ipp_operator", PartyRoles.IPPOperator),
            new KeyValuePair<string, PartyRoles>("manufacturer", PartyRoles.Manufacturer),
            new KeyValuePair<string, PartyRoles>("marketplace", PartyRoles.Marketplace),
            new KeyValuePair<string, PartyRoles>("payer", PartyRoles.Payer),
            new KeyValuePair<string, PartyRoles>("remittee", PartyRoles.Remittee),
            new KeyValuePair<string, PartyRoles>("standardization_body", PartyRoles.StandardizationBody),
            new KeyValuePair<string, PartyRoles>("supplier", PartyRoles.Supplier),
            new KeyValuePair<string, PartyRoles>("trustedthirdparty", PartyRoles.TrustedThirdParty),
            new KeyValuePair<string, PartyRoles>("other", PartyRoles.Other),
        };

        public static PartyRoles FromString(this PartyRoles _c, string s)
        {
            s = s.ToLower().Trim();

            try
            {
                return _Mapping.Single(m => m.Key.Equals(s)).Value;
            }
            catch (Exception)
            {
                return PartyRoles.Unknown;
            }
        } // !FromString()


        public static string EnumToString(this PartyRoles c)
        {
            try
            {
                return _Mapping.Single(m => m.Value.Equals(c)).Key;
            }
            catch (Exception)
            {
                return "unknown";
            }
        } // !ToString()
    }
}
