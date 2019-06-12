// Author: Orlys
// Contact: mailto:viyrex.aka.yuyu@gmail.com// Github: https://github.com/Orlys

namespace Melt.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System;
    using System.Text;

    [TestClass]
    public class BclTypeTest
    {
        private ConverterPool p;
        public TestContext TestContext { get; set; }

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
            p = new ConverterPool();
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

    [TestClass]
    public class SpecialTypeTest
    {
        private enum TestEnum
        {
            A = 999,
            B = ~999
        }

        private ConverterPool p;
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Enum()
        {
            p.Register<EnumerationConverter<TestEnum>>();
            var raw = TestEnum.B;

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<TestEnum>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped);
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestInitialize]
        public void Init()
        {
            p = new ConverterPool();
        }

        [TestMethod]
        public void Object()
        {
            object raw = 12345;

            var c = p.Construct();
            byte[] bytes = c.Attach(raw);

            var wrapped = p.Deconstruct(bytes).Detach<object>(out var l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Type()
        {
            var raw = ("").GetType();

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<Type>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped);
            TestContext.WriteLine("Length: {0}", l);
        }
    }
}