using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenTrans.net.UnitTests
{
    [TestClass]
    public class AsyncApiTests
    {
        [TestMethod]
        public async Task OrderStreamRoundtripWorks()
        {
            Order original = TestDataFactory.CreateOrder();

            using (MemoryStream stream = new MemoryStream())
            {
                await original.SaveAsync(stream);
                Order loaded = await Order.LoadAsync(stream);

                Assert.AreEqual(original.Id, loaded.Id);
                Assert.AreEqual(original.GenerationDate, loaded.GenerationDate);
                RoundtripAssert.AreEqual(original.Parties[0], loaded.Parties[0]);
                RoundtripAssert.AreEqual(original.OrderItems[0], loaded.OrderItems[0]);
            }
        } // !OrderStreamRoundtripWorks()


        [TestMethod]
        public async Task AsyncSaveWritesSameDocumentAsSyncSave()
        {
            Order original = TestDataFactory.CreateOrder();

            using (MemoryStream syncStream = new MemoryStream())
            using (MemoryStream asyncStream = new MemoryStream())
            {
                original.Save(syncStream, "generator");
                await original.SaveAsync(asyncStream, "generator");

                CollectionAssert.AreEqual(syncStream.ToArray(), asyncStream.ToArray());
            }
        } // !AsyncSaveWritesSameDocumentAsSyncSave()


        [TestMethod]
        public async Task OrderResponseStreamRoundtripWorks()
        {
            OrderResponse original = TestDataFactory.CreateOrderResponse();

            using (MemoryStream stream = new MemoryStream())
            {
                await original.SaveAsync(stream);
                OrderResponse loaded = await OrderResponse.LoadAsync(stream);

                Assert.AreEqual(original.OrderId, loaded.OrderId);
                Assert.AreEqual(original.Currency, loaded.Currency);
                RoundtripAssert.AreEqual(original.Parties[0], loaded.Parties[0]);
                RoundtripAssert.AreEqual(original.OrderItems[0], loaded.OrderItems[0]);
            }
        } // !OrderResponseStreamRoundtripWorks()


        [TestMethod]
        public async Task OrderFileRoundtripReleasesFile()
        {
            Order original = TestDataFactory.CreateOrder();
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xml");

            await original.SaveAsync(path, "generator");
            Order loaded = await Order.LoadAsync(path);

            // fails if a file handle is kept open
            File.Delete(path);
            Assert.AreEqual(original.Id, loaded.Id);
        } // !OrderFileRoundtripReleasesFile()


        [TestMethod]
        public async Task OrderResponseFileRoundtripReleasesFile()
        {
            OrderResponse original = TestDataFactory.CreateOrderResponse();
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xml");

            await original.SaveAsync(path);
            OrderResponse loaded = await OrderResponse.LoadAsync(path);

            // fails if a file handle is kept open
            File.Delete(path);
            Assert.AreEqual(original.OrderId, loaded.OrderId);
        } // !OrderResponseFileRoundtripReleasesFile()


        [TestMethod]
        public async Task SaveAsyncResetsStreamToOriginalPosition()
        {
            Order original = TestDataFactory.CreateOrder();

            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(new byte[] { 1, 2, 3 }, 0, 3);

                await original.SaveAsync(stream);

                Assert.AreEqual(3, stream.Position);
                Assert.IsTrue(stream.Length > 3);
            }
        } // !SaveAsyncResetsStreamToOriginalPosition()


        [TestMethod]
        public async Task LoadAsyncSupportsNonSeekableStreams()
        {
            Order original = TestDataFactory.CreateOrder();
            byte[] data;
            using (MemoryStream stream = new MemoryStream())
            {
                original.Save(stream);
                data = stream.ToArray();
            }

            using (NonSeekableStream stream = new NonSeekableStream(data))
            {
                Order loaded = await Order.LoadAsync(stream);

                Assert.AreEqual(original.Id, loaded.Id);
            }
        } // !LoadAsyncSupportsNonSeekableStreams()


        [TestMethod]
        public async Task SaveAsyncRejectsNonSeekableStreams()
        {
            Order original = TestDataFactory.CreateOrder();

            using (NonSeekableStream stream = new NonSeekableStream(new byte[0]))
            {
                await Assert.ThrowsExceptionAsync<IllegalStreamException>(() => original.SaveAsync(stream));
            }
        } // !SaveAsyncRejectsNonSeekableStreams()


        [TestMethod]
        public async Task LoadAsyncThrowsForMissingFile()
        {
            string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".xml");

            await Assert.ThrowsExceptionAsync<FileNotFoundException>(() => Order.LoadAsync(path));
            await Assert.ThrowsExceptionAsync<FileNotFoundException>(() => OrderResponse.LoadAsync(path));
        } // !LoadAsyncThrowsForMissingFile()


        [TestMethod]
        public async Task CancellationIsHonored()
        {
            Order original = TestDataFactory.CreateOrder();
            using (CancellationTokenSource cts = new CancellationTokenSource())
            using (MemoryStream stream = new MemoryStream())
            {
                cts.Cancel();

                await _assertCancelledAsync(() => original.SaveAsync(stream, null, cts.Token));
                Assert.AreEqual(0, stream.Length);

                original.Save(stream);
                await _assertCancelledAsync(() => Order.LoadAsync(stream, cts.Token));
            }
        } // !CancellationIsHonored()


        private static async Task _assertCancelledAsync(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (OperationCanceledException)
            {
                return;
            }

            Assert.Fail("OperationCanceledException expected");
        } // !_assertCancelledAsync()
    }
}
