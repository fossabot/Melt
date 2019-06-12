// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System.Net;

    public sealed class IPAddressConverter : ReferenceTypeConverter<IPAddress>
    {
        protected override IPAddress OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            return new IPAddress(SeparateLenAndPayload(bytes, out length));
        }
        protected override byte[] OnConvertToBytes(IPAddress graph, ConverterPool pool)
        {
            return ConcatLenAndPayload(graph.GetAddressBytes());
        }
    }
}