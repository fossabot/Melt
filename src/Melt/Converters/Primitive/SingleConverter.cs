// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public sealed class SingleConverter : ValueTypeConverter<float>
    {
        protected override int SpanSize => 8;

        protected override float OnConvertFromBytes(byte[] bytes, ConverterPool pool) => Convert.ToSingle(BitConverter.ToDouble(bytes, 0));

        protected override byte[] OnConvertToBytes(float graph, ConverterPool pool) => BitConverter.GetBytes(Convert.ToDouble(graph));
    }
}