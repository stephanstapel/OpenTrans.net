# OpenTrans.net

.net library for reading and writing OpenTRANS orders and order responses.

# Installation
You can install it via nuget:

https://www.nuget.org/packages/OpenTrans.net

# Usage
For creating orders, you can simply create Order objects like this:

```csharp
Order order = new Order()
            {
                Id = "MyOrderId",
                OrderDate = new DateTime(2020, 06, 21, 12, 20, 0),
                DesiredDeliveryDateStart = new DateTime(2020, 06, 21, 10, 0, 0),
                DesiredDeliveryDateEnd = new DateTime(2020, 06, 21, 10, 0, 0),
            };
```

with order id being the internal identifier for your order.
You can then add parties to your order object where each party comes with specific roles like Buyer, Manufacturer, Supplier and its address and contact data:

```csharp
order.Parties.Add(new Party(){
  Ids = new List<PartyId>() { new PartyId() { Id = "iln-no", Type = PartyIdTypes.ILN } },
  Roles = { PartyRoles.Buyer },
  Name = ....
});
```

make sure to add the appropriate party ids since the document needs to be used by both buyer and supplier and mapping of the ids needs to be possible on both ends.

Finally, you need to add the order items:

```csharp
order.OrderItems.Add(new OrderItem()
            {
                LineItemId = "1",
                OrderUnit = QuantityCodes.C62,
                ProductId = new ProductId()
                {
                  SupplierPId = "...",
                  DescriptionShort = "..."
                },
                Quantity = 1.0m,
                LineAmount = 10,
                Remarks = new List<string>() { "Please deliver soon" }
            });
```

Again, make sure to use appropriate item ids and id reference to allow mapping on both ends of the comunication.
  
Finally, all you need is to save the order. You can write the order into a stream (open the stream before):
```csharp
Stream s = ...
order.Save(s);
```

or into a file:

```csharp
order.Save("order.xml");
```

The demo application contains some simple examples. Please see here for more details:

https://github.com/stephanstapel/OpenTrans.net/blob/master/OpenTrans.net-Test/Application.cs 

Additional transactions will be added as soon as possible.

# More information
* https://de.wikipedia.org/wiki/OpenTRANS
