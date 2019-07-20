
namespace Melt.UnitTest.Onion
{
    using Melt.Marshaling;
    using Melt.Onion;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;
    using FluentAssertions;
    [TestClass]
    public class InheritedTest
    {
        IMarshalingProvider p;

        [TestInitialize]
        public void Init()
        {
            p = Marshallers.Common;
        }

        [TestMethod]
        public void SimpleTest()
        {
            var raw = new Test { Data1 = 123456, Data2 = "Test-String" };
            byte[] c = p.Construct().Attach(raw);

            var wrapped = p.Deconstruct(c).Detach<Test>(out var len);

            raw.Should().BeEquivalentTo(wrapped);
            c.Length.Should().Be(len);
        }
    }

    public class Test : OnionBase<Test>
    {
        public int Data1 { get; set; }
        public string Data2 { get; set; }

        protected override IEnumerable<Expression<MemberSelector>> GetFlowControl()
        {
            yield return _ => Data1;
            yield return _ => Data2;
        }
    }
}
