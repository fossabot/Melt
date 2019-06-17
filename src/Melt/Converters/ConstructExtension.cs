// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
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

        public static Construct ToConstruct<T>(this T obj)
        {
            return Default.Construct().Attach(obj);
        }

        public static Deconstruct ToDeconstruct(this Construct construct)
        {
            return Default.Deconstruct(construct);
        }
    }
}