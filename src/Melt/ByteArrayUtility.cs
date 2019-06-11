
namespace Melt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal static class ByteArrayUtility
    {
        private static StringBuilder s_builder
        {
            get
            {
                if (s_sb == null)
                    s_sb = new StringBuilder();

                return s_sb;
            }
        }
        private static StringBuilder s_sb;

        /// <summary>
        /// Converts the byte array to the hexdecimal string.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        internal static string ToHAString(this byte[] bytes)
        {
            s_builder.Clear();
            s_builder.Append("{ ");
            s_builder.Append(string.Join(", ", bytes.Select(x => "0x" + x.ToString("X2"))));
            s_builder.Append(" }");

            return s_builder.ToString();
        }

        internal static string ToHAString(this Construct c) => ((byte[])c).ToHAString();

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
