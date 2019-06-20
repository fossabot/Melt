// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using Melt.Marshaling.Internal;
    using System;
    using System.Diagnostics;

    public sealed class ObjectMarshaller : ReferenceTypeMarshaller<object>
    {
        protected override byte[] DefaultValueBytes => MarshallerUtilities.Null;

        protected override object OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            var d = pool.Deconstruct(bytes);
            var type = d.Detach<Type>();
            var value = d.Detach(type, out length);
            return value;
        }

        protected override byte[] OnConvertToBytes(object graph, IMarshalingProvider pool)
        {
            var type = graph.GetType();
            byte[] result = pool.Construct().Attach(type).Attach(type, graph);
            return result;
        }
    }
}