// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System.Text;

    public sealed class StringBuilderMarshaller : ReferenceTypeMarshaller<StringBuilder>
    {
        protected override StringBuilder OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool) => new StringBuilder(pool.Deconstruct(bytes).Detach<string>(out length));

        protected override byte[] OnConvertToBytes(StringBuilder graph, IMarshalingProvider pool) => pool.Construct().Attach(graph.ToString());
    }
}