// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System.Net;

    public sealed class IPEndPointMarshaller : ReferenceTypeMarshaller<IPEndPoint>
    {
        protected override IPEndPoint OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            var d = pool.Deconstruct(bytes);
            var addr = d.Detach<IPAddress>();
            var p = d.Detach<int>(out length);
            return new IPEndPoint(addr, p);
        }
        protected override byte[] OnConvertToBytes(IPEndPoint graph, IMarshalingProvider pool)
        {
            return pool.Construct().Attach(graph.Address).Attach(graph.Port);
        }
    }

}