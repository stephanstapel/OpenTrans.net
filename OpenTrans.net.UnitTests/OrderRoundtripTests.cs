using System;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenTrans.net.UnitTests
{
    [TestClass]
    public class OrderRoundtripTests
    {
        [TestMethod]
        public void HeaderIsPreserved()
        {
            Order original = TestDataFactory.CreateOrder();

            Order loaded = Roundtrip.Run(original);

            Assert.AreEqual(original.Id, loaded.Id);
            Assert.AreEqual(original.OrderDate, loaded.OrderDate);
            Assert.AreEqual(original.Currency, loaded.Currency);
            RoundtripAssert.AreEqual(original.DeliveryDate, loaded.DeliveryDate);
            RoundtripAssert.AreEqual(original.Remarks, loaded.Remarks);
        } // !HeaderIsPreserved()


        [TestMethod]
        public void GenerationDateIsPreserved()
        {
            Order original = TestDataFactory.CreateOrder();

            Order loaded = Roundtrip.Run(original);

            Assert.AreEqual(original.GenerationDate, loaded.GenerationDate);
        } // !GenerationDateIsPreserved()


        [TestMethod]
        public void GenerationDateDefaultsToNowIfNotSet()
        {
            Order original = TestDataFactory.CreateOrder();
            original.GenerationDate = null;
            DateTime before = DateTime.Now.AddSeconds(-1);

            Order loaded = Roundtrip.Run(original);

            Assert.IsNotNull(loaded.GenerationDate);
            Assert.IsTrue(loaded.GenerationDate >= before);
        } // !GenerationDateDefaultsToNowIfNotSet()


        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void PartialShipmentAllowedIsPreserved(bool value)
        {
            Order original = TestDataFactory.CreateOrder();
            original.PartialShipmentAllowed = value;

            Order loaded = Roundtrip.Run(original);

            Assert.AreEqual(value, loaded.PartialShipmentAllowed);
        } // !PartialShipmentAllowedIsPreserved()


        [TestMethod]
        public void CustomerOrderReferenceIsPreserved()
        {
            Order original = TestDataFactory.CreateOrder();

            Order loaded = Roundtrip.Run(original);

            Assert.IsNotNull(loaded.CustomerOrderReference);
            Assert.AreEqual(original.CustomerOrderReference.OrderId, loaded.CustomerOrderReference.OrderId);
        } // !CustomerOrderReferenceIsPreserved()


        [TestMethod]
        public void OrderPartiesReferenceIsPreserved()
        {
            Order original = TestDataFactory.CreateOrder();

            Order loaded = Roundtrip.Run(original);

            Assert.IsNotNull(loaded.OrderPartiesReference);
            RoundtripAssert.AreEqual(original.OrderPartiesReference.BuyerIdRef, loaded.OrderPartiesReference.BuyerIdRef);
            RoundtripAssert.AreEqual(original.OrderPartiesReference.SupplierIdRef, loaded.OrderPartiesReference.SupplierIdRef);
            Assert.AreEqual(original.OrderPartiesReference.ShipmentPartiesReference.DeliveryIdRef, loaded.OrderPartiesReference.ShipmentPartiesReference.DeliveryIdRef);
        } // !OrderPartiesReferenceIsPreserved()


        [TestMethod]
        public void PartialOrderPartiesReferenceCanBeSaved()
        {
            Order original = TestDataFactory.CreateOrder();
            original.OrderPartiesReference = new OrderPartiesReference()
            {
                BuyerIdRef = new PartyId() { Id = "BUYER-1", Type = PartyIdTypes.BuyerSpecific }
            };

            Order loaded = Roundtrip.Run(original);

            RoundtripAssert.AreEqual(original.OrderPartiesReference.BuyerIdRef, loaded.OrderPartiesReference.BuyerIdRef);
            Assert.IsNull(loaded.OrderPartiesReference.SupplierIdRef);
            Assert.IsNull(loaded.OrderPartiesReference.ShipmentPartiesReference);
        } // !PartialOrderPartiesReferenceCanBeSaved()


        [TestMethod]
        public void OrderSummaryIsPreserved()
        {
            Order original = TestDataFactory.CreateOrder();

            Order loaded = Roundtrip.Run(original);

            Assert.IsNotNull(loaded.OrderSummary);
            Assert.AreEqual(original.OrderSummary.TotalAmount, loaded.OrderSummary.TotalAmount);
        } // !OrderSummaryIsPreserved()


        [TestMethod]
        public void PartiesArePreserved()
        {
            Order original = TestDataFactory.CreateOrder();

            Order loaded = Roundtrip.Run(original);

            Assert.AreEqual(original.Parties.Count, loaded.Parties.Count);
            for (int i = 0; i < original.Parties.Count; i++)
            {
                RoundtripAssert.AreEqual(original.Parties[i], loaded.Parties[i]);
            }
        } // !PartiesArePreserved()


        [TestMethod]
        public void MinimalPartyCanBeSaved()
        {
            Order original = TestDataFactory.CreateOrder();
            original.Parties.Clear();
            original.Parties.Add(new Party()
            {
                Roles = { PartyRoles.Buyer },
                Name = "Minimal",
                ContactDetails = new Contact() { Name = "Contact" }
            });

            Order loaded = Roundtrip.Run(original);

            Assert.AreEqual(1, loaded.Parties.Count);
            Party party = loaded.Parties[0];
            CollectionAssert.AreEqual(original.Parties[0].Roles, party.Roles);
            Assert.AreEqual("Minimal", party.Name);
            Assert.AreEqual("Contact", party.ContactDetails.Name);
            // missing elements are read as empty strings
            Assert.AreEqual("", party.Name2);
            Assert.AreEqual(0, party.Ids.Count);
            Assert.AreEqual(0, party.PhoneNo.Count);
            Assert.AreEqual(0, party.FaxNo.Count);
            Assert.AreEqual(CountryCodes.Unknown, party.CountryCode);
        } // !MinimalPartyCanBeSaved()


        [TestMethod]
        public void ItemsArePreserved()
        {
            Order original = TestDataFactory.CreateOrder();

            Order loaded = Roundtrip.Run(original);

            Assert.AreEqual(original.OrderItems.Count, loaded.OrderItems.Count);
            for (int i = 0; i < original.OrderItems.Count; i++)
            {
                RoundtripAssert.AreEqual(original.OrderItems[i], loaded.OrderItems[i]);
            }
        } // !ItemsArePreserved()


        [TestMethod]
        public void MinimalItemCanBeSaved()
        {
            Order original = TestDataFactory.CreateOrder();
            original.OrderItems.Clear();
            original.OrderItems.Add(new OrderItem() { LineItemId = "1", Quantity = 1m });

            Order loaded = Roundtrip.Run(original);

            Assert.AreEqual(1, loaded.OrderItems.Count);
            RoundtripAssert.AreEqual(original.OrderItems[0], loaded.OrderItems[0]);
        } // !MinimalItemCanBeSaved()


        [TestMethod]
        [DataRow("1.125")]
        [DataRow("0.001")]
        [DataRow("123456.789")]
        public void DecimalPrecisionIsPreserved(string value)
        {
            decimal d = decimal.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
            Order original = TestDataFactory.CreateOrder();
            original.OrderItems[0].Quantity = d;
            original.OrderItems[0].ProductPriceFix.PriceAmount = d;

            Order loaded = Roundtrip.Run(original);

            Assert.AreEqual(d, loaded.OrderItems[0].Quantity);
            Assert.AreEqual(d, loaded.OrderItems[0].ProductPriceFix.PriceAmount);
        } // !DecimalPrecisionIsPreserved()


        [TestMethod]
        public void DecimalsAreWrittenCultureInvariant()
        {
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
                Order original = TestDataFactory.CreateOrder();
                original.OrderItems[0].LineAmount = 1234567.5m;

                Order loaded = Roundtrip.Run(original);

                Assert.AreEqual(1234567.5m, loaded.OrderItems[0].LineAmount);
            }
            finally
            {
                System.Globalization.CultureInfo.CurrentCulture = culture;
            }
        } // !DecimalsAreWrittenCultureInvariant()


        [TestMethod]
        public void WrittenXmlUsesSpecValues()
        {
            Order original = TestDataFactory.CreateOrder();
            original.OrderItems[0].OrderUnit = QuantityCodes.Unknown;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Roundtrip.ToXml(original));
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("o", "http://www.opentrans.org/XMLSchema/2.1");
            nsmgr.AddNamespace("bmecat", "http://www.bmecat.org/bmecat/2005");

            // FVALUE_TYPE must be lower case according to BMEcat 2005
            Assert.AreEqual("range", doc.SelectSingleNode("//bmecat:FVALUE_TYPE", nsmgr)?.InnerText);
            // element names must not contain whitespace
            Assert.IsNotNull(doc.SelectSingleNode("//o:PRODUCT_FEATURES/o:FEATURE", nsmgr));
            Assert.IsNotNull(doc.SelectSingleNode("//o:ORDER_SUMMARY/o:TOTAL_AMOUNT", nsmgr));
            // unknown units must not be written
            Assert.IsNull(doc.SelectSingleNode("//o:ORDER_ITEM[o:LINE_ITEM_ID='1']/bmecat:ORDER_UNIT", nsmgr));
        } // !WrittenXmlUsesSpecValues()


        [TestMethod]
        public void SaveResetsStreamPosition()
        {
            Order original = TestDataFactory.CreateOrder();

            using (MemoryStream stream = new MemoryStream())
            {
                original.Save(stream);

                Assert.AreEqual(0, stream.Position);
                Assert.IsTrue(stream.Length > 0);
            }
        } // !SaveResetsStreamPosition()


        [TestMethod]
        public void FileRoundtripWorks()
        {
            Order original = TestDataFactory.CreateOrder();
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xml");

            try
            {
                original.Save(path);
                Order loaded = Order.Load(path);

                Assert.AreEqual(original.Id, loaded.Id);
                Assert.AreEqual(original.OrderItems.Count, loaded.OrderItems.Count);
            }
            finally
            {
                File.Delete(path);
            }
        } // !FileRoundtripWorks()


        [TestMethod]
        public void LoadingMissingFileThrows()
        {
            Assert.ThrowsException<FileNotFoundException>(() => Order.Load(Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xml")));
        } // !LoadingMissingFileThrows()
    }
}
