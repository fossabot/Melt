
namespace Melt
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public sealed class ValueTupleConverter : InterfaceTypeConverter<ITuple>
    {
        protected override ITuple OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var len = d.Detach<int>();
            var values = new Stack<object>(len);
            for (int i = 0; i < len -1; i++)
            {
                var current = d.Detach<object>();
                values.Push(current);
            }
            var last = d.Detach<object>(out length);
            values.Push(last);

            var tupleTypes = GetTupleTypes(len, out var tupleCount, out var lastTupleElementCount);

            var lastTupleTypeDefinition = tupleTypes.Pop();
            var typeCache = new List<Type>(7);
            var valueCache = new List<object>(7);
            for (int i = 0; i < lastTupleElementCount; i++)
            {
                var current = values.Pop();
                typeCache.Add(current.GetType());
                valueCache.Add(current);
            }
            typeCache.Reverse();
            valueCache.Reverse();
            var lastTupleType = lastTupleTypeDefinition.MakeGenericType(typeCache.ToArray());
            var holder = Activator.CreateInstance(lastTupleType, valueCache.ToArray()) as ITuple;

            typeCache.Clear();
            valueCache.Clear();


            while (tupleTypes.TryPop(out var tupleTypeDefinition))// Tuple<7+TRest>
            {
                for (int i = 0; i < 7; i++)
                {
                    var c = values.Pop();
                    typeCache.Add(c.GetType());
                    valueCache.Add(c);
                }
                typeCache.Reverse();
                valueCache.Reverse();
                typeCache.Add(lastTupleType);
                valueCache.Add(holder);

                lastTupleType = tupleTypeDefinition.MakeGenericType(typeCache.ToArray());
                holder = Activator.CreateInstance(lastTupleType, valueCache.ToArray()) as ITuple;
                typeCache.Clear();
                valueCache.Clear();
            }
            return holder;
            
        }

        private static Stack<Type> GetTupleTypes(int length, out int tupleCount, out int lastTupleElementCount)
        {
            var stack = new Stack<Type>();

            lastTupleElementCount = length % 7;
            tupleCount = length / 7;

            var flag = lastTupleElementCount > 0;

            for (int i = 0; i < tupleCount - (flag ? 0 : 1); i++)
                stack.Push(typeof(ValueTuple<,,,,,,,>));

            switch (lastTupleElementCount)
            {
                case 1: stack.Push(typeof(ValueTuple<>)); break;
                case 2: stack.Push(typeof(ValueTuple<,>)); break;
                case 3: stack.Push(typeof(ValueTuple<,,>)); break;
                case 4: stack.Push(typeof(ValueTuple<,,,>)); break;
                case 5: stack.Push(typeof(ValueTuple<,,,,>)); break;
                case 6: stack.Push(typeof(ValueTuple<,,,,,>)); break;
                case 0:
                    lastTupleElementCount = 7;
                    stack.Push(typeof(ValueTuple<,,,,,,>));
                    break;
            }

            return stack;
        }

        protected override byte[] OnConvertToBytes(ITuple graph, ConverterPool pool)
        {
            var c = pool.Construct();
            c.Attach(graph.Length);
            for (int i = 0; i < graph.Length; i++)
            {
                var current = graph[i];
                c.Attach(current);
            }
            return c;
        }
    }
}
