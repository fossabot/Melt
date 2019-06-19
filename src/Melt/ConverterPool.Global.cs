namespace Melt
{
    using Melt.Converters;

    partial class ConverterPool
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

                                // Basic Class Library Type
                                .Install<CultureInfoConverter>()
                                .Install<DateTimeConverter>()
                                .Install<GuidConverter>()
                                .Install<IPAddressConverter>()
                                .Install<IPEndPointConverter>()
                                .Install<RegexConverter>()
                                .Install<StringBuilderConverter>()
                                .Install<TimeSpanConverter>()
                                .Install<UriConverter>()

                                // Collection Types
                                .Install<ArrayConverter>()
                                .Install<ListConverter>()
                                .Install<DictionaryConverter>()

                                // Data Components Types
                                .Install<DataColumnConverter>()
                                .Install<DataTableConverter>()
                                .Install<DataSetConverter>()

                                // Special Types
                                .Install<EnumerationConverter>()
                                .Install<ObjectConverter>()
                                .Install<TypeConverter>()
                                .Install<ValueTupleConverter>()

                                // Primitive Types
                                .Install<BooleanConverter>()
                                .Install<SignedByteConverter>()
                                .Install<SignedShortConverter>()
                                .Install<SignedIntegerConverter>()
                                .Install<SignedLongConverter>()
                                .Install<UnsignedByteConverter>()
                                .Install<UnsignedShortConverter>()
                                .Install<UnsignedIntegerConverter>()
                                .Install<UnsignedLongConverter>()
                                .Install<CharacterConverter>()
                                .Install<SingleConverter>()
                                .Install<DoubleConverter>()
                                .Install<DecimalConverter>()
                                .Install<UnicodeStringConverter>();


                        }
                    }
                    return s_instance;
                }
            }
        }
        private readonly static object s_locker = new object();
        private static volatile ConverterPool s_instance;
    }
}
