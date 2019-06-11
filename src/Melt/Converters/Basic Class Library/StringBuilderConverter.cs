
namespace Melt
{
    using System;
    using System.Text;

    public sealed class StringBuilderConverter : ReferenceTypeConverter<StringBuilder>
    {
        protected override byte[] OnConvertToBytes(StringBuilder graph, ConverterPool pool) => pool.Construct().Attach(graph.ToString());
        protected override StringBuilder OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool) => new StringBuilder(pool.Deconstruct(bytes).Detach<string>(out length));
    }
}