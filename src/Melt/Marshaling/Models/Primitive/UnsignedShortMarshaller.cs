// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class UnsignedShortMarshaller : ValueTypeMarshaller<ushort>
    {
        protected override int SpanSize => 2;

        protected override ushort OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => BitConverter.ToUInt16(bytes, 0);

        protected override byte[] OnConvertToBytes(ushort graph, IMarshalingProvider pool) => BitConverter.GetBytes(graph);
    }
}