// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Contracts
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    

    public abstract class MarshallerBase<T> : IMarshaller 
    {
        public MarshallerBase()
        {
            this.Name = this.GetType().Name;
        }

        public override string ToString() => this.Name;

        public override bool Equals(object obj)
        {
            if(obj is IMarshaller c)
            {
                return c.GetHashCode() == this.GetHashCode();                
            }
            return false;
        }

        public override int GetHashCode() => this.Name.GetHashCode();

        public virtual string Name { get; }

        protected abstract byte[] DefaultValueBytes { get; }

        [DebuggerNonUserCode]
        public T FromBytes(byte[] bytes, out int spanLength, IMarshalingProvider pool)
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

        [DebuggerNonUserCode]
        object IMarshaller.FromBytes(byte[] bytes, out int spanLength, IMarshalingProvider pool)
        {
            return FromBytes(bytes, out spanLength, pool);
        }

        public virtual bool CanMarshal(Type type) => type.FullName == typeof(T).FullName;

        [DebuggerNonUserCode]
        public byte[] ToBytes(T obj, IMarshalingProvider pool)
        {
            if (Equals(obj, default(T)))
                return DefaultValueBytes;

            if (!CanMarshal(typeof(T)))
                return DefaultValueBytes;

            return OnConvertToBytes(obj, pool);
        }

        [DebuggerNonUserCode]
        byte[] IMarshaller.ToBytes(object obj, IMarshalingProvider pool)
        {
            var data = (T)obj;
            return ToBytes(data, pool);
        }

        protected abstract T OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool);

        protected abstract byte[] OnConvertToBytes(T graph, IMarshalingProvider pool);

        private bool IsDefaultValueBytes(byte[] bytes)
        {
            if (bytes.Length < DefaultValueBytes.Length)
                return false;

            var span = bytes.AsSpan(default, DefaultValueBytes.Length).ToArray();
            return DefaultValueBytes.SequenceEqual(span);
        }
    }
}