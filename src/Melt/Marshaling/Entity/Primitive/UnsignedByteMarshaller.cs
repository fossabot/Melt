// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;

    public sealed class UnsignedByteMarshaller : ValueTypeMarshaller<byte>
    {
        protected override int SpanSize => 1;

        protected override byte OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => bytes[0];

        protected override byte[] OnConvertToBytes(byte graph, IMarshalingProvider pool) => new byte[1] { graph };
    }
}