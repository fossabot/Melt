// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public sealed class CharacterConverter : ValueTypeConverter<char>
    {
        protected override int SpanSize => 2;

        protected override char OnConvertFromBytes(byte[] bytes, ConverterPool pool) => BitConverter.ToChar(bytes, 0);

        protected override byte[] OnConvertToBytes(char graph, ConverterPool pool) => BitConverter.GetBytes(graph);
    }
}