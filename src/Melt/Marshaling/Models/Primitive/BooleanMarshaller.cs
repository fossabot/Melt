// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class BooleanMarshaller : ValueTypeMarshaller<bool>
    {
        protected override int SpanSize => 1;

        protected override bool OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => BitConverter.ToBoolean(bytes, 0);

        protected override byte[] OnConvertToBytes(bool graph, IMarshalingProvider pool) => BitConverter.GetBytes(graph);
    }
}