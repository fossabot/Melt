using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melt.Dev
{
    class Program
    {
        enum s : long
        {
            a=1,
            b=100
        }

        static void Main(string[] args)
        {
            var q = new ConverterPool();
            var ee = s.b;
            var e = new EnumerationConverter<s>();
            var r = e.ToBytes(ee, q);

            var w = e.FromBytes(r, out var v, q);
            Console.WriteLine(w);

            Console.ReadKey();
        }
    }
}
