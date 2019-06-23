
namespace Melt.Dev
{
    using BenchmarkDotNet.Running;
    using Melt.Marshaling;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    class Program
    {

        static void Main(string[] args)
        {
            var r = default(BenchmarkDotNet.Reports.Summary);
            r = BenchmarkRunner.Run<Bm.ConstructBm>();
            //Console.ReadKey();
            r = BenchmarkRunner.Run<Bm.DeconstructBm>();

            Exit();
        }
        
        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
