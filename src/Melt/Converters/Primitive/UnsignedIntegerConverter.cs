
namespace Melt
{
    using System;

    public sealed class UnsignedIntegerConverter : ValueTypeConverter<uint>
    {
        protected override int SpanSize => 4;
        protected override uint OnConvertFromBytes(byte[] bytes, ConverterPool pool) => BitConverter.ToUInt32(bytes, 0);

        protected override byte[] OnConvertToBytes(uint graph, ConverterPool pool) => BitConverter.GetBytes(graph);
    }
    
}