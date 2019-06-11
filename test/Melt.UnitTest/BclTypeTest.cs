
namespace Melt.UnitTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections;
    using System.Diagnostics;

    [TestClass]
    public class BclTypeTest
    {

        private ConverterPool p;
        [TestInitialize]
        public void Init()
        {
            p = new ConverterPool();
        }
        public TestContext TestContext { get; set; }


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
    }
}
