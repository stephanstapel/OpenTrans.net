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
namespace OpenTrans.net
{
    /// <summary>
    /// Types for the product number used by the buying company.
    /// </summary>
    public enum BuyerProductIdTypes
    {
        /// <summary> Artikelnummer des einkaufenden Unternehmens </summary>
        BuyerSpecific,

        /// <summary> Europäische Artikelnummer (14 Zeichen), s. http://www.ean-int.org </summary>
        EAN,

        /// <summary> Global Trade Item Number, s. http://www.uc-council.org/2005sunrise/global_trade_item_number.html </summary>
        GTIN,

        /// <summary> Universal Product Code, s. http://www.ean.de/ean/Inhalt/e2/e8/e335 </summary>
        UPC,

        /// <summary>
        /// Unknown (error) value
        /// </summary>
        Unknown
    }

    internal static class BuyerProductIdTypesExtensions
    {
        public static BuyerProductIdTypes FromString(this BuyerProductIdTypes _, string s)
        {
            s = s.ToLower().Trim();
            switch (s)
            {
                case "buyer_specific": return BuyerProductIdTypes.BuyerSpecific;
                case "ean": return BuyerProductIdTypes.EAN;
                case "gtin": return BuyerProductIdTypes.GTIN;
                case "upc": return BuyerProductIdTypes.UPC;

                default: return BuyerProductIdTypes.Unknown;
            }
        } // !FromString()


        public static string EnumToString(this BuyerProductIdTypes c)
        {
            switch (c)
            {
                case BuyerProductIdTypes.BuyerSpecific: return "buyer_specific";
                case BuyerProductIdTypes.EAN: return "ean";
                case BuyerProductIdTypes.GTIN: return "gtin";
                case BuyerProductIdTypes.UPC: return "upc";

                default: return "";
            }
        } // !ToString()
    }
}

