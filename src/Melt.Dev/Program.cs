
namespace Melt.Dev
{
    using Melt.CognitiveServices;
    using Melt.CognitiveServices.Pipeline;
    using Melt.Marshaling;
    using Melt.Marshaling.Extensions;
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
        static void Main(string[] args)
        {
            var c = Marshallers.Common;
            var s = c.Construct().Attach((1,2,3,4));

            Console.WriteLine(s.ToHAString());

            Console.WriteLine(c.Deconstruct(s).Detach<(int a,int b,int c,int d)>());

            Exit();
        }

        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
