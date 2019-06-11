
namespace Melt.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class PrimitiveTypeTest
    {
        private ConverterPool p;
        [TestInitialize]
        public void Init()
        {
            p = new ConverterPool();
        }
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Object()
        {
            var raw = 12345;

            var c = p.Construct();
            byte[] bytes = c.Attach<object>(raw);

            var wrapped = p.Deconstruct(bytes).Detach<object>(out var l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Bool()
        {
            var raw = true;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void SByte()
        {
            var raw = (sbyte)2;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Byte()
        {
            var raw = (byte)3;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Char()
        {
            var raw = '4';

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }
        [TestMethod]
        public void UInt16()
        {
            var raw = (ushort)5;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Int16()
        {
            var raw = (short)-6;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void UInt32()
        {
            var raw = 7u;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Int32()
        {
            var raw = -8;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void UInt64()
        {
            var raw = 9uL;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Int64()
        {
            var raw = -10L;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Single()
        {
            var raw = 11.0;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void Double()
        {
            var raw = -12.0;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }


        [TestMethod]
        public void Decimal()
        {
            var raw = 13m;

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }


        [TestMethod]
        public void String()
        {
            var raw = "Test";

            byte[] bytes = p.Construct().Attach(raw.GetType(), raw);
            var wrapped = p.Deconstruct(bytes).Detach(raw.GetType(), out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

    }
}
