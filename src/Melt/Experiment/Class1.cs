
namespace Melt.Ultra
{
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;
    using Melt;

    public class TupleConverter : InterfaceTypeConverter<ITuple>
    {
        protected override ITuple OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var len = d.Detach<int>();
            var list = new ArrayList(len);
            for (int i = 0; i < len -1; i++)
            {
                var current = d.Detach<object>();
                list.Add(current);
            }
            var last = d.Detach<object>(out length);
            list.Add(last);

            

            return Tuple.Create(1);
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
