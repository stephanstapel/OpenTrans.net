
namespace OpenTrans.net
{
    /// <summary>
    /// This element contains the product number issued by the supplier. It is determining for ordering the product; it identifies the product in the supplier catalog.
    /// </summary>
    public class SupplierProductId
    {
        /// <summary>
        /// The product ID itself
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// This attribute specifies the type of ID, i.e. indicates the organization that has issued the ID.
        /// </summary>
        public SupplierProductIdTypes Type { get; set; }
    }
}
