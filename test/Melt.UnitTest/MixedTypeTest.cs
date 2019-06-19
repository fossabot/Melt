// Author: Orlys
// Github: https://github.com/Orlys
using Melt.Marshaling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Melt.UnitTest
{
    [TestClass]
    public class MixedTypeTest
    {
        [TestMethod]
        public void Mixed()
        {
            var p = Marshallers.Common;
            var value = "Test-Object";
            var value2 = 5987;
            var value3 = '#';

            byte[] bytes = p.Construct().Attach(value).Attach(value2).Attach(value3);
            var d = p.Deconstruct(bytes);

            Assert.AreEqual(d.Detach<string>(), value);
            Assert.AreEqual(d.Detach<int>(), value2);
            Assert.AreEqual(d.Detach<char>(out var l), value3);

            Assert.AreEqual(l, bytes.Length);
        }
    }
}