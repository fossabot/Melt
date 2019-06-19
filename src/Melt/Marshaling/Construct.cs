// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling
{
    using Melt.Marshaling.Internal;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;

    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerTypeProxy(typeof(BinaryStreamView))]
    public sealed class Construct
    {
        private readonly List<byte> _bytes;

        private readonly IMarshalingProvider _pool;

        internal Construct(IMarshalingProvider pool)
        {
            _pool = pool;
            _bytes = new List<byte>();
        }

        public static implicit operator byte[] (Construct construct)
        {
            return construct.ToBytes();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public byte[] ToBytes()
        {
            var array = this._bytes.ToArray();
            return array;
        }

        [DebuggerNonUserCode]
        public Construct Attach(Type type, object value)
        {
            var c = _pool.Get(type);
            var bytes = c.ToBytes(value, _pool);
            if (bytes != null)
                _bytes.AddRange(bytes);
            return this;
        }

        [DebuggerNonUserCode]
        public Construct Attach<T>(T value)
        {
            return Attach(typeof(T), value);
        }
    }
}