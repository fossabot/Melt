
namespace Melt
{
    using System;
    using System.Collections.Generic;

    public class ConverterPool
    {
        private readonly List<IConverter> _converters = new List<IConverter>();

        public ConverterPool()
        {
            this
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

                .Register<TypeConverter>()
                .Register<GuidConverter>()

                .Register<ObjectConverter>()
                ;
           ;
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
            Console.WriteLine($"[{_converters.Count}]: " + inst);
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

            throw new Exception("Converter not found");
        }

        internal IConverter Get<T>()
        {
            return Get(typeof(T));
        }
    }
}
