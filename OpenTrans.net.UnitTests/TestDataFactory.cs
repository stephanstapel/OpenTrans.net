using System;
using System.Collections.Generic;

namespace OpenTrans.net.UnitTests
{
    /// <summary>
    /// Creates fully populated business objects so that roundtrip tests cover as many properties as possible
    /// </summary>
    internal static class TestDataFactory
    {
        internal static Order CreateOrder()
        {
            Order order = new Order()
            {
                Id = "ORDER-4711",
                GenerationDate = new DateTime(2024, 03, 15, 08, 00, 00),
                OrderDate = new DateTime(2024, 03, 15, 10, 30, 00),
                Currency = "EUR",
                PartialShipmentAllowed = true,
                DeliveryDate = new DeliveryDate()
                {
                    StartDate = new DateTime(2024, 03, 20, 08, 00, 00),
                    EndDate = new DateTime(2024, 03, 22, 17, 00, 00),
                    Type = DeliveryDateTypes.FixedDeliveryDate
                },
                CustomerOrderReference = new CustomerOrderReference() { OrderId = "CUSTOMER-ORDER-1" },
                OrderPartiesReference = new OrderPartiesReference()
                {
                    BuyerIdRef = new PartyId() { Id = "BUYER-1", Type = PartyIdTypes.BuyerSpecific },
                    SupplierIdRef = new PartyId() { Id = "SUPPLIER-1", Type = PartyIdTypes.SupplierSpecific },
                    ShipmentPartiesReference = new ShipmentPartiesReference() { DeliveryIdRef = "DELIVERY-1" }
                },
                OrderSummary = new OrderSummary() { TotalAmount = 1234.56m },
                Remarks = new List<Remark>()
                {
                    new Remark() { Value = "Please deliver to gate 3", Type = "delivery", Lang = "eng" },
                    new Remark() { Value = "Bitte vorher anrufen", Type = "general", Lang = "deu" }
                }
            };

            order.Parties.Add(CreateParty("BUYER-1", PartyIdTypes.BuyerSpecific, PartyRoles.Buyer));
            order.Parties.Add(CreateParty("SUPPLIER-1", PartyIdTypes.SupplierSpecific, PartyRoles.Supplier));
            order.OrderItems.Add(CreateOrderItem("1"));
            order.OrderItems.Add(CreateOrderItem("2"));

            return order;
        } // !CreateOrder()


        internal static OrderResponse CreateOrderResponse()
        {
            OrderResponse response = new OrderResponse()
            {
                OrderId = "ORDER-4711",
                SupplierOrderId = "SUPPLIER-ORDER-0815",
                OrderDate = new DateTime(2024, 03, 15, 10, 30, 00),
                OrderResponseDate = new DateTime(2024, 03, 16, 09, 15, 00),
                OrderChangeSequenceId = 2
            };

            response.Parties.Add(CreateParty("BUYER-1", PartyIdTypes.BuyerSpecific, PartyRoles.Buyer));
            response.Parties.Add(CreateParty("SUPPLIER-1", PartyIdTypes.SupplierSpecific, PartyRoles.Supplier));
            response.OrderItems.Add(CreateOrderItem("1"));
            response.OrderItems.Add(CreateOrderItem("2"));

            return response;
        } // !CreateOrderResponse()


        internal static Party CreateParty(string id, PartyIdTypes idType, PartyRoles role)
        {
            return new Party()
            {
                Ids = new List<PartyId>()
                {
                    new PartyId() { Id = id, Type = idType },
                    new PartyId() { Id = "4012345000009", Type = PartyIdTypes.GLN }
                },
                Roles = new List<PartyRoles>() { role, PartyRoles.InvoiceRecipient },
                RolesCustom = new List<string>() { "my_custom_role" },
                Name = "Muster GmbH",
                Name2 = "Abteilung Einkauf",
                Name3 = "Gebäude 3",
                Department = "Purchasing",
                Street = "Musterstraße 1",
                Zip = "76131",
                BoxNo = "1234",
                ZipBox = "76132",
                City = "Karlsruhe",
                State = "Baden-Württemberg",
                CountryCode = CountryCodes.DE,
                VATId = "DE123456789",
                TaxNumber = "35/123/45678",
                PhoneNo = new List<PhoneNo>()
                {
                    new PhoneNo() { Number = "+49 721 123456", Type = PhoneNoTypes.Office },
                    new PhoneNo() { Number = "+49 171 123456", Type = PhoneNoTypes.Mobile }
                },
                FaxNo = new List<PhoneNo>()
                {
                    new PhoneNo() { Number = "+49 721 123457", Type = PhoneNoTypes.Unknown }
                },
                EmailAddress = "info@muster.de",
                Url = "https://www.muster.de",
                ContactDetails = new Contact()
                {
                    Id = "CONTACT-1",
                    Name = "Mustermann",
                    FirstName = "Max",
                    Title = "Herr",
                    AcademicTitle = "Dr.",
                    Roles = new List<string>() { "Einkäufer" },
                    Description = "Ansprechpartner für Bestellungen",
                    Url = "https://www.muster.de/max",
                    PhoneNo = new List<PhoneNo>() { new PhoneNo() { Number = "+49 721 999", Type = PhoneNoTypes.Private } },
                    FaxNo = new List<PhoneNo>() { new PhoneNo() { Number = "+49 721 998", Type = PhoneNoTypes.Office } },
                    EmailAddresses = new List<string>() { "max@muster.de", "einkauf@muster.de" }
                }
            };
        } // !CreateParty()


        internal static OrderItem CreateOrderItem(string lineItemId)
        {
            return new OrderItem()
            {
                LineItemId = lineItemId,
                ProductId = new ProductId()
                {
                    SupplierPId = new SupplierProductId() { Id = "SUP-PID-" + lineItemId, Type = SupplierProductIdTypes.SupplierSpecific },
                    SupplierIdRef = new PartyId() { Id = "SUPPLIER-1", Type = PartyIdTypes.SupplierSpecific },
                    BuyerPId = new BuyerProductId() { Id = "BUY-PID-" + lineItemId, Type = BuyerProductIdTypes.BuyerSpecific },
                    DescriptionShort = "Schraube M8",
                    DescriptionLong = "Sechskantschraube M8x40, verzinkt <DIN 933> & \"Qualität\""
                },
                Quantity = 12.5m,
                OrderUnit = QuantityCodes.C62,
                LineAmount = 37.5m,
                ProductPriceFix = new ProductPriceFix()
                {
                    PriceAmount = 3.0m,
                    PriceQuantity = 1m,
                    PriceBaseFix = new PriceBaseFix()
                    {
                        PriceUnitValue = 100m,
                        PriceUnit = QuantityCodes.C62,
                        PriceUnitFactor = 1m
                    }
                },
                DeliveryDate = new DeliveryDate()
                {
                    StartDate = new DateTime(2024, 03, 21, 08, 00, 00),
                    EndDate = new DateTime(2024, 03, 21, 12, 00, 00),
                    Type = DeliveryDateTypes.RequiredDate
                },
                Remarks = new List<Remark>()
                {
                    new Remark() { Value = "Position " + lineItemId, Type = "item", Lang = "deu" }
                },
                ProductFeatures = new List<Feature>()
                {
                    new Feature()
                    {
                        Name = "Länge",
                        Value = "40",
                        ValueDetails = "Gesamtlänge",
                        Description = "Länge der Schraube",
                        Order = "1",
                        Unit = QuantityCodes.MMT,
                        ValueType = ValueTypes.Range
                    }
                }
            };
        } // !CreateOrderItem()
    }
}
