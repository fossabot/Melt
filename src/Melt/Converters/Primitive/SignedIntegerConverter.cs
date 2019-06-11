
namespace Melt
{
    using System;

    public sealed class SignedIntegerConverter : ValueTypeConverter<int>
    {
        protected override int SpanSize => 4;
        protected override int OnConvertFromBytes(byte[] bytes, ConverterPool pool) => BitConverter.ToInt32(bytes, 0);

        protected override byte[] OnConvertToBytes(int graph, ConverterPool pool) => BitConverter.GetBytes(graph);
    }
    
}