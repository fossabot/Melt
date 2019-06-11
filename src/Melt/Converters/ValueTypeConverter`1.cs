
namespace Melt
{
    using System.Runtime.InteropServices;

    public abstract class ValueTypeConverter<T> : ConverterBase<T> where T : struct
    {

        protected override byte[] DefaultValueBytes => new byte[SpanSize];

        protected abstract int SpanSize { get; }

        protected override T OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            length = SpanSize;
            return OnConvertFromBytes(bytes, pool);
        }
        protected abstract T OnConvertFromBytes(byte[] bytes, ConverterPool pool);
    }
    
}
