// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Converters
{
    using System;

    public sealed class ObjectConverter : ReferenceTypeConverter<object>
    {
        protected override byte[] DefaultValueBytes => ConverterCommonFields.Null;

        protected override object OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var type = d.Detach<Type>();
            var value = d.Detach(type, out length);
            return value;
        }

        protected override byte[] OnConvertToBytes(object graph, ConverterPool pool)
        {
            var type = graph.GetType();
            byte[] result = pool.Construct().Attach(type).Attach(type, graph);
            return result;
        }
    }
}