using System.IO;
using System.Text;

namespace OpenTrans.net.UnitTests
{
    /// <summary>
    /// Saves business documents into memory and loads them again
    /// </summary>
    internal static class Roundtrip
    {
        internal static Order Run(Order order)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                order.Save(stream);
                return Order.Load(stream);
            }
        } // !Run()


        internal static OrderResponse Run(OrderResponse response)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                response.Save(stream);
                return OrderResponse.Load(stream);
            }
        } // !Run()


        internal static string ToXml(Order order)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                order.Save(stream);
                return new StreamReader(stream, Encoding.UTF8).ReadToEnd();
            }
        } // !ToXml()


        internal static string ToXml(OrderResponse response)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                response.Save(stream);
                return new StreamReader(stream, Encoding.UTF8).ReadToEnd();
            }
        } // !ToXml()
    }
}
