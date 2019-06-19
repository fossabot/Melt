// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Converters
{
    using Melt.Internal;
    using System;

    public sealed class TypeConverter : ReferenceTypeConverter<Type>
    {
        public override bool CanConvert(Type type)
        {
            return type.FullName.Equals("System.Type");
        }

        protected override Type OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var code = d.Detach<int>(out length);
            if (TypeMap.TryGet(code, out var typeString))
            {
                return Type.GetType(typeString);
            }
            if (code == 0x7FFFFFFF)
            {
                return Type.GetType(d.Detach<string>(out length));
            }

            throw new NotSupportedException("Type not difined.");
        }

        protected override byte[] OnConvertToBytes(Type graph, ConverterPool pool)
        {
            var c = pool.Construct();
            if (TypeMap.TryGet(graph.AssemblyQualifiedName, out var code))
            {
                c.Attach(code);
            }
            else
            {
                c.Attach(0x7FFFFFFF).Attach(graph.AssemblyQualifiedName);
            }
            return c;
        }
    }
}