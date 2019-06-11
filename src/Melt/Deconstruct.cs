
namespace Melt
{
    using System;
    using System.Buffers;
    using System.Linq;

    public sealed class Deconstruct
    {
        private readonly byte[] _bytes;
        private readonly ConverterPool _pool;
        private int _index = 0;
        internal Deconstruct(byte[] bytes, ConverterPool pool)
        {
            _bytes = bytes;
            _pool = pool;
        }
        public object Detach(Type type, out int length)
        {
            var span = _bytes.AsSpan(_index);

            var converter = _pool.Get(type);

            var result = converter.FromBytes(span.ToArray(), out var spanLength, _pool);

            _index += spanLength;
            length = _index;
            return result;
        }

        public object Detach(Type type)
        {
            return Detach(type, out _);
        }

        public T Detach<T>(out int length)
        {
            return (T)Detach(typeof(T), out length);
        }

        public T Detach<T>()
        {
            return (T)Detach(typeof(T), out _);
        }
    }
}
