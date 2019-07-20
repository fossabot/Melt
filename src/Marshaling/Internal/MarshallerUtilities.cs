// Author: Orlys
// Github: https://github.com/Orlys
namespace Melt.Marshaling.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class MarshallerUtilities
    {
        internal static readonly byte[] Null = { 0, 0, 0, 0 };

        internal static List<byte> ConcatToList(this byte[] first, params byte[][] other)
        {
            if (other == null && first == null)
                throw new ArgumentNullException(nameof(first));

            var list = first.ToList();

            foreach (var bs in other)
            {
                if (bs == null || bs.Length == 0)
                    continue;
                list.AddRange(bs);
            }
            return list;
        }

        internal static byte[] ConcatToArray(this byte[] first, params byte[][] other)
        {
            return first.ConcatToList(other).ToArray();
        }
    }
}
