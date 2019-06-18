// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class ConverterPool
    {
        private readonly HashSet<IConverter> _converters;

        public ConverterPool()
        {
            _converters = new HashSet<IConverter>();
        }

        public Construct Construct()
        {
            return new Construct(this);
        }
        
        public Deconstruct Deconstruct(byte[] bytes)
        {
            return new Deconstruct(bytes, this);
        }


        public ConverterPool Install<T>(T inst) where T : IConverter
        {
            if (_converters.Add(inst))
                Debug.WriteLine($"Install: [{_converters.Count}]({inst})");
            return this;
        }

        public ConverterPool Install<T>() where T : IConverter, new()
        {
            return Install(new T());
        }
        

        [DebuggerNonUserCode]
        internal IConverter Get(Type type)
        {
            foreach (var c in _converters)
            {
                if (c.CanConvert(type))
                {
                    return c;
                }
            }

            throw new Exception($"Can not convert type '{type}' because converter not found.");
        }

        [DebuggerNonUserCode]
        internal IConverter Get<T>()
        {
            return Get(typeof(T));
        }
    }
}