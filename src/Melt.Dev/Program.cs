
namespace Melt.Dev
{
    using Melt;
    using Melt.Extensions;
    using Melt.Support;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    
    class Program
    {
        public static Stack<Type> GetTupleTypes(int length,out int tupleCount, out int lastTupleElementCount)
        {
            var stack = new Stack<Type>();

            lastTupleElementCount = length % 7;
            tupleCount = length / 7;

            for (int i = lastTupleElementCount == 0 ? 1 : 0; i < tupleCount; i++)
                stack.Push(typeof(ValueTuple<,,,,,,,>));


            switch (lastTupleElementCount)
            {
                case 1: stack.Push(typeof(ValueTuple<>)); break;
                case 2: stack.Push(typeof(ValueTuple<,>)); break;
                case 3: stack.Push(typeof(ValueTuple<,,>)); break;
                case 4: stack.Push(typeof(ValueTuple<,,,>)); break;
                case 5: stack.Push(typeof(ValueTuple<,,,,>)); break;
                case 6: stack.Push(typeof(ValueTuple<,,,,,>)); break;
                case 0: stack.Push(typeof(ValueTuple<,,,,,,>)); break;
            }
            return stack;
        }

        static void Main(string[] args)
        {
            var kk = (1, 2, 3 ,4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,15,16);
            

            ConverterPool.Global.Install<ValueTupleConverter>();


            Console.WriteLine(kk.ToConstruct().ToHAString());

            var vv = kk.ToConstruct().ToDeconstruct().Detach<(int, int, int, int, int, int, int, int, int, int, int, int, int, int, int,int) > ();
            Console.WriteLine(vv);

            Exit();
        }

        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
