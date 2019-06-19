
namespace Melt.CognitiveServices
{
    using Melt.Converters;
    using System.Collections.Generic;

    partial class Cognitive<TSelf> where TSelf : Cognitive<TSelf>, new()
    {
        private sealed class RuntimeGeneratedConverter : ReferenceTypeConverter<TSelf>
        {
            private readonly List<DelegateCarried> _carrieds;
            private readonly ConverterPool _pool;


            internal RuntimeGeneratedConverter(List<DelegateCarried> carrieds, ConverterPool pool)
            {
                this._carrieds = carrieds;
                this._pool = pool;
            }
            public override string Name => typeof(TSelf).FullName + " + " + nameof(RuntimeGeneratedConverter);

            protected override TSelf OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
            {
                for (int i = s_pipes.Count - 1; i >= 0; i--)
                {
                    bytes = s_pipes[i].Decode(bytes);
                }

                var obj = new TSelf();
                var q = new Queue<DelegateCarried>(_carrieds);
                var d = pool.Deconstruct(bytes);
                var carried = default(DelegateCarried);
                var value = default(object);
                while (q.Count > 1)
                {
                    carried = q.Dequeue();
                    value = d.Detach(carried.Type);
                    carried.SetValue(obj, value);
                }

                carried = q.Dequeue();
                value = d.Detach(carried.Type, out length);
                carried.SetValue(obj, value);

                return obj;
            }

            protected override byte[] OnConvertToBytes(TSelf graph, ConverterPool pool)
            {
                var c = pool.Construct();
                foreach (var carried in _carrieds)
                {
                    var getter = carried.GetValue(graph);
                    c.Attach(getter.GetType(), getter);
                }

                byte[] bytes = c;
                for (int i = 0; i < s_pipes.Count; i++)
                {
                    bytes = s_pipes[i].Encode(bytes);
                }
                return bytes;
            }
        }
    }
}
