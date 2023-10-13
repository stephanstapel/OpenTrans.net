# OpenTrans.net
[![NuGet](https://img.shields.io/nuget/v/OpenTrans.net?color=blue)](https://www.nuget.org/packages/OpenTrans.net/)

OpenTrans is an XML-based format that is used for electronic data exchange in the logistics industry. It defines a set of standardized XML schemas that can be used for exchanging information about orders, order responses, and other logistics-related information between different software systems.

To make it easier to work with OpenTrans data in C#, you can use the OpenTrans.net library, which provides classes and methods for reading and writing OpenTrans documents. This library can parse OpenTrans XML documents into C# objects and vice versa, allowing you to easily manipulate and process the data.

One of the most important types of OpenTrans documents are orders and order responses. An order document contains information about a customer's order, including details such as the order ID, customer information, shipping address, and the products being ordered. An order response document contains information about the status of the order, such as whether it has been accepted or rejected by the supplier.

OpenTrans.net supports the latest version of the OpenTrans standard. Additionally, if you need to work with the related BMECat standard for catalog data exchange, you can also use the BMECat.net library (https://github.com/stephanstapel/BMECat.net), which provides similar functionality for reading and writing BMECat documents.


# Installation
You can get the library from nuget or from Visual Studio Package Manager under the name OpenTrans.net.

The URL of the package is here:

[![NuGet](https://img.shields.io/nuget/v/OpenTrans.net?color=blue)](https://www.nuget.org/packages/OpenTrans.net/)

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
OrderResponse response = OrderResponse.Load("order-response.xml");
```

The demo application contains some simple examples. Please see here for more details:

https://github.com/stephanstapel/OpenTrans.net/blob/master/OpenTrans.net-Test/Application.cs 

## Dispatch Notification, Receipt Acknowledgement
The other message types will be implemented when someone should require it.

# More information
* https://www.opentrans.de/
* https://de.wikipedia.org/wiki/OpenTRANS
