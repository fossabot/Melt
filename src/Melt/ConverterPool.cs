// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class ConverterPool
    {
        public static ConverterPool Global
        {
            get
            {
                lock (s_locker)
                {
                    if (s_instance == null)
                    {
                        lock (s_locker)
                        {
                            s_instance = new ConverterPool()
                                .Register<BooleanConverter>()
                                .Register<SignedByteConverter>()
                                .Register<SignedShortConverter>()
                                .Register<SignedIntegerConverter>()
                                .Register<SignedLongConverter>()
                                .Register<UnsignedByteConverter>()
                                .Register<UnsignedShortConverter>()
                                .Register<UnsignedIntegerConverter>()
                                .Register<UnsignedLongConverter>()
                                .Register<CharacterConverter>()
                                .Register<SingleConverter>()
                                .Register<DoubleConverter>()
                                .Register<DecimalConverter>()
                                .Register<UnicodeStringConverter>()

                                .Register<DateTimeConverter>()
                                .Register<UriConverter>()
                                .Register<StringBuilderConverter>()
                                .Register<TypeConverter>()
                                .Register<GuidConverter>()
                                .Register<IPAddressConverter>()
                                .Register<IPEndPointConverter>()

                                .Register<ObjectConverter>();
                        }
                    }
                    return s_instance;
                }
            }
        }
        private readonly static object s_locker = new object();
        private static volatile ConverterPool s_instance;




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