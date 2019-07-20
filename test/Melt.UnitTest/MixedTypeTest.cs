// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.UnitTest
{
    using Melt.Marshaling;
    using Melt.Marshaling.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FluentAssertions;
    

    [TestClass]
    public class MixedTypeTest
    {
        private IMarshalingProvider p;

        [TestInitialize]
        public void Init()
        {
            p = Marshallers.Common;
            p.Install<TestMarshaller>();
        }

        [TestMethod]
        public void CustomizeTypeTest()
        {
            var raw = new Test { Data1 = 123456, Data2 = "Test-String" };
            byte[] c = p.Construct().Attach(raw);

            var wrapped = p.Deconstruct(c).Detach<Test>(out var len);

            raw.Should().BeEquivalentTo(wrapped);
            c.Length.Should().Be(len);
        }
    }
    
    public class Test
    {
        public int Data1 { get; set; }
        public string Data2 { get; set; }
    }

    class TestMarshaller : ReferenceTypeMarshaller<Test>
    {
        protected override Test OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            var d = pool.Deconstruct(bytes);
            var obj = new Test();
            obj.Data1 = d.Detach<int>();
            obj.Data2 = d.Detach<string>(out length);
            return obj;
        }
        protected override byte[] OnConvertToBytes(Test graph, IMarshalingProvider pool)
        {
            return pool.Construct().Attach(graph.Data1).Attach(graph.Data2);
        }
    }
}