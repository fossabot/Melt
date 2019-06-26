
namespace Melt.Dev
{
    using BenchmarkDotNet.Running;
    using Melt.Marshaling;
    using Melt.Marshaling.Contracts;
    using Microsoft.CSharp.RuntimeBinder;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Dynamic;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            Exit();

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
