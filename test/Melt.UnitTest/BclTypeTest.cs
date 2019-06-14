// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System;
    using System.Net;
    using System.Text;

    [TestClass]
    public class BclTypeTest
    {
        private ConverterPool p;
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Regex()
        {
            var raw = new System.Text.RegularExpressions.Regex("[A-Z][a-z]+");

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<System.Text.RegularExpressions.Regex>(out int l);
            Assert.IsTrue(wrapped.IsMatch("Orlys"));
            Assert.AreEqual(raw.ToString(), wrapped.ToString());
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void IPEndPoint_v4()
        {
            var raw = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 80);

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<IPEndPoint>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void IPEndPoint_v6()
        {
            var raw = new IPEndPoint(IPAddress.Parse("::1"), 443);

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<IPEndPoint>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void IPAddress_v4()
        {
            var raw = IPAddress.Parse("127.0.0.1");

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<IPAddress>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }
        [TestMethod]
        public void IPAddress_v6()
        {
            var raw = IPAddress.Parse("::1");

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<IPAddress>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void DateTime()
        {
            var raw = System.DateTime.Now;

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<DateTime>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }


        [TestMethod]
        public void TimeSpan()
        {
            var raw = System.TimeSpan.FromTicks(System.DateTime.Now.Ticks);
            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<TimeSpan>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Guid()
        {
            var raw = System.Guid.NewGuid();

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<Guid>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestInitialize]
        public void Init()
        {
            p = ConverterPool.Global;
        }

        [TestMethod]
        public void StringBuilder()
        {
            var raw = new StringBuilder();
            raw.AppendLine("Hello");

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<StringBuilder>(out int l);
            Assert.AreEqual(raw.ToString(), wrapped.ToString());
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Uri()
        {
            var raw = new Uri("https://github.com");

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<Uri>(out int l);
            Assert.AreEqual(raw.ToString(), wrapped.ToString());
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }
    }
}