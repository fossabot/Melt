
namespace Melt
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    
    public sealed class ObjectConverter : ReferenceTypeConverter<object>
    {
        protected override byte[] OnConvertToBytes(object graph, ConverterPool pool)
        {
            var type = graph.GetType();
            byte[] result = pool.Construct().Attach(type).Attach(type, graph);
            return result;
        }
        protected override object OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var type = d.Detach<Type>();
            var value = d.Detach(type, out length);
            return value;
        }
        protected override byte[] DefaultValueBytes => ConverterCommonFields.Null;
    }

}