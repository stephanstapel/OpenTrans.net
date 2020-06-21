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
         * The business partner is the creator of the document.
         */
        DocumentCreator,

        /**
         * The business partner operatores an IPP application.
         */
        IPPOperator,

        /**
         * The business partner is a manufacturer.
         */
        Manufacturer,

        /**
         * The business partner is a standardization body. 
         */
        StandardizationBody,

        /**
         * The business partner is a supplier. 
         */
        Supplier,
        Unknown
    }

    public static class PartyRolesTypesExtensions
    {
        public static PartyRoles FromString(this PartyRoles _c, string s)
        {
            s = s.ToLower().Trim();
            switch (s)
            {
                case "buyer": return PartyRoles.Buyer;
                case "document_creator": return PartyRoles.DocumentCreator;
                case "ipp_operator": return PartyRoles.IPPOperator;
                case "manufacturer": return PartyRoles.Manufacturer;
                case "standardization_body": return PartyRoles.StandardizationBody;
                case "supplier": return PartyRoles.Supplier;
                default: return PartyRoles.Unknown;
            }
        } // !FromString()


        public static string EnumToString(this PartyRoles c)
        {
            switch (c)
            {
                case PartyRoles.Buyer: return "buyer";
                case PartyRoles.DocumentCreator: return "document_creator";
                case PartyRoles.IPPOperator: return "ipp_operator";
                case PartyRoles.Manufacturer: return "manufacturer";
                case PartyRoles.StandardizationBody: return "standardization_body";
                case PartyRoles.Supplier: return "";
                default: return "";
            }
        } // !ToString()
    }
}
