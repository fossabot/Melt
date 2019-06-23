
namespace Melt.Dev
{
    using Melt.Marshaling;
    using Melt.Marshaling.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using BenchmarkDotNet.Attributes;
    public class Bm
    {

        [RankColumn]
        public class ConstructBm
        {
            private IMarshalingProvider marshaller;

            [GlobalSetup]
            public void Setup()
            {
                marshaller = Marshallers.Common;
                character = '#';
                str = "abc";
                array = new object[] { 12, (byte)0xDE, ("Tuple", -78f), 37.0, 10m };
                day = DayOfWeek.Wednesday;
                dict = new Dictionary<Type, object>
                {
                    [typeof(int?)] = 99,
                    [typeof(sbyte)] = new Regex(@"\d+")
                };

                list = new List<(int, int)>
            {
                (1,2),
                (3,4)
            };
            }


            char character;
            string str;
            object[] array;
            DayOfWeek day;
            Dictionary<Type, object> dict;

            List<(int, int)> list;


            [Benchmark]
            public void Contruct()
            {
                var construct = marshaller.Construct()
                    .Attach(character)
                    .Attach(str)
                    .Attach(array)
                    .Attach(day)
                    .Attach(dict)
                    .Attach(list);
            }
        }

        [RankColumn]
        public class DeconstructBm
        {
            private IMarshalingProvider marshaller;
            private byte[] construct;

            [GlobalSetup]
            public void Setup()
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
                    .Attach(list).ToBytes();
            }




            [Benchmark]
            public void Deconstruct()
            {
                var x = marshaller.Deconstruct(construct);
                var a = x.Detach<char>();

                var b = x.Detach<string>();
                var c = x.Detach<object[]>();
                var d = x.Detach<DayOfWeek>();
                var e = x.Detach<Dictionary<Type, object>>();
                var f = x.Detach<List<(int, int)>>();
            }


        }
    }
}