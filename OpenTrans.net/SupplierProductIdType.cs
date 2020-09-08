using System;
using System.Collections.Generic;
using System.Text;

namespace OpenTrans.net
{
    public enum SupplierProductIdType
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
    public static class SupplierProductIdTypeExtensions
    {
        public static SupplierProductIdType FromString(this SupplierProductIdType _c, string s)
        {
            s = s.ToLower().Trim();
            switch (s)
            {
                case "buyer_specific": return SupplierProductIdType.BuyerSpecific;
                case "ean": return SupplierProductIdType.EAN;
                case "gtin": return SupplierProductIdType.GTIN;
                case "supplier_specific": return SupplierProductIdType.SupplierSpecific;
                case "upc": return SupplierProductIdType.UPC;

                default: return SupplierProductIdType.Unknown;
            }
        } // !FromString()


        public static string EnumToString(this SupplierProductIdType c)
        {
            switch (c)
            {
                case SupplierProductIdType.BuyerSpecific: return "buyer_specific";
                case SupplierProductIdType.EAN: return "ean";
                case SupplierProductIdType.GTIN: return "gtin";
                case SupplierProductIdType.SupplierSpecific: return "supplier_specific";
                case SupplierProductIdType.UPC: return "upc";

                default: return "";
            }
        } // !ToString()
    }
}

