// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public sealed class SignedLongConverter : ValueTypeConverter<long>
    {
        protected override int SpanSize => 8;

        protected override long OnConvertFromBytes(byte[] bytes, ConverterPool pool) => BitConverter.ToInt64(bytes, 0);

        protected override byte[] OnConvertToBytes(long graph, ConverterPool pool) => BitConverter.GetBytes(graph);
    }
}