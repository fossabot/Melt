// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;
    using System.Collections.Generic;

    public sealed class DecimalMarshaller : ValueTypeMarshaller<decimal>
    {
        protected override int SpanSize => 16;

        protected override decimal OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => ToDecimal(bytes);

        protected override byte[] OnConvertToBytes(decimal graph, IMarshalingProvider pool) => GetBytes(graph);

        //https://social.technet.microsoft.com/wiki/contents/articles/19055.net-convert-system-decimal-to-and-from-byte-arrays.aspx
        private byte[] GetBytes(decimal dec)
        {
            //Load four 32 bit integers from the Decimal.GetBits function
            var bits = decimal.GetBits(dec);
            //Create a temporary list to hold the bytes
            var bytes = new List<byte>();
            //iterate each 32 bit integer
            foreach (var i in bits)
            {
                //add the bytes of the current 32bit integer
                //to the bytes list
                bytes.AddRange(BitConverter.GetBytes(i));
            }
            //return the bytes list as an array
            return bytes.ToArray();
        }

        private decimal ToDecimal(byte[] bytes)
        {
            if (bytes.Length != SpanSize)
                throw new Exception("A decimal must be created from exactly 16 bytes");
            var bits = new int[4];
            for (int i = 0; i < 16; i += 4)
            {
                bits[i / 4] = BitConverter.ToInt32(bytes, i);
            }
            return new decimal(bits);
        }
    }
}