// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;
    using System.Linq;

    public abstract class ConverterBase<T> : IConverter
    {
        protected abstract byte[] DefaultValueBytes { get; }

        public T FromBytes(byte[] bytes, out int spanLength, ConverterPool pool)
        {
            spanLength = 0;
            if (bytes == null || bytes.Length == 0)
                throw new ArgumentNullException(nameof(bytes));

            if (IsDefaultValueBytes(bytes))
            {
                spanLength = DefaultValueBytes.Length;
                return default;
            }

            return OnConvertFromBytes(bytes, out spanLength, pool);
        }

        object IConverter.FromBytes(byte[] bytes, out int spanLength, ConverterPool pool)
        {
            return FromBytes(bytes, out spanLength, pool);
        }

        public virtual bool IsTypeMatch(Type type) => type.FullName == typeof(T).FullName;

        public byte[] ToBytes(T obj, ConverterPool pool)
        {
            if (Equals(obj, default(T)))
                return DefaultValueBytes;

            if (!IsTypeMatch(typeof(T)))
                return DefaultValueBytes;

            return OnConvertToBytes(obj, pool);
        }

        byte[] IConverter.ToBytes(object obj, ConverterPool pool)
        {
            var data = (T)obj;
            return ToBytes(data, pool);
        }

        protected abstract T OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool);

        protected abstract byte[] OnConvertToBytes(T graph, ConverterPool pool);

        private bool IsDefaultValueBytes(byte[] bytes)
        {
            if (bytes.Length < DefaultValueBytes.Length)
                return false;

            var span = bytes.AsSpan(default, DefaultValueBytes.Length).ToArray();
            return DefaultValueBytes.SequenceEqual(span);
        }
    }
}