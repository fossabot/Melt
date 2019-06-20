
namespace Melt.Marshaling
{
    using Melt.Common;
    using Melt.Marshaling.Contracts;
    using Melt.Marshaling.Internal;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    [NoteMaybe("unstable")]
    public sealed class NullableMarshaller : IMarshaller
    {
        public string Name => nameof(NullableMarshaller);

        public bool CanMarshal(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public override string ToString() => this.Name;

        public override bool Equals(object obj)
        {
            if (obj is IMarshaller c)
            {
                return c.GetHashCode() == this.GetHashCode();
            }
            return false;
        }

        public override int GetHashCode() => this.Name.GetHashCode();

        private byte[] DefaultValueBytes => MarshallerUtilities.Null;
        

        object IMarshaller.FromBytes(byte[] bytes, out int spanLength, IMarshalingProvider pool)
        {
            spanLength = 0;
            if (bytes == null || bytes.Length == 0)
                throw new ArgumentNullException(nameof(bytes));

            if (IsDefaultValueBytes(bytes))
            {
                spanLength = DefaultValueBytes.Length;
                return default;
            }

            return pool.Deconstruct(bytes).Detach<object>(out spanLength);
        }
        byte[] IMarshaller.ToBytes(object obj, IMarshalingProvider pool)
        {
            if (Equals(obj, null))
                return DefaultValueBytes;
            
            if(!obj.GetType().IsValueType)
                return DefaultValueBytes;

            return pool.Construct().Attach(obj);
        }
        
    

        private bool IsDefaultValueBytes(byte[] bytes)
        {
            if (bytes.Length < DefaultValueBytes.Length)
                return false;

            var span = bytes.AsSpan(default, DefaultValueBytes.Length).ToArray();
            return DefaultValueBytes.SequenceEqual(span);
        }
    }
}
