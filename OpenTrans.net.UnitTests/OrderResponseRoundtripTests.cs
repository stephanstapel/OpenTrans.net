using System;
using System.IO;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenTrans.net.UnitTests
{
    [TestClass]
    public class OrderResponseRoundtripTests
    {
        [TestMethod]
        public void HeaderIsPreserved()
        {
            OrderResponse original = TestDataFactory.CreateOrderResponse();

            OrderResponse loaded = Roundtrip.Run(original);

            Assert.AreEqual(original.OrderId, loaded.OrderId);
            Assert.AreEqual(original.SupplierOrderId, loaded.SupplierOrderId);
            Assert.AreEqual(original.OrderDate, loaded.OrderDate);
            Assert.AreEqual(original.OrderResponseDate, loaded.OrderResponseDate);
            Assert.AreEqual(original.OrderChangeSequenceId, loaded.OrderChangeSequenceId);
        } // !HeaderIsPreserved()


        [TestMethod]
        public void PartiesArePreserved()
        {
            OrderResponse original = TestDataFactory.CreateOrderResponse();

            OrderResponse loaded = Roundtrip.Run(original);

            Assert.AreEqual(original.Parties.Count, loaded.Parties.Count);
            for (int i = 0; i < original.Parties.Count; i++)
            {
                RoundtripAssert.AreEqual(original.Parties[i], loaded.Parties[i]);
            }
        } // !PartiesArePreserved()


        [TestMethod]
        public void ItemsArePreserved()
        {
            OrderResponse original = TestDataFactory.CreateOrderResponse();

            OrderResponse loaded = Roundtrip.Run(original);

            Assert.AreEqual(original.OrderItems.Count, loaded.OrderItems.Count);
            for (int i = 0; i < original.OrderItems.Count; i++)
            {
                RoundtripAssert.AreEqual(original.OrderItems[i], loaded.OrderItems[i]);
            }
        } // !ItemsArePreserved()


        [TestMethod]
        public void HeaderElementsAreWrittenInSchemaOrder()
        {
            OrderResponse original = TestDataFactory.CreateOrderResponse();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Roundtrip.ToXml(original));
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("o", "http://www.opentrans.org/XMLSchema/2.1");

            XmlNodeList children = doc.SelectNodes("//o:ORDERRESPONSE_INFO/*", nsmgr);
            Assert.AreEqual("ORDER_ID", children[0].LocalName);
            Assert.AreEqual("ORDERRESPONSE_DATE", children[1].LocalName);
            Assert.AreEqual("ORDER_DATE", children[2].LocalName);
            Assert.AreEqual("SUPPLIER_ORDER_ID", children[3].LocalName);
            Assert.AreEqual("ORDERCHANGE_SEQUENCE_ID", children[4].LocalName);
        } // !HeaderElementsAreWrittenInSchemaOrder()


        [TestMethod]
        public void FileRoundtripReleasesFile()
        {
            OrderResponse original = TestDataFactory.CreateOrderResponse();
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xml");

            original.Save(path);
            OrderResponse loaded = OrderResponse.Load(path);

            // fails if the reader keeps the file handle open
            File.Delete(path);
            Assert.AreEqual(original.OrderId, loaded.OrderId);
        } // !FileRoundtripReleasesFile()
    }
}
