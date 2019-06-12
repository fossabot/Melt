// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System.Net;

    public sealed class IPEndPointConverter : ReferenceTypeConverter<IPEndPoint>
    {
        protected override IPEndPoint OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var addr = d.Detach<IPAddress>();
            var p = d.Detach<int>(out length);
            return new IPEndPoint(addr, p);
        }
        protected override byte[] OnConvertToBytes(IPEndPoint graph, ConverterPool pool)
        {
            return pool.Construct().Attach(graph.Address).Attach(graph.Port);
        }
    }

}