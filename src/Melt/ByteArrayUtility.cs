
namespace Melt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ByteArrayUtility
    {
        private static StringBuilder Builder
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
        public static string ToHAString(this byte[] bytes)
        {
            Builder.Clear();
            Builder.Append("{ ");
            Builder.Append(string.Join(", ", bytes.Select(x => "0x" + x.ToString("X2"))));
            Builder.Append(" }");

            return Builder.ToString();
        }

        public static string ToHAString(this Construct c) => ((byte[])c).ToHAString();

        public static List<byte> ConcatToList(this byte[] first, params byte[][] other)
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

        public static byte[] ConcatToArray(this byte[] first, params byte[][] other)
        {
            return first.ConcatToList(other).ToArray();
        }
    }
   
}
