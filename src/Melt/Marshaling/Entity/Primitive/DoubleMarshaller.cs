// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class DoubleMarshaller : ValueTypeMarshaller<double>
    {
        protected override int SpanSize => 8;

        protected override double OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => BitConverter.ToDouble(bytes, 0);

        protected override byte[] OnConvertToBytes(double graph, IMarshalingProvider pool) => BitConverter.GetBytes(graph);
    }
}