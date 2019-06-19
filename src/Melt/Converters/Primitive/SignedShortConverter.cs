// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Converters
{
    using System;

    public sealed class SignedShortConverter : ValueTypeConverter<short>
    {
        protected override int SpanSize => 2;

        protected override short OnConvertFromBytes(byte[] bytes, ConverterPool pool) => BitConverter.ToInt16(bytes, 0);

        protected override byte[] OnConvertToBytes(short graph, ConverterPool pool) => BitConverter.GetBytes(graph);
    }
}