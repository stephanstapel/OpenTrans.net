# OpenTrans.net

.net library for reading and writing OpenTRANS orders and order responses.

The library has a sister library (https://github.com/stephanstapel/BMECat.net) which allows managing product catalogues.

# Installation
You can get the library from nuget or from Visual Studio Package Manager under the name OpenTrans.net.

The URL of the package is here:

https://www.nuget.org/packages/OpenTrans.net/

# Usage
## Creating orders
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

## Loading orders
Loading orders looks similar to saving orders. Again, you can use streams:

```csharp
Stream s = ...
Order order = Order.Load(s);
```

and alternatively you can use file names to load orders:

```csharp
Order order = Order.Load("order.xml");
```

## Creating order responses
After the order is received by the supplier, the supplier answers the order by an order response, in order to acknowledge the order.
Most information can be copied from the order object which is simple with this library since the exact same types (Party, OrderItem) are used for Order and OrderResponse.

```csharp
OrderResponse response = new OrderResponse()
{
            Id = "Same id as in the order",
            OrderDate = DateTime(... same date as in the order ...),
            OrderChangeSequenceId = 0           
};
```

Then, add the parties (just like in the order):

```csharp
response.Parties.Add(new Party(){
  ...
});
```

and finally, the order items:

```csharp
response.OrderItems.Add(new OrderItem(){
  ...
});
```


Save the order response works just like saving orders:

```csharp
Stream s = ...
response.Save(s);
```

or into a file:

```csharp
response.Save("order-response.xml");
```

## Loading order responses
As the buyer, you will receive the order response from the supplier. In order to read it, you just use:

```csharp
Stream s = ...
OrderResponse response = OrderResponse.Load(s);
```

and alternatively you can use file names to load the order response:

```csharp
OrderResponse response = OrderResponse.Load("order-respons.xml");
```

The demo application contains some simple examples. Please see here for more details:

https://github.com/stephanstapel/OpenTrans.net/blob/master/OpenTrans.net-Test/Application.cs 

Additional transactions will be added as soon as possible.

# More information
* https://de.wikipedia.org/wiki/OpenTRANS
