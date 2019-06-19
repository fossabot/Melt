
namespace Melt.Dev
{
    using Melt;
    using Melt.CognitiveServices;
    using Melt.CognitiveServices.Pipeline;
    using Melt.Extensions;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    class Program
    {
        [MarshalPipeline(typeof(GZipPipeline))]
        public class Test : Cognitive<Test>
        {
            public Test()
            {

            }

            public string Name { get; set; }

            protected override IEnumerable<Expression<MemberSelector>> GetFlowControl()
            {
                yield return x => Name;
            }
        }


        static void Main(string[] args)
        {

            var t = new Test() { Name = "Yuyu" };
            byte[] cc = t.ToConstruct();
            Console.WriteLine(cc.Length);


            Exit();
        }

        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
