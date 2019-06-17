// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Dev
{

    using Melt.Support;
    using Melt.Utilities;

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    internal class Program
    {

        [STAThread]
        private static void Main(string[] args)
        {

            var strAr = new[] { "ABC", "DE", "F" };
            var ds = new[] { 1, 2, 3, 4 };

            var k = ds.ToConstruct().Attach(strAr);

            Console.WriteLine(k.ToHAString());

            var dd = k.ToDeconstruct();
            var x = dd.Detach<int[]>(out var len);
            foreach (var item in x)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------");
            foreach (var item in dd.Detach<string[]>())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine(len);
            Console.ReadKey();
            return;

            Console.WriteLine("-------");
            foreach (var item in dd.Detach<int[]>())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------");
            Console.ReadKey();
            return;

            var l = 7;

            var bytes = l.ToConstruct();

            Console.WriteLine(bytes.ToHAString());

            Console.WriteLine("------------------------");
            var d = bytes.ToDeconstruct().Detach<int>();
            Console.WriteLine(d);
            Console.WriteLine("------------------------");

            Console.ReadKey();
            return;
            
            Console.ReadKey();
        }

        

        
    }
}


