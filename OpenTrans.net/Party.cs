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
using System.Collections.Generic;

namespace OpenTrans.net
{
    /// <summary>
    /// This element contains information about a business partner.
    /// </summary>
    public class Party
    {
        /// <summary>
        /// Unique identifier of the business partner
        /// </summary>
        public List<PartyId> Ids { get; set; } = new List<PartyId>();

        /// <summary>
        /// Role of the business partner in the context of this document (PARTY_ROLE)
        /// </summary>
        public List<PartyRoles> Roles { get; set; } = new List<PartyRoles>();

        /// <summary>
        /// String values of PARTY_ROLEs, that do not have a value according to the standard 
        /// </summary>
        public List<string> RolesCustom { get; set; } = new List<string>();

        /// <summary>
        /// First address line, in most cases the name of the organisation
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// additional space for address information
        /// </summary>
        public string Name2 { get; set; }

        /// <summary>
        /// additional space for address information
        /// </summary>
        public string Name3 { get; set; }

        /// <summary>
        /// Department of the organisation
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Street name and house number
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// ZIP code of address
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// P.O. box number
        /// </summary>
        public string BoxNo { get; set; }

        /// <summary>
        /// ZIP code of P.O. box
        /// </summary>
        public string ZipBox { get; set; }

        /// <summary>
        /// Town or city of the company
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Federal state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// VAT identification number of the business partner
        /// </summary>
        public string VATId { get; set; }

        /// <summary>
        /// Tax number of a business partner
        /// </summary>
        public string TaxNumber { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Country code
        /// </summary>
        public CountryCodes CountryCode { get; set; }

        /// <summary>
        /// Information on a contact person
        /// </summary>
        public Contact ContactDetails { get; set; }

        /// <summary>
        /// Phone numbers - contents of ADDRESS/PHONE element
        /// </summary>
        public List<PhoneNo> PhoneNo { get; set; } = new List<PhoneNo>();

        /// <summary>
        /// Fax numbers - contents of ADDRESS/FAX element
        /// </summary>
        public List<PhoneNo> FaxNo { get; set; }

        /// <summary>
        /// e-mail address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// URL of the company's web site
        /// </summary>
        public string Url { get; set; }
    }
}