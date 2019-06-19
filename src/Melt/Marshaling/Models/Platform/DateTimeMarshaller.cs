// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;
    using System.Runtime.InteropServices;
    public sealed class DateTimeMarshaller : ValueTypeMarshaller<DateTime>
    {
        private readonly static int s_intSz = Marshal.SizeOf<long>();
        protected override int SpanSize => s_intSz;

        protected override DateTime OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool)
        {
            return new DateTime(pool.Deconstruct(bytes).Detach<long>());
        }

        protected override byte[] OnConvertToBytes(DateTime graph, IMarshalingProvider pool)
        {
            return pool.Construct().Attach(graph.Ticks);
        }
    }
}