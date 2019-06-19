// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class CharacterMarshaller : ValueTypeMarshaller<char>
    {
        protected override int SpanSize => 2;

        protected override char OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => BitConverter.ToChar(bytes, 0);

        protected override byte[] OnConvertToBytes(char graph, IMarshalingProvider pool) => BitConverter.GetBytes(graph);
    }
}