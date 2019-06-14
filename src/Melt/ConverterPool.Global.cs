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
                                .Register<TimeSpanConverter>()

                                .Register<UriConverter>()
                                .Register<StringBuilderConverter>()
                                .Register<TypeConverter>()
                                .Register<GuidConverter>()
                                .Register<IPAddressConverter>()
                                .Register<IPEndPointConverter>()
                                .Register<RegexConverter>()

                                .Register<CollectionConverter>()

                                .Register<ObjectConverter>();

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
