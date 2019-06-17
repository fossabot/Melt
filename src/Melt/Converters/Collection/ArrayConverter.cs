
namespace Melt
{
    using System;

    public sealed class ArrayConverter : ReferenceTypeConverter<Array>
    {
        public override bool CanConvert(Type type)
        {
            return type.IsArray || type.IsSubclassOf(typeof(Array)) || type == typeof(Array);
        }

        protected override byte[] OnConvertToBytes(Array list, ConverterPool pool)
        {
            var c = pool.Construct();
            var elementType = list.GetType().GetElementType();
            c.Attach(elementType);
            c.Attach(list.Length);
            for (int i = 0; i < list.Length; i++)
            {
                c.Attach(elementType, list.GetValue(i));
            }
            return c;
        }

        protected override Array OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var element = d.Detach<Type>();
            var count = d.Detach<int>(out length);
            var array = Array.CreateInstance(element, count);
            if (count == 0)
                goto Leave;
            if(count != 1)
            {
                for (int i = 0; i < count-1; i++)
                {
                    var current = d.Detach(element);
                    array.SetValue(current, i);
                }
            }
            var last = d.Detach(element, out length);
            array.SetValue(last, count - 1);

            Leave:
            return array;

        }
    }
    
}
