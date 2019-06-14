// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public partial class ConverterPool
    {
        private readonly List<IConverter> _converters = new List<IConverter>();

        public ConverterPool()
        {
        }

        public Construct Construct()
        {
            return new Construct(this);
        }

        public Deconstruct Deconstruct(byte[] bytes)
        {
            return new Deconstruct(bytes, this);
        }


        public ConverterPool Register<T>(T inst) where T : IConverter
        {
            Debug.WriteLine($"Register: [{_converters.Count}]({inst})");
            _converters.Add(inst);
            return this;
        }

        public ConverterPool Register<T>() where T : IConverter, new()
        {
            return Register(new T());
        }
        

        internal IConverter Get(Type type)
        {
            foreach (var c in _converters)
            {
                if (c.IsTypeMatch(type))
                {
                    return c;
                }
            }

            throw new Exception($"Can not convert type '{type}' because converter not found.");
        }

        internal IConverter Get<T>()
        {
            return Get(typeof(T));
        }
    }
}