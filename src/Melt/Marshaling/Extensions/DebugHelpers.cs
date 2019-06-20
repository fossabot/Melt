// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Extensions
{
    using Melt.Marshaling;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text; 

    public static class DebugHelpers
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
        public static string ToHAString(this byte[] bytes, int rowCount = 8)
        {

            s_builder.Clear();
            s_builder.Append("{ ");
            var last = bytes.Length - 1;
            for (int i = 0; i < last; i++)
            {
                if (i % rowCount == 0)
                {
                    s_builder.AppendLine().Append("    ");
                }
                s_builder.Append("0x" + bytes[i].ToString("X2") + ", ");

            }
            s_builder.AppendLine("0x" + bytes[last].ToString("X2"));
            s_builder.Append("}");

            return s_builder.ToString();
        }

        /// <summary>
        /// Converts the <see cref="Construct"/> to the hexdecimal string.
        /// </summary>
        public static string ToHAString(this Construct c, int rowCount = 8) => ((byte[])c).ToHAString(rowCount);


    }
}