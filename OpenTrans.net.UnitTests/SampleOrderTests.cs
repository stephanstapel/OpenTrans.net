using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenTrans.net.UnitTests
{
    /// <summary>
    /// Reads the official openTRANS 2.1 sample order
    /// </summary>
    [TestClass]
    public class SampleOrderTests
    {
        private static readonly string SamplePath = Path.Combine(AppContext.BaseDirectory, "Samples", "sample_order.xml");


        [TestMethod]
        public void HeaderIsRead()
        {
            Order order = Order.Load(SamplePath);

            Assert.AreEqual("OID1", order.Id);
            Assert.AreEqual("EUR", order.Currency);
            Assert.AreEqual(true, order.PartialShipmentAllowed);
            Assert.AreEqual("a", order.CustomerOrderReference?.OrderId);
            Assert.AreEqual(new DateTimeOffset(2009, 05, 13, 06, 20, 00, TimeSpan.FromHours(1)).LocalDateTime, order.OrderDate);
            Assert.AreEqual(1, order.Remarks.Count);
            Assert.AreEqual("customType", order.Remarks[0].Type);
        } // !HeaderIsRead()


        [TestMethod]
        public void OrderPartiesReferenceIsRead()
        {
            Order order = Order.Load(SamplePath);

            Assert.AreEqual(PartyIdTypes.BuyerSpecific, order.OrderPartiesReference.BuyerIdRef.Type);
            Assert.AreEqual(PartyIdTypes.DUNS, order.OrderPartiesReference.SupplierIdRef.Type);
            Assert.AreEqual("aaa (this ID should be defined in parties)", order.OrderPartiesReference.ShipmentPartiesReference.DeliveryIdRef);
        } // !OrderPartiesReferenceIsRead()


        [TestMethod]
        public void PartyIsRead()
        {
            Order order = Order.Load(SamplePath);

            Party buyer = order.Parties.Single();
            CollectionAssert.AreEqual(new[] { PartyRoles.Buyer }, buyer.Roles);
            Assert.AreEqual(CountryCodes.DE, buyer.CountryCode);
            Assert.AreEqual("general-mail", buyer.EmailAddress);
            Assert.AreEqual(PhoneNoTypes.Office, buyer.PhoneNo.Single().Type);
            Assert.AreEqual(2, buyer.ContactDetails.EmailAddresses.Count);
            CollectionAssert.AreEqual(new[] { "a" }, buyer.ContactDetails.Roles);
            Assert.AreEqual("a", buyer.ContactDetails.Authentification);
            Assert.AreEqual("use encryption", buyer.ContactDetails.AuthentificationPassword);
        } // !PartyIsRead()


        [TestMethod]
        public void ItemIsRead()
        {
            Order order = Order.Load(SamplePath);

            OrderItem item = order.OrderItems.Single();
            Assert.AreEqual("1", item.LineItemId);
            Assert.AreEqual(1.0m, item.Quantity);
            Assert.AreEqual("a", item.ProductId.SupplierPId.Id);
            Assert.AreEqual("a", item.ProductId.BuyerPId?.Id);
            Assert.AreEqual(ValueTypes.Choice, item.ProductFeatures.Single().ValueType);
            Assert.AreEqual("0", item.ProductFeatures.Single().Order);
        } // !ItemIsRead()


        [TestMethod]
        public void SampleCanBeSavedAgain()
        {
            Order order = Order.Load(SamplePath);

            Order loaded = Roundtrip.Run(order);

            Assert.AreEqual(order.Id, loaded.Id);
            RoundtripAssert.AreEqual(order.Parties[0], loaded.Parties[0]);
            RoundtripAssert.AreEqual(order.OrderItems[0], loaded.OrderItems[0]);
        } // !SampleCanBeSavedAgain()
    }
}
