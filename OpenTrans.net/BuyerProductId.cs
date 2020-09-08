
namespace OpenTrans.net
{
    /// <summary>
    /// Identifier of the product from the perspective of the buyer. The included elements ensure the capability of a unique identification of a product.
    /// </summary>
    public class BuyerProductId
    {
        public string Id { get; set; }
        public BuyerProductIdTypes Type { get; set; }
    }
}
