
namespace Melt
{
    using System;

    public sealed class DoubleConverter : ValueTypeConverter<double>
    {
        protected override int SpanSize => 8;
        protected override double OnConvertFromBytes(byte[] bytes, ConverterPool pool) => BitConverter.ToDouble(bytes, 0);
        protected override byte[] OnConvertToBytes(double graph, ConverterPool pool) => BitConverter.GetBytes(graph);
    }
    
}