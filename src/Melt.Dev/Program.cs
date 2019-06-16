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


        class MyClass
        {

        }
        private static void Main(string[] args)
        {
            var ty = new MyClass().GetType();

            var p = new ConverterPool();
            p.Register<SignedIntegerConverter>();
            p.Register<UnicodeStringConverter>();
            p.Register<TypeConverter>();

            byte[] bytes = p.Construct().Attach(ty);
            Console.WriteLine(bytes.ToHAString());
            Console.WriteLine("len: "+bytes.Length);
            var b = p.Deconstruct(bytes).Detach<Type>();

            Console.WriteLine(b);

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


