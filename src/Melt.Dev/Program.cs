
namespace Melt.Dev
{
    using Melt.CognitiveServices;
    using Melt.CognitiveServices.Pipeline;
    using Melt.Marshaling;
    using Melt.Marshaling.Contracts;
    using Melt.Marshaling.Entity;
    using Melt.Marshaling.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using BenchmarkDotNet;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    public class Bm
    {
        private readonly IMarshalingProvider marshaller;
        private readonly Construct construct;
        public Bm()
        {
            marshaller = Marshallers.Common;


            var character = '#';
            var str = "abc";
            var array = new object[] { 12, (byte)0xDE, ("Tuple", -78f), 37.0, 10m };
            var day = DayOfWeek.Wednesday;
            var dict = new Dictionary<Type, object>
            {
                [typeof(int?)] = 99,
                [typeof(sbyte)] = new Regex(@"\d+")
            };

            var list = new List<(int, int)>
            {
                (1,2),
                (3,4)
            };

            construct = marshaller.Construct()
                .Attach(character)
                .Attach(str)
                .Attach(array)
                .Attach(day)
                .Attach(dict)
                .Attach(list);
        }

        [Benchmark]
        public void Test()
        {
            var x = marshaller.Deconstruct(construct);
            var a = x.Detach<char>();
            /*
            var b = x.Detach<string>();
            var c = x.Detach<object[]>();
            var d = x.Detach<DayOfWeek>();
            var e = x.Detach<Dictionary<Type, object>>();
            var f = x.Detach<List<(int, int)>>();*/
        }
        /*
        [Benchmark]
        public void Test2()
        {
            var x = marshaller.Deconstruct(construct);
            var a = x.Detach<char>();
            var b = x.Detach<string>();
            var c = x.Detach<object[]>();
            var d = x.Detach<DayOfWeek>();
            var e = x.Detach<Dictionary<Type, object>>();
            var f = x.Detach<List<(int, int)>>();
        }*/

    }


    class Program
    {

        static void Main(string[] args)
        {
            var summery = BenchmarkRunner.Run<Bm>();

            Exit();
        }
        
        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
