// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public sealed class BooleanConverter : ValueTypeConverter<bool>
    {
        protected override int SpanSize => 1;

        protected override bool OnConvertFromBytes(byte[] bytes, ConverterPool pool) => BitConverter.ToBoolean(bytes, 0);

        protected override byte[] OnConvertToBytes(bool graph, ConverterPool pool) => BitConverter.GetBytes(graph);
    }
}