// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class TimeSpanConverter : ValueTypeConverter<TimeSpan>
    {
        private static readonly int s_intSz = Marshal.SizeOf<long>();
        protected override int SpanSize => s_intSz;

        protected override TimeSpan OnConvertFromBytes(byte[] bytes, ConverterPool pool)
        {
            return new TimeSpan(pool.Deconstruct(bytes).Detach<long>());
        }

        protected override byte[] OnConvertToBytes(TimeSpan graph, ConverterPool pool)
        {
            return pool.Construct().Attach(graph.Ticks);
        }
    }
}