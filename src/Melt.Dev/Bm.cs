
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
        private readonly IMarshalingProvider marshaller;
        private  Construct construct;
        public Bm()
        {
            marshaller = Marshallers.Common;

        }

        char character = '#';
        string str = "abc";
        object[] array = new object[] { 12, (byte)0xDE, ("Tuple", -78f), 37.0, 10m };
        DayOfWeek day = DayOfWeek.Wednesday;
        Dictionary<Type,object> dict = new Dictionary<Type, object>
        {
            [typeof(int?)] = 99,
            [typeof(sbyte)] = new Regex(@"\d+")
        };

        List<(int,int)> list = new List<(int, int)>
            {
                (1,2),
                (3,4)
            };



        [Benchmark]
        public void Contruct()
        {
            construct = marshaller.Construct()
                .Attach(character)
                .Attach(str)
                .Attach(array)
                .Attach(day)
                .Attach(dict)
                .Attach(list);
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
