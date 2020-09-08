
namespace OpenTrans.net
{
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

        Unknown
    }
    public static class BuyerProductIdTypesExtensions
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

