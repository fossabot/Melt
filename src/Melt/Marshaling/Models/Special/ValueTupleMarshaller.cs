
namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public sealed class ValueTupleMarshaller : ContractTypeMarshaller<ITuple>
    {
        private static readonly Type[] s_types =
        {
            typeof(ValueTuple<>),
            typeof(ValueTuple<,>),
            typeof(ValueTuple<,,>),
            typeof(ValueTuple<,,,>),
            typeof(ValueTuple<,,,,>),
            typeof(ValueTuple<,,,,,>),
            typeof(ValueTuple<,,,,,,>),
            typeof(ValueTuple<,,,,,,,>)
        };

        public override bool CanMarshal(Type type)
        {
            var f = base.CanMarshal(type) &&((type == typeof(ITuple)) || (type.IsGenericType && s_types.Contains(type.GetGenericTypeDefinition())));
            return f;
        }
        // todo:  expression cache
        private ITuple Constructor(Type valueTupleType, object[] args) => Activator.CreateInstance(valueTupleType, args) as ITuple;

        private const byte Max_Valid_Argument_Count = 7;

        private ITuple CreateByArgs(Stack<object> values, int maxStackSize)
        {
            var tupleTypes = GetTupleTypes(maxStackSize, out var tupleCount, out var lastTupleElementCount);

            var lastTupleTypeDefinition = tupleTypes.Pop();

            var typeCache = new Stack<Type>(Max_Valid_Argument_Count);
            var valueCache = new Stack<object>(Max_Valid_Argument_Count);
            for (int i = 0; i < lastTupleElementCount; i++)
            {
                var current = values.Pop();
                typeCache.Push(current.GetType());
                valueCache.Push(current);
            }

            var lastTupleType = lastTupleTypeDefinition.MakeGenericType(typeCache.ToArray());
            var holder = Constructor(lastTupleType, valueCache.ToArray());

            typeCache.Clear();
            valueCache.Clear();

            // Tuple<7+TRest>
            while (tupleTypes.TryPop(out var tupleTypeDefinition))
            {
                typeCache.Push(lastTupleType);
                valueCache.Push(holder);

                for (int i = 0; i < Max_Valid_Argument_Count; i++)
                {
                    var c = values.Pop();
                    typeCache.Push(c.GetType());
                    valueCache.Push(c);
                }

                lastTupleType = tupleTypeDefinition.MakeGenericType(typeCache.ToArray());
                holder = Constructor(lastTupleType, valueCache.ToArray());

                typeCache.Clear();
                valueCache.Clear();
            }
            return holder;
        }

        protected override ITuple OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            var d = pool.Deconstruct(bytes);
            var maxStackSize = d.Detach<int>();
            var values = new Stack<object>(maxStackSize);
            for (int i = 0; i < maxStackSize -1; i++)
            {
                var current = d.Detach<object>();
                values.Push(current);
            }
            var last = d.Detach<object>(out length);
            values.Push(last);

            return CreateByArgs(values, maxStackSize);
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

        protected override byte[] OnConvertToBytes(ITuple graph, IMarshalingProvider pool)
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
