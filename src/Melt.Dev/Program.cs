
namespace Melt.Dev
{
    using Melt;
    using Melt.Extensions;
    using Melt.Internal;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            var kk = (1, 2, 3 ,4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,15);
            var gg = (100, 101, 102);

            kk.ToConstruct()
                .Attach(gg)
                .ToDeconstruct()
                .Detach(out (int, int, int, int, int, int, int, int, int, int, int, int, int, int, int) vv)
                .Detach(out (int a, int b, int c) ss);

            var a = new { name = "" };

            Console.WriteLine(vv);
            Console.WriteLine(ss.a);

            Exit();
        }

        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
