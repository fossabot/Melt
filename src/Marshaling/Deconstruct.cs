// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class Deconstruct
    {
        private readonly byte[] _bytes;
        private readonly IMarshalingProvider _pool;
        private int _index = 0;

        internal Deconstruct(byte[] bytes, IMarshalingProvider pool)
        {
            _bytes = bytes;
            _pool = pool;
        }

        [DebuggerNonUserCode]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public object Detach(Type type, out int length)
        {
            var span = _bytes.AsSpan(_index);

            var marshaller = _pool.Get(type);

            var result = marshaller.FromBytes(span.ToArray(), out var spanLength, _pool);

            _index += spanLength;
            length = _index;
            return result;
        }

        [DebuggerNonUserCode]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public object Detach(Type type)
        {
            return Detach(type, out _);
        }

        [DebuggerNonUserCode]
        public T Detach<T>(out int length)
        {
            return (T)Detach(typeof(T), out length);
        }

        [DebuggerNonUserCode]
        public T Detach<T>()
        {
            return (T)Detach(typeof(T), out _);
        }
    }
}