
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
            var g = ConverterPool.Global;
            var data = 1;

            Exit();
        }

        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
