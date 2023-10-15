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
    /**
     * @todo add missing attribute: Phone, Fax (typed), page 62 of spec
     */

    /// <summary>
    /// This element contains informations about a contact person.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Unique ID of the contact person
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Last name of the contact
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// First name of the contact person
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Form of address, e.g., Mr., Ms.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Academic title of the contact person, e.g., Dr
        /// </summary>
        public string AcademicTitle { get; set; }

        /// <summary>
        /// Roles or positions of a contact
        /// </summary>
        public List<string> Roles { get; set; } = new List<string>();

        /// <summary>
        /// Additional information on the contact person
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// URL of the web site
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Phone numbers - contents of CONTACT_DETAILS/PHONE element
        /// </summary>
        public List<Phone> PhoneNo { get; set; } = new List<Phone>();

        /// <summary>
        /// Fax numbers - contents of CONTACT_DETAILS/FAX element
        /// </summary>
        public List<Phone> FaxNo { get; set; }

        /// <summary>
        /// List of e-mail addresses
        /// </summary>
        public List<string> EmailAddresses { get; set; } = new List<string>();

        /// <summary>
        /// Authentification information
        /// </summary>
        public string Authentification { get; set; }
    }
}