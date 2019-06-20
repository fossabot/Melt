// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using Melt.Marshaling.Internal;
    using System;
    using System.Diagnostics;

    public sealed class TypeMarshaller : ReferenceTypeMarshaller<Type>
    {        

        public override bool CanMarshal(Type type)
        {
            return type.FullName.Equals("System.Type");
        }

        [DebuggerNonUserCode]
        protected override Type OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
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

            throw new InvalidCastException("Dislocation, unregistered type or not type not matched.");
        }

        protected override byte[] OnConvertToBytes(Type graph, IMarshalingProvider pool)
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