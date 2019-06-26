// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System.Buffers;

    public sealed class UnsignedByteMarshaller : ValueTypeMarshaller<byte>
    {
        private readonly ArrayPool<byte> _array;
        public UnsignedByteMarshaller()
        {
            _array = ArrayPool<byte>.Create(1, 1);
        }
        protected override int SpanSize => 1;

        protected override byte OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => bytes[0];

        protected override byte[] OnConvertToBytes(byte graph, IMarshalingProvider pool)
        {
            var a = _array.Rent(1);
            try
            {
                a[0] = graph;
                return a;
            }
            finally
            {
                _array.Return(a, true);
            }
        }
    }
}