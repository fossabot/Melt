// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.UnitTest
{
    using Melt.Marshaling;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PrimitiveTypeTest
    {
        private IMarshalingProvider p;
        public TestContext TestContext { get; set; }

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

        [TestInitialize]
        public void Init()
        {
            p = Marshallers.Common;
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

        [TestMethod]
        public void String_Empty()
        {
            var raw = "";

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<string>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
            TestContext.WriteLine("Type: {0}", wrapped.GetType());
            TestContext.WriteLine("Length: {0}", l);
        }

        [TestMethod]
        public void String_Null()
        {
            var raw = default(string);

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<string>(out int l);
            Assert.AreEqual(raw, wrapped);
            Assert.IsNull(wrapped);
            Assert.AreEqual(l, bytes.Length);
            TestContext.WriteLine("Value: {0}", wrapped);
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
    }
}