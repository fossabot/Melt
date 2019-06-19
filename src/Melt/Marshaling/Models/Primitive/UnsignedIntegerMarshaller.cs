// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class UnsignedIntegerMarshaller : ValueTypeMarshaller<uint>
    {
        protected override int SpanSize => 4;

        protected override uint OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => BitConverter.ToUInt32(bytes, 0);

        protected override byte[] OnConvertToBytes(uint graph, IMarshalingProvider pool) => BitConverter.GetBytes(graph);
    }
}