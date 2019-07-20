// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class SignedByteMarshaller : ValueTypeMarshaller<sbyte>
    {
        protected override int SpanSize => 2;

        protected override sbyte OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => (sbyte)BitConverter.ToChar(bytes, 0);

        protected override byte[] OnConvertToBytes(sbyte graph, IMarshalingProvider pool) => BitConverter.GetBytes(graph);
    }
}