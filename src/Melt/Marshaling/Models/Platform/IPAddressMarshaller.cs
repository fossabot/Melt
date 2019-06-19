// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System.Net;

    public sealed class IPAddressMarshaller : ReferenceTypeMarshaller<IPAddress>
    {
        protected override IPAddress OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            return new IPAddress(SeparateLenAndPayload(bytes, out length));
        }
        protected override byte[] OnConvertToBytes(IPAddress graph, IMarshalingProvider pool)
        {
            return ConcatLenAndPayload(graph.GetAddressBytes());
        }
    }
}