// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Converters
{
    using System;

    public sealed class UnsignedLongConverter : ValueTypeConverter<ulong>
    {
        protected override int SpanSize => 8;

        protected override ulong OnConvertFromBytes(byte[] bytes, ConverterPool pool) => BitConverter.ToUInt64(bytes, 0);

        protected override byte[] OnConvertToBytes(ulong graph, ConverterPool pool) => BitConverter.GetBytes(graph);
    }
}