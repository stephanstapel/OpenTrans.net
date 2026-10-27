using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenTrans.net.UnitTests
{
    /// <summary>
    /// Compares the original object graph with the one that was read back after saving
    /// </summary>
    internal static class RoundtripAssert
    {
        internal static void AreEqual(Party expected, Party actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Ids.Count, actual.Ids.Count, "Party.Ids.Count");
            for (int i = 0; i < expected.Ids.Count; i++)
            {
                AreEqual(expected.Ids[i], actual.Ids[i]);
            }

            CollectionAssert.AreEqual(expected.Roles, actual.Roles, "Party.Roles");
            CollectionAssert.AreEqual(expected.RolesCustom, actual.RolesCustom, "Party.RolesCustom");
            Assert.AreEqual(expected.Name, actual.Name, "Party.Name");
            Assert.AreEqual(expected.Name2, actual.Name2, "Party.Name2");
            Assert.AreEqual(expected.Name3, actual.Name3, "Party.Name3");
            Assert.AreEqual(expected.Department, actual.Department, "Party.Department");
            Assert.AreEqual(expected.Street, actual.Street, "Party.Street");
            Assert.AreEqual(expected.Zip, actual.Zip, "Party.Zip");
            Assert.AreEqual(expected.BoxNo, actual.BoxNo, "Party.BoxNo");
            Assert.AreEqual(expected.ZipBox, actual.ZipBox, "Party.ZipBox");
            Assert.AreEqual(expected.City, actual.City, "Party.City");
            Assert.AreEqual(expected.State, actual.State, "Party.State");
            Assert.AreEqual(expected.CountryCode, actual.CountryCode, "Party.CountryCode");
            Assert.AreEqual(expected.VATId, actual.VATId, "Party.VATId");
            Assert.AreEqual(expected.TaxNumber, actual.TaxNumber, "Party.TaxNumber");
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress, "Party.EmailAddress");
            Assert.AreEqual(expected.Url, actual.Url, "Party.Url");
            AreEqual(expected.PhoneNo, actual.PhoneNo, "Party.PhoneNo");
            AreEqual(expected.FaxNo, actual.FaxNo, "Party.FaxNo");
            AreEqual(expected.ContactDetails, actual.ContactDetails);
        } // !AreEqual()


        internal static void AreEqual(Contact expected, Contact actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual, "Contact");
                return;
            }

            Assert.IsNotNull(actual, "Contact");
            Assert.AreEqual(expected.Id, actual.Id, "Contact.Id");
            Assert.AreEqual(expected.Name, actual.Name, "Contact.Name");
            Assert.AreEqual(expected.FirstName, actual.FirstName, "Contact.FirstName");
            Assert.AreEqual(expected.Title, actual.Title, "Contact.Title");
            Assert.AreEqual(expected.AcademicTitle, actual.AcademicTitle, "Contact.AcademicTitle");
            Assert.AreEqual(expected.Description, actual.Description, "Contact.Description");
            Assert.AreEqual(expected.Url, actual.Url, "Contact.Url");
            Assert.AreEqual(expected.Authentification, actual.Authentification, "Contact.Authentification");
            CollectionAssert.AreEqual(expected.Roles, actual.Roles, "Contact.Roles");
            CollectionAssert.AreEqual(expected.EmailAddresses, actual.EmailAddresses, "Contact.EmailAddresses");
            AreEqual(expected.PhoneNo, actual.PhoneNo, "Contact.PhoneNo");
            AreEqual(expected.FaxNo, actual.FaxNo, "Contact.FaxNo");
        } // !AreEqual()


        internal static void AreEqual(List<PhoneNo> expected, List<PhoneNo> actual, string name)
        {
            Assert.IsNotNull(actual, name);
            Assert.AreEqual(expected.Count, actual.Count, name + ".Count");
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Number, actual[i].Number, name + ".Number");
                Assert.AreEqual(expected[i].Type, actual[i].Type, name + ".Type");
            }
        } // !AreEqual()


        internal static void AreEqual(PartyId expected, PartyId actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual, "PartyId");
                return;
            }

            Assert.IsNotNull(actual, "PartyId");
            Assert.AreEqual(expected.Id, actual.Id, "PartyId.Id");
            Assert.AreEqual(expected.Type, actual.Type, "PartyId.Type");
        } // !AreEqual()


        internal static void AreEqual(DeliveryDate expected, DeliveryDate actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual, "DeliveryDate");
                return;
            }

            Assert.IsNotNull(actual, "DeliveryDate");
            Assert.AreEqual(expected.StartDate, actual.StartDate, "DeliveryDate.StartDate");
            Assert.AreEqual(expected.EndDate, actual.EndDate, "DeliveryDate.EndDate");
            Assert.AreEqual(expected.Type, actual.Type, "DeliveryDate.Type");
        } // !AreEqual()


        internal static void AreEqual(List<Remark> expected, List<Remark> actual)
        {
            Assert.AreEqual(expected.Count, actual.Count, "Remarks.Count");
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Value, actual[i].Value, "Remark.Value");
                Assert.AreEqual(expected[i].Type, actual[i].Type, "Remark.Type");
                Assert.AreEqual(expected[i].Lang, actual[i].Lang, "Remark.Lang");
            }
        } // !AreEqual()


        internal static void AreEqual(OrderItem expected, OrderItem actual)
        {
            Assert.IsNotNull(actual, "OrderItem");
            Assert.AreEqual(expected.LineItemId, actual.LineItemId, "OrderItem.LineItemId");
            Assert.AreEqual(expected.Quantity, actual.Quantity, "OrderItem.Quantity");
            Assert.AreEqual(expected.OrderUnit, actual.OrderUnit, "OrderItem.OrderUnit");
            Assert.AreEqual(expected.LineAmount, actual.LineAmount, "OrderItem.LineAmount");
            AreEqual(expected.ProductId, actual.ProductId);
            AreEqual(expected.ProductPriceFix, actual.ProductPriceFix);
            AreEqual(expected.DeliveryDate, actual.DeliveryDate);
            AreEqual(expected.Remarks, actual.Remarks);

            Assert.AreEqual(expected.ProductFeatures.Count, actual.ProductFeatures.Count, "OrderItem.ProductFeatures.Count");
            for (int i = 0; i < expected.ProductFeatures.Count; i++)
            {
                AreEqual(expected.ProductFeatures[i], actual.ProductFeatures[i]);
            }
        } // !AreEqual()


        internal static void AreEqual(ProductId expected, ProductId actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual, "ProductId");
                return;
            }

            Assert.IsNotNull(actual, "ProductId");
            Assert.AreEqual(expected.SupplierPId?.Id, actual.SupplierPId?.Id, "ProductId.SupplierPId.Id");
            Assert.AreEqual(expected.SupplierPId?.Type, actual.SupplierPId?.Type, "ProductId.SupplierPId.Type");
            AreEqual(expected.SupplierIdRef, actual.SupplierIdRef);
            Assert.AreEqual(expected.BuyerPId?.Id, actual.BuyerPId?.Id, "ProductId.BuyerPId.Id");
            Assert.AreEqual(expected.BuyerPId?.Type, actual.BuyerPId?.Type, "ProductId.BuyerPId.Type");
            Assert.AreEqual(expected.DescriptionShort, actual.DescriptionShort, "ProductId.DescriptionShort");
            Assert.AreEqual(expected.DescriptionLong, actual.DescriptionLong, "ProductId.DescriptionLong");
        } // !AreEqual()


        internal static void AreEqual(ProductPriceFix expected, ProductPriceFix actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual, "ProductPriceFix");
                return;
            }

            Assert.IsNotNull(actual, "ProductPriceFix");
            Assert.AreEqual(expected.PriceAmount, actual.PriceAmount, "ProductPriceFix.PriceAmount");
            Assert.AreEqual(expected.PriceQuantity, actual.PriceQuantity, "ProductPriceFix.PriceQuantity");
            if (expected.PriceBaseFix == null)
            {
                Assert.IsNull(actual.PriceBaseFix, "PriceBaseFix");
                return;
            }

            Assert.IsNotNull(actual.PriceBaseFix, "PriceBaseFix");
            Assert.AreEqual(expected.PriceBaseFix.PriceUnitValue, actual.PriceBaseFix.PriceUnitValue, "PriceBaseFix.PriceUnitValue");
            Assert.AreEqual(expected.PriceBaseFix.PriceUnit, actual.PriceBaseFix.PriceUnit, "PriceBaseFix.PriceUnit");
            Assert.AreEqual(expected.PriceBaseFix.PriceUnitFactor, actual.PriceBaseFix.PriceUnitFactor, "PriceBaseFix.PriceUnitFactor");
        } // !AreEqual()


        internal static void AreEqual(Feature expected, Feature actual)
        {
            Assert.IsNotNull(actual, "Feature");
            Assert.AreEqual(expected.Name, actual.Name, "Feature.Name");
            Assert.AreEqual(expected.Value, actual.Value, "Feature.Value");
            Assert.AreEqual(expected.ValueDetails, actual.ValueDetails, "Feature.ValueDetails");
            Assert.AreEqual(expected.Description, actual.Description, "Feature.Description");
            Assert.AreEqual(expected.Order, actual.Order, "Feature.Order");
            Assert.AreEqual(expected.Unit, actual.Unit, "Feature.Unit");
            Assert.AreEqual(expected.ValueType, actual.ValueType, "Feature.ValueType");
        } // !AreEqual()
    }
}
