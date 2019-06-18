// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    

    public abstract class ConverterBase<T> : IConverter 
    {
        public ConverterBase()
        {
            this.Name = this.GetType().Name;
        }

        public override string ToString() => this.Name;

        public override bool Equals(object obj)
        {
            if(obj is IConverter c)
            {
                return c.GetHashCode() == this.GetHashCode();                
            }
            return false;
        }

        public override int GetHashCode() => this.Name.GetHashCode();

        public virtual string Name { get; }

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

        public virtual bool CanConvert(Type type) => type.FullName == typeof(T).FullName;

        public byte[] ToBytes(T obj, ConverterPool pool)
        {
            if (Equals(obj, default(T)))
                return DefaultValueBytes;

            if (!CanConvert(typeof(T)))
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