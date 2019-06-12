// Author: Orlys
// Contact: mailto:viyrex.aka.yuyu@gmail.com// Github: https://github.com/Orlys
using Melt.Utilities;

using System;

namespace Melt.Dev
{
    internal class Program
    {
        private enum s : long
        {
            a = 1,
            b = 100
        }

        private static void Main(string[] args)
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