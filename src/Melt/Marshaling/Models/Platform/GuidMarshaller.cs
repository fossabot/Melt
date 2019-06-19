// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class GuidMarshaller : ValueTypeMarshaller<Guid>
    {
        protected override int SpanSize => 16;

        protected override Guid OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => new Guid(bytes.AsSpan(0, SpanSize).ToArray());

        protected override byte[] OnConvertToBytes(Guid graph, IMarshalingProvider pool) => graph.ToByteArray();
    }
}