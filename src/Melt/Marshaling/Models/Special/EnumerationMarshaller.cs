// Author: Orlys
// Github: https://github.com/Orlys
namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class EnumerationMarshaller : ReferenceTypeMarshaller<Enum>
    {
        public override bool CanMarshal(Type type)
        {
            return type.IsEnum || type == typeof(Enum);
        }

        protected override byte[] OnConvertToBytes(Enum graph, IMarshalingProvider pool)
        {
            var type = graph.GetType();
            var underlyingType = Enum.GetUnderlyingType(type);
            var c = pool.Construct();
            c.Attach(type);
            c.Attach(underlyingType, graph);
            return c;
        }

        protected override Enum OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            var d = pool.Deconstruct(bytes);
            var enumType = d.Detach<Type>();
            var underlyType = Enum.GetUnderlyingType(enumType);
            var value = d.Detach(underlyType, out length);
            return (Enum)Enum.ToObject(enumType, value);
        }
    }
}