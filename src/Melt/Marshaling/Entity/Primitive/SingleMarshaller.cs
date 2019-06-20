// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;


    public sealed class SingleMarshaller : ValueTypeMarshaller<float>
    {
        protected override int SpanSize => 8;

        protected override float OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => Convert.ToSingle(BitConverter.ToDouble(bytes, 0));

        protected override byte[] OnConvertToBytes(float graph, IMarshalingProvider pool) => BitConverter.GetBytes(Convert.ToDouble(graph));
    }
}