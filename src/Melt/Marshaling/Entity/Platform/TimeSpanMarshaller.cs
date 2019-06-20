// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;
    using System.Runtime.InteropServices;

    public sealed class TimeSpanMarshaller : ValueTypeMarshaller<TimeSpan>
    {
        private static readonly int s_intSz = Marshal.SizeOf<long>();
        protected override int SpanSize => s_intSz;

        protected override TimeSpan OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool)
        {
            return new TimeSpan(pool.Deconstruct(bytes).Detach<long>());
        }

        protected override byte[] OnConvertToBytes(TimeSpan graph, IMarshalingProvider pool)
        {
            return pool.Construct().Attach(graph.Ticks);
        }
    }
}