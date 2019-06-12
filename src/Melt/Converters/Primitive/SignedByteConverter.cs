// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public sealed class SignedByteConverter : ValueTypeConverter<sbyte>
    {
        protected override int SpanSize => 2;

        protected override sbyte OnConvertFromBytes(byte[] bytes, ConverterPool pool) => (sbyte)BitConverter.ToChar(bytes, 0);

        protected override byte[] OnConvertToBytes(sbyte graph, ConverterPool pool) => BitConverter.GetBytes(graph);
    }
}