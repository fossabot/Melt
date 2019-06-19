// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Contracts
{
    public abstract class ValueTypeMarshaller<TStruct> : MarshallerBase<TStruct> where TStruct : struct
    {
        protected override byte[] DefaultValueBytes => new byte[SpanSize];

        protected abstract int SpanSize { get; }

        protected override TStruct OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            length = SpanSize;
            return OnConvertFromBytes(bytes, pool);
        }

        protected abstract TStruct OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool);
    }
}