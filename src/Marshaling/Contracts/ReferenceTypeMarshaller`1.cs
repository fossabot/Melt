// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Contracts
{
    using Melt.Marshaling.Internal;
    using System;
    using System.Runtime.InteropServices;

    public abstract class ReferenceTypeMarshaller<TClass> : MarshallerBase<TClass> //where TClass : class
    {
        private static int s_intSz = Marshal.SizeOf<int>();
        protected override byte[] DefaultValueBytes => MarshallerUtilities.Null;

        protected byte[] ConcatLenAndPayload(byte[] payload)
        {
            var len = System.BitConverter.GetBytes(payload.Length);
            return len.ConcatToArray(payload);
        }

        protected byte[] SeparateLenAndPayload(byte[] bytes, out int length)
        {
            var len = System.BitConverter.ToInt32(bytes, 0);
            var payload = bytes.AsSpan(s_intSz, len).ToArray();
            length = s_intSz + len;
            return payload;
        }
    }
}