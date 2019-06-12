// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public sealed class UriConverter : ReferenceTypeConverter<Uri>
    {
        protected override Uri OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool) => new Uri(pool.Deconstruct(bytes).Detach<string>(out length));

        protected override byte[] OnConvertToBytes(Uri graph, ConverterPool pool) => pool.Construct().Attach(graph.ToString());
    }
}