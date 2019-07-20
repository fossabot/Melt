// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;
    using System.Net.NetworkInformation;

    public sealed class PhysicalAddressMarshaller : ReferenceTypeMarshaller<PhysicalAddress>
    {
        protected override PhysicalAddress OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            length = 6;
            return new PhysicalAddress(bytes.AsSpan(0, length).ToArray());
        }
        protected override byte[] OnConvertToBytes(PhysicalAddress graph, IMarshalingProvider pool)
        {
            return graph.GetAddressBytes();
        }
    }
}