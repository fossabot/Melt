
namespace Melt.Dev
{
    using Melt.CognitiveServices;
    using Melt.CognitiveServices.Pipeline;
    using Melt.Marshaling;
    using Melt.Marshaling.Contracts;

    using Melt.Marshaling.Extensions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    class Program
    {

        static void Main(string[] args)
        {
            int? a = null;
            
            var c = Marshallers.Common;

            var s = c.Construct().Attach(a);

            Console.WriteLine(s.ToHAString());

            var d = c.Deconstruct(s);
            var dat = d.Detach<int?>(out var n);

            Console.WriteLine("has v: "+dat.HasValue);
            Console.WriteLine("value: "+dat);
            Console.WriteLine("Len:   "+n);

            Exit();
        }


        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
