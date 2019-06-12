using System;
using Melt.Utilities;
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
            var s = "";// default(string);
            var p = new ConverterPool();
            var b = p.Construct().Attach(s);
            Console.WriteLine(b.ToHAString());
            var k = p.Deconstruct(b).Detach<string>();
            Console.WriteLine(k == "");
            Console.ReadKey();
        }
    }
}
