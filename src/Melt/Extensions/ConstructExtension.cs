// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Extensions
{
    using System.ComponentModel;
    using System.Diagnostics;

    public static class ConstructExtension
    {
        private static ConverterPool s_pool;
        public static ConverterPool Default
        {
            get
            {
                if (s_pool == null)
                    return ConverterPool.Global;
                return s_pool;
            }
            set
            {
                s_pool = value;
            }
        }

        [DebuggerNonUserCode]
        public static Construct ToConstruct<T>(this T obj)
        {
            return Default.Construct().Attach(obj);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Construct ToConstruct(this Construct obj)
        {
            return obj;
        }

        [DebuggerNonUserCode]
        public static Deconstruct ToDeconstruct(this Construct construct)
        {
            return ((byte[])construct).ToDeconstruct();
        }

        [DebuggerNonUserCode]
        public static Deconstruct ToDeconstruct(this byte[] construct)
        {
            return Default.Deconstruct(construct);
        }

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