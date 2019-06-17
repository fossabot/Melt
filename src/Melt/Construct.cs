﻿// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using Melt.Extensions;
    using System;
    using System.Collections.Generic;

    using System.Diagnostics;

    internal class ConstructObjectView
    {
        private readonly Construct _construct;

        public ConstructObjectView(Construct construct)
        {
            this._construct = construct;
            this.BinaryStream = (byte[])construct;
        }

        public byte[] BinaryStream { get; }

    }

    [DebuggerTypeProxy(typeof(ConstructObjectView))]
    public sealed class Construct
    {
        private readonly List<byte> _bytes;

        private readonly ConverterPool _pool;

        internal Construct(ConverterPool pool)
        {
            _pool = pool;
            _bytes = new List<byte>();
        }

        public static implicit operator byte[] (Construct construct)
        {
            var array = construct._bytes.ToArray();
            return array;
        }

        public Construct Attach(Type type, object value)
        {
            var c = _pool.Get(type);
            var bytes = c.ToBytes(value, _pool);
            if (bytes != null)
                _bytes.AddRange(bytes);
            return this;
        }

        public Construct Attach<T>(T value)
        {
            return Attach(typeof(T), value);
        }
    }
}