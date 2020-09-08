using System;
using System.Collections.Generic;
using System.Text;

namespace OpenTrans.net
{
    public enum SupplierProductIdTypes
    {
        /// <summary> Artikelnummer des einkaufenden Unternehmen </summary>
        BuyerSpecific,

        /// <summary> Europäische Artikelnummer (14 Zeichen), s. http://www.ean-int.org </summary>
        EAN,

        /// <summary> Global Trade Item Number, s. http://www.uc-council.org/2005sunrise/global_trade_item_number.html </summary>
        GTIN,

        /// <summary> Artikelnummer des Lieferanten </summary>
        SupplierSpecific,

        /// <summary> Universal Product Code, s. http://www.ean.de/ean/Inhalt/e2/e8/e335</summary>
        UPC,

        Unknown
    }
    public static class SupplierProductIdTypesExtensions
    {
        public static SupplierProductIdTypes FromString(this SupplierProductIdTypes _, string s)
        {
            s = s.ToLower().Trim();
            switch (s)
            {
                case "buyer_specific": return SupplierProductIdTypes.BuyerSpecific;
                case "ean": return SupplierProductIdTypes.EAN;
                case "gtin": return SupplierProductIdTypes.GTIN;
                case "supplier_specific": return SupplierProductIdTypes.SupplierSpecific;
                case "upc": return SupplierProductIdTypes.UPC;

                default: return SupplierProductIdTypes.Unknown;
            }
        } // !FromString()


        public static string EnumToString(this SupplierProductIdTypes c)
        {
            switch (c)
            {
                case SupplierProductIdTypes.BuyerSpecific: return "buyer_specific";
                case SupplierProductIdTypes.EAN: return "ean";
                case SupplierProductIdTypes.GTIN: return "gtin";
                case SupplierProductIdTypes.SupplierSpecific: return "supplier_specific";
                case SupplierProductIdTypes.UPC: return "upc";

                default: return "";
            }
        } // !ToString()
    }
}

