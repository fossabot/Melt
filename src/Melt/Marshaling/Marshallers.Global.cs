namespace Melt.Marshaling
{
    using Marshaling.Entity;

    partial class Marshallers
    {
        public static IMarshalingProvider Common
        {
            get
            {
                lock (s_locker)
                {
                    if (s_instance == null)
                    {
                        lock (s_locker)
                        {
                            s_instance = new Marshallers()

                                // Basic Class Library Type
                                .Install<BigIntegerMarshaller>()
                                .Install<CultureInfoMarshaller>()
                                .Install<DateTimeMarshaller>()
                                .Install<GuidMarshaller>()
                                .Install<IPAddressMarshaller>()
                                .Install<IPEndPointMarshaller>()
                                .Install<RegexMarshaller>()
                                .Install<StringBuilderMarshaller>()
                                .Install<TimeSpanMarshaller>()
                                .Install<UriMarshaller>()

                                // Collection Types
                                .Install<ArrayMarshaller>()
                                .Install<ListMarshaller>()
                                .Install<DictionaryMarshaller>()

                                // Data Components Types
                                .Install<DataColumnMarshaller>()
                                .Install<DataTableMarshaller>()
                                .Install<DataSetMarshaller>()

                                // Special Types
                                .Install<EnumerationMarshaller>()
                                .Install<ObjectMarshaller>()
                                .Install<TypeMarshaller>()
                                .Install<ValueTupleMarshaller>()
                                .Install<NullableMarshaller>()

                                // Primitive Types
                                .Install<BooleanMarshaller>()
                                .Install<SignedByteMarshaller>()
                                .Install<SignedShortMarshaller>()
                                .Install<SignedIntegerMarshaller>()
                                .Install<SignedLongMarshaller>()
                                .Install<UnsignedByteMarshaller>()
                                .Install<UnsignedShortMarshaller>()
                                .Install<UnsignedIntegerMarshaller>()
                                .Install<UnsignedLongMarshaller>()
                                .Install<CharacterMarshaller>()
                                .Install<SingleMarshaller>()
                                .Install<DoubleMarshaller>()
                                .Install<DecimalMarshaller>()
                                .Install<UnicodeStringMarshaller>();
                        }
                    }
                    return s_instance;
                }
            }
        }
        private readonly static object s_locker = new object();
        private static volatile IMarshalingProvider s_instance;
    }
}
