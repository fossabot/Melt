// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class SignedIntegerMarshaller : ValueTypeMarshaller<int>
    {
        protected override int SpanSize => 4;

        protected override int OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => BitConverter.ToInt32(bytes, 0);

        protected override byte[] OnConvertToBytes(int graph, IMarshalingProvider pool) => BitConverter.GetBytes(graph);
    }
}