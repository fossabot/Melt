// Author: Orlys
// Github: https://github.com/Orlys
namespace Melt
{
    using System;

    public sealed class EnumerationConverter : ReferenceTypeConverter<Enum>
    {
        public override bool IsTypeMatch(Type type)
        {
            return type.IsEnum || type == typeof(Enum);
        }

        protected override byte[] OnConvertToBytes(Enum graph, ConverterPool pool)
        {
            var type = graph.GetType();
            var underlyingType = Enum.GetUnderlyingType(type);
            var c = pool.Construct();
            c.Attach(type);
            c.Attach(underlyingType, graph);
            return c;
        }

        protected override Enum OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var enumType = d.Detach<Type>();
            var underlyType = Enum.GetUnderlyingType(enumType);
            var value = d.Detach(underlyType, out length);
            return (Enum)Enum.ToObject(enumType, value);
        }
    }
}