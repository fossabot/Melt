// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public sealed class TypeConverter : ReferenceTypeConverter<Type>
    {
        public override bool IsTypeMatch(Type type)
        {
            return type.FullName.Equals("System.Type");
        }

        protected override Type OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            return Type.GetType(pool.Deconstruct(bytes).Detach<string>(out length));
        }

        protected override byte[] OnConvertToBytes(Type graph, ConverterPool pool)
        {
            var str = graph.IsPrimitive ? graph.FullName : graph.AssemblyQualifiedName;
            return pool.Construct().Attach(str);
        }
    }
    
}