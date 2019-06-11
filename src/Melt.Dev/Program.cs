using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melt.Dev
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new ConverterPool();
            var v = (object)123456;
            var cc = c.Construct();
            var rr = cc.Attach(v);

            Console.WriteLine(rr.ToHAString());

            var resu = c.Deconstruct(rr).Detach<object>();
            Console.WriteLine(resu);


            Console.WriteLine("----");
            Console.ReadKey();
        }
    }
}
