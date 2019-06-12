﻿// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class DateTimeConverter : ValueTypeConverter<DateTime>
    {
        private readonly static int s_sz = Marshal.SizeOf<long>();

        protected override int SpanSize => s_sz;

        protected override DateTime OnConvertFromBytes(byte[] bytes, ConverterPool pool)
        {
            return new DateTime(pool.Deconstruct(bytes).Detach<long>());
        }

        protected override byte[] OnConvertToBytes(DateTime graph, ConverterPool pool)
        {
            return pool.Construct().Attach(graph.Ticks);
        }
    }
}