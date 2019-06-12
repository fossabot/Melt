// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;
    using System.Linq;
    using System.Text;

    public sealed class UnicodeStringConverter : ReferenceTypeConverter<string>
    {
        private readonly byte[] _empty = { 2, 0, 0, 0, 0, 0 };

        protected override string OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var span = bytes.AsSpan();

            if (span.Length == _empty.Length && _empty.AsSpan().SequenceEqual(span.Slice(0, _empty.Length)))
            {
                length = _empty.Length;
                return string.Empty;
            }

            var payload = SeparateLenAndPayload(bytes, out length);
            var result = Encoding.Unicode.GetString(payload);
            return result;
        }

        protected override byte[] OnConvertToBytes(string graph, ConverterPool pool)
        {
            if (string.Equals(graph, string.Empty))
            {
                return _empty;
            }

            var value = Encoding.Unicode.GetBytes(graph);
            var result = ConcatLenAndPayload(value);
            return result;
        }
    }
}