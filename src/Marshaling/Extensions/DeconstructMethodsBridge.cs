// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Extensions
{
    using Melt.Marshaling;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    public static class DeconstructMethodsBridge
    {
        [DebuggerNonUserCode]
        public static Deconstruct Detach<T>(this Deconstruct deconstruct, out T value)
        {
            return deconstruct.Detach(out value, out _);
        }

        [DebuggerNonUserCode]
        public static Deconstruct Detach<T>(this Deconstruct deconstruct, out T value, out int length)
        {
            value = deconstruct.Detach<T>(out length);
            return deconstruct;
        }
    }
}