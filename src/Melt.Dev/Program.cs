// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Dev
{
    using Melt.Utilities;
    using clrmd = Microsoft.Diagnostics.Runtime;
    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Security.Permissions;

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
            
            var act = new Func<double, double, double>((x, y) =>
            {
                var k = (x + y) * 0.5 * 20 / 4;

                return k - 20;
            });
             
            Console.WriteLine(act(10,20) == 55);
            Console.WriteLine(act.Method.GetMethodBody().GetILAsByteArray().ToHAString());

            /*
            if ( _c._9__0_0 == null)
            {
                _c._9__0_0 = new Func<double, double, double>(_c._9._b__0_0);
            }
            Console.WriteLine(_c._9__0_0(10, 20) == 55);
            */
            Console.ReadKey();
        }
    }
}