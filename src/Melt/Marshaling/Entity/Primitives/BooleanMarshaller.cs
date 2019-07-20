// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class BooleanMarshaller : ValueTypeMarshaller<bool>
    {
        protected override int SpanSize => 1;

        protected override bool OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => bytes[0] != default;

        protected override byte[] OnConvertToBytes(bool graph, IMarshalingProvider pool) => new byte[] { (byte)(graph ? 1 : 0) };
    }
}