// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Dev
{
    using Melt.Utilities;

    using System;
    using System.IO;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Security.Permissions;
    using System.Linq;
    using ClrTest.Reflection;
    using System.Collections.Generic;

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
            /*
            var act = new Func<double, double, double>((x, y) =>
            {
                var k = (x + y) * 0.5 * 20 / 4;

                return k - 20;
            });
            */

            int x = 600;

            Func<int,int,int> myAction = (s,y) =>
            {
                Console.WriteLine("Hello " + s +"<>" + y);
                x += s;
                return s + y;
            };


            var method = myAction.GetMethodInfo();
            var target = myAction.Target;
            var body = method.GetMethodBody();
            var maxStackSize = body.MaxStackSize;

            var paraList = method.GetParameters().Aggregate(new List<Type> { method.DeclaringType }, (l, pt) => { l.Add(pt.ParameterType); return l; });
            
            var code = body.GetILAsByteArray();
            var ret = method.ReturnType;

            var n = "_" + Guid.NewGuid().ToString("X").Replace("-", null);
            var dm = new DynamicMethod(n, ret, paraList.ToArray(), paraList[0], true);
            var ilInfo = dm.GetDynamicILInfo();
            var sig = SignatureHelper.GetLocalVarSigHelper();
            foreach (var lvi in body.LocalVariables)
                sig.AddArgument(lvi.LocalType, lvi.IsPinned);
            
            ilInfo.SetLocalSignature(sig.GetSignature());
            var reader = new ILReader(method);
            var visitor = new DynamicMethodHelper.ILInfoGetTokenVisitor(ilInfo, code);
            reader.Accept(visitor);
            ilInfo.SetCode(code, maxStackSize);

            var k = dm.Invoke(target, new object[] { target, 200, 100 });
            Console.WriteLine(k);
            Console.ReadKey();
        }

        public static byte[] ToBytes<T>(T @delegate) where T : Delegate
        {
            var method = @delegate.GetMethodInfo();
            var target = @delegate.Target;

            var il = method.GetMethodBody().GetILAsByteArray();
            return il;
        }

        /*
        public static T FromBytes<T>(byte[] bytes) where T : Delegate
        {
            var name = "m_" + Guid.NewGuid().ToString("x").Replace("-", null);
            var retType = 
            var dm = new DynamicMethod(
                name,
                method.ReturnType,
                new[] { method.DeclaringType }.
            Concat(method.GetParameters().
                Select(pi => pi.ParameterType)).ToArray(),
                method.DeclaringType,
        skipVisibility: true);

            DynamicILInfo ilInfo = dm.GetDynamicILInfo();
            var body = method.GetMethodBody();
            var sig = SignatureHelper.GetLocalVarSigHelper();
            foreach (LocalVariableInfo lvi in body.LocalVariables)
            {
                sig.AddArgument(lvi.LocalType, lvi.IsPinned);
            }
            ilInfo.SetLocalSignature(sig.GetSignature());
            byte[] code = body.GetILAsByteArray();
            ILReader reader = new ILReader(method);
            DynamicMethodHelper.ILInfoGetTokenVisitor visitor = new DynamicMethodHelper.ILInfoGetTokenVisitor(ilInfo, code);
            reader.Accept(visitor);
            ilInfo.SetCode(code, body.MaxStackSize);

            dm.Invoke(target, new object[] { target, "World" });
        }

        */
    }
}