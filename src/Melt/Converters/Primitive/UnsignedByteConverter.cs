// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    public sealed class UnsignedByteConverter : ValueTypeConverter<byte>
    {
        protected override int SpanSize => 1;

        protected override byte OnConvertFromBytes(byte[] bytes, ConverterPool pool) => bytes[0];

        protected override byte[] OnConvertToBytes(byte graph, ConverterPool pool) => new byte[1] { graph };
    }
}