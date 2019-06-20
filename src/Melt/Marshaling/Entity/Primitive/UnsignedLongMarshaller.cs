// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class UnsignedLongMarshaller : ValueTypeMarshaller<ulong>
    {
        protected override int SpanSize => 8;

        protected override ulong OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => BitConverter.ToUInt64(bytes, 0);

        protected override byte[] OnConvertToBytes(ulong graph, IMarshalingProvider pool) => BitConverter.GetBytes(graph);
    }
}