namespace Melt
{
    public partial class ConverterPool
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
                            s_instance = new ConverterPool();

                            s_instance
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
                                .Install<EnumerationConverter>()

                                .Install<UnicodeStringConverter>()
                                .Install<DateTimeConverter>()
                                .Install<TimeSpanConverter>()

                                .Install<UriConverter>()
                                .Install<StringBuilderConverter>()
                                .Install<TypeConverter>()
                                .Install<GuidConverter>()
                                .Install<IPAddressConverter>()
                                .Install<IPEndPointConverter>()
                                .Install<RegexConverter>()

                                .Install<ArrayConverter>()
                                .Install<ListConverter>()
                                .Install<DictionaryConverter>()

                                .Install<CultureInfoConverter>()
                                .Install<DataColumnConverter>()
                                .Install<DataTableConverter>()
                                .Install<DataSetConverter>()

                                .Install<ObjectConverter>();

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
