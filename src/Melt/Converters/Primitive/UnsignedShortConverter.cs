// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public sealed class UnsignedShortConverter : ValueTypeConverter<ushort>
    {
        protected override int SpanSize => 2;

        protected override ushort OnConvertFromBytes(byte[] bytes, ConverterPool pool) => BitConverter.ToUInt16(bytes, 0);

        protected override byte[] OnConvertToBytes(ushort graph, ConverterPool pool) => BitConverter.GetBytes(graph);
    }
}