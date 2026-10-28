using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenTrans.net.UnitTests
{
    /// <summary>
    /// Makes sure that the written documents comply with the openTRANS 2.1 schema
    /// </summary>
    [TestClass]
    public class SchemaValidationTests
    {
        [TestMethod]
        public void FullOrderIsValid()
        {
            Order order = TestDataFactory.CreateOrder();
            _removeCustomRoles(order.Parties);

            _assertValid(Roundtrip.ToXml(order));
        } // !FullOrderIsValid()


        [TestMethod]
        public void FullOrderResponseIsValid()
        {
            OrderResponse response = TestDataFactory.CreateOrderResponse();
            _removeCustomRoles(response.Parties);

            _assertValid(Roundtrip.ToXml(response));
        } // !FullOrderResponseIsValid()


        [TestMethod]
        public void LegacyAuthentificationIsRead()
        {
            Order order = TestDataFactory.CreateOrder();
            // older versions wrote the value as plain text content
            string xml = System.Text.RegularExpressions.Regex.Replace(Roundtrip.ToXml(order),
                                                                       @"<bmecat:AUTHENTIFICATION>.*?</bmecat:AUTHENTIFICATION>",
                                                                       "<bmecat:AUTHENTIFICATION>max.mustermann</bmecat:AUTHENTIFICATION>",
                                                                       System.Text.RegularExpressions.RegexOptions.Singleline);
            Assert.IsFalse(xml.Contains("<bmecat:LOGIN>"));

            using (System.IO.MemoryStream stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml)))
            {
                Order loaded = Order.Load(stream);

                Assert.AreEqual("max.mustermann", loaded.Parties[0].ContactDetails.Authentification);
            }
        } // !LegacyAuthentificationIsRead()


        [TestMethod]
        public void OrderPartiesReferenceIsDerivedFromParties()
        {
            Order order = TestDataFactory.CreateOrder();
            order.OrderPartiesReference = null;
            _removeCustomRoles(order.Parties);
            OrderResponse response = TestDataFactory.CreateOrderResponse();
            response.OrderPartiesReference = null;
            _removeCustomRoles(response.Parties);

            _assertValid(Roundtrip.ToXml(order));
            _assertValid(Roundtrip.ToXml(response));

            OrderResponse loaded = Roundtrip.Run(response);
            RoundtripAssert.AreEqual(response.Parties[0].Ids[0], loaded.OrderPartiesReference.BuyerIdRef);
            RoundtripAssert.AreEqual(response.Parties[1].Ids[0], loaded.OrderPartiesReference.SupplierIdRef);
        } // !OrderPartiesReferenceIsDerivedFromParties()


        /// <summary>
        /// PARTY_ROLE is an enumeration in the schema, custom roles are supported by the library but are not schema-valid
        /// </summary>
        private static void _removeCustomRoles(List<Party> parties)
        {
            foreach (Party party in parties)
            {
                party.RolesCustom.Clear();
            }
        } // !_removeCustomRoles()


        [TestMethod]
        public void ResavedSampleOrderIsValid()
        {
            Order order = Order.Load(System.IO.Path.Combine(System.AppContext.BaseDirectory, "Samples", "sample_order.xml"));

            _assertValid(Roundtrip.ToXml(order));
        } // !ResavedSampleOrderIsValid()


        private static void _assertValid(string xml)
        {
            List<string> errors = SchemaValidator.Validate(xml);
            Assert.AreEqual(0, errors.Count, string.Join("\n", errors) + "\n\n" + xml);
        } // !_assertValid()
    }
}
