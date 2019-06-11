
namespace Melt
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public abstract class ConverterBase<T> : IConverter
    {
        public virtual bool IsTypeMatch(Type type) => type.FullName == typeof(T).FullName;


        protected abstract byte[] OnConvertToBytes(T graph, ConverterPool pool);
        protected abstract T OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool);

        protected abstract byte[] DefaultValueBytes { get; }

        private bool IsDefaultValueBytes(byte[] bytes)
        {
            if (bytes.Length < DefaultValueBytes.Length)
                return false;

            var span = bytes.AsSpan(default, DefaultValueBytes.Length).ToArray();
            return DefaultValueBytes.SequenceEqual(span);
        }


        public byte[] ToBytes(T obj, ConverterPool pool)
{

            if (!IsTypeMatch(typeof(T)))
                return DefaultValueBytes;

            if (Equals(obj, default(T)))
                return DefaultValueBytes;

            return OnConvertToBytes(obj, pool);
        }

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
        byte[] IConverter.ToBytes(object obj, ConverterPool pool)
        {
            var data = (T)obj;
            return ToBytes(data, pool);
        }
    }
    
}
