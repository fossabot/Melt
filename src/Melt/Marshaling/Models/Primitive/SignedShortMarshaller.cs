// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class SignedShortMarshaller : ValueTypeMarshaller<short>
    {
        protected override int SpanSize => 2;

        protected override short OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => BitConverter.ToInt16(bytes, 0);

        protected override byte[] OnConvertToBytes(short graph, IMarshalingProvider pool) => BitConverter.GetBytes(graph);
    }
}