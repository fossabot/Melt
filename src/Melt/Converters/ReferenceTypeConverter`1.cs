
namespace Melt
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    public abstract class ReferenceTypeConverter<T> : ConverterBase<T> where T : class
    {

        protected override byte[] DefaultValueBytes => ConverterCommonFields.Null;


        protected byte[] ConcatLenAndPayload(byte[] payload)
        {
            var len = BitConverter.GetBytes(payload.Length);
            return len.ConcatToArray(payload);
        }

        private static int s_intSz = Marshal.SizeOf<int>();
        protected byte[] SeparateLenAndPayload(byte[] bytes, out int length)
        {
            var len = BitConverter.ToInt32(bytes, 0);
            var payload = bytes.AsSpan(s_intSz, len).ToArray();
            length = s_intSz + len;
            return payload;
        }
    }
    
}
