// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class UriMarshaller : ReferenceTypeMarshaller<Uri>
    {
        protected override Uri OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool) => new Uri(pool.Deconstruct(bytes).Detach<string>(out length));

        protected override byte[] OnConvertToBytes(Uri graph, IMarshalingProvider pool) => pool.Construct().Attach(graph.ToString());
    }
}