// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.UnitTest
{
    using Melt.Marshaling;
    using Melt.Marshaling.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System;

    [TestClass]
    public class SpecialTypeTest
    {
        private enum TestEnum
        {
            A = 999,
            B = ~999
        }

        private IMarshalingProvider p;
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void Enum()
        {
#pragma warning disable 0618
            p.Install<EnumerationMarshaller<TestEnum>>();
#pragma warning restore 0618
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
            p =  Marshallers.Common;
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