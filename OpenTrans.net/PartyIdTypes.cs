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

namespace OpenTrans.net
{
    public enum PartyIdTypes
    {
        /**
         * Vom Einkäufer vergebene Identifikationsnummer
         */
        BuyerSpecific,

        /**
         * Vom Kunden vergebene Identifikationsnummer
         */
        CustomerSpecific,

        /**
         * DUNS-Kennung (siehe auch http://www.dnbgermany.de/datenbank/dunsnummer.html)
         */
        DUNS,

        /**
         * ILN-Kennung (siehe auch http://www.gs1-germany.de/internet/content/e39/e50/e221/e222/index_ger.html)
         */
        ILN,

        /**
         * In Deutschland auch ILN genannt (siehe ILN)
         */
        GLN,

        /**
         * Von der jeweiligen Organisation selbst definierte Identifikationsnummer
         */
        PartySpecific,

        /**
         * Vom Lieferanten vergebene Identifikationsnummer
         */
        SupplierSpecific,

        /// <summary>
        /// Unknown (error) value
        /// </summary>
        Unknown
    }


    internal static class PartyIdTypesExtensions
    {
        public static PartyIdTypes FromString(this PartyIdTypes _, string s)
        {
            s = s.ToLower().Trim();
            switch (s)
            {
                case "buyer_specific": return PartyIdTypes.BuyerSpecific;
                case "customer_specific": return PartyIdTypes.CustomerSpecific;
                case "duns": return PartyIdTypes.DUNS;
                case "iln": return PartyIdTypes.ILN;
                case "gln": return PartyIdTypes.GLN;
                case "party_specific": return PartyIdTypes.PartySpecific;
                case "supplier_specific": return PartyIdTypes.SupplierSpecific;
                default: return PartyIdTypes.Unknown;
            }
        } // !FromString()


        public static string EnumToString(this PartyIdTypes c)
        {
            switch (c)
            {
                case PartyIdTypes.BuyerSpecific: return "buyer_specific";
                case PartyIdTypes.CustomerSpecific: return "customer_specific";
                case PartyIdTypes.DUNS: return "duns";
                case PartyIdTypes.ILN: return "iln";
                case PartyIdTypes.GLN: return "gln";
                case PartyIdTypes.PartySpecific: return "party_specific";
                case PartyIdTypes.SupplierSpecific: return "supplier_specific";
                default: return "";
            }
        } // !ToString()
    }
}
 
 
 
 
 