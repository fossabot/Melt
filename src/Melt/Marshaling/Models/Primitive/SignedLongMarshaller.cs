// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class SignedLongMarshaller : ValueTypeMarshaller<long>
    {
        protected override int SpanSize => 8;

        protected override long OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => BitConverter.ToInt64(bytes, 0);

        protected override byte[] OnConvertToBytes(long graph, IMarshalingProvider pool) => BitConverter.GetBytes(graph);
    }
}