// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Dev
{
    using Melt.Support;
    using Melt.Utilities;

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    
    public static class ConstructExtension
    {
        private static ConverterPool s_pool;
        public static ConverterPool Default
        {
            get
            {
                if (s_pool == null)
                    return ConverterPool.Global;
                return s_pool;
            }
            set
            {
                s_pool = value;
            }
        }

        public static Construct ToConstruct<T>(this T obj)
        {
            return Default.Construct().Attach(obj);
        }

        public static Deconstruct ToDeconstruct(this Construct construct)
        {
            return Default.Deconstruct(construct);
        }
    }

    internal class Program
    {
        /*
        [Serializable]
        [CompilerGenerated]
        private sealed class _c
        {
            public static readonly _c _9;

            public static Func<double, double, double> _9__0_0;

            static _c()
            {
                _9 = new _c();
            }

            public double _b__0_0(double x, double y)
            {
                var loc_0 = (x + y) * 0.5 * 20 / 4;
                var loc_1 = loc_0 - 20;
                return loc_1;
            }
        }
        */
        
        private static void Main(string[] args)
        {
            var l = new object[] { "#", 2, 3, 4, 5 };

            var bytes = l.ToConstruct();

            Console.WriteLine(bytes.ToHAString());

            Console.WriteLine("------------------------");
            var d = bytes.ToDeconstruct().Detach<object[]>();
            foreach (var item in d)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------");

            Console.ReadKey();
            return;

            var asmList = new[]
            {
                typeof(GC).Assembly,
                typeof(Uri).Assembly,
                typeof(Enumerable).Assembly
            };


            var list = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.IsPublic && !(a.IsAbstract && a.IsSealed) && asmList.Contains(a.Assembly))
                .OrderBy(x => x.Name?.Length * (x.IsPrimitive ? -1 : 1) * x.Namespace?.Length)
                .ToLookup(x => x.IsGenericType ? x.GetGenericArguments().Length : 0);

            var sb = new StringBuilder();

            var map = new MapCollection<int, string> { { 0x7FFFFFFF, "" } };
            foreach (var v in list)
            {
                var k = v.ToList();
                for (int i = 0; i < k.Count; i++)
                {
                    var weight = v.Key + (i + 1) * 256;

                    map.Link(weight, k[i].AssemblyQualifiedName);

                    sb.AppendLine($"{{ 0x{weight.ToString("X").PadLeft(6, '0')}, \"{k[i].AssemblyQualifiedName}\" }},");
                }
            }
            Console.WriteLine(sb);

            //Console.WriteLine();
            //map.TryGet(0x101, out var item);
           // Console.WriteLine(item);
            File.WriteAllText("content.cs", sb.ToString());
            //Console.WriteLine(sb);

            Console.ReadKey();
        }

        

        
    }
}


