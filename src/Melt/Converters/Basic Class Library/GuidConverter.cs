// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public sealed class GuidConverter : ValueTypeConverter<Guid>
    {
        protected override int SpanSize => 16;

        protected override Guid OnConvertFromBytes(byte[] bytes, ConverterPool pool) => new Guid(bytes.AsSpan(0, SpanSize).ToArray());

        protected override byte[] OnConvertToBytes(Guid graph, ConverterPool pool) => graph.ToByteArray();
    }
}