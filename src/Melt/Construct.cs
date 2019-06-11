
namespace Melt
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public sealed class Construct
    {
        internal Construct(ConverterPool pool)
        {
            _pool = pool;
            _bytes = new List<byte>();
        }

        private readonly List<byte> _bytes;
        private readonly ConverterPool _pool;

        public Construct Attach( Type type, object value)
        {
            var c = _pool.Get(type);
            var bytes =c.ToBytes(value, _pool);
            _bytes.AddRange(bytes);
            return this;
        }


        public Construct Attach<T>(T value)
        {
            return Attach(typeof(T), value);
        }


        public static implicit operator byte[](Construct construct)
        {
            var array = construct._bytes.ToArray();
            return array;
        }
    }
}
