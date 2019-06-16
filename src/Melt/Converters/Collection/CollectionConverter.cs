
namespace Melt
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class CollectionConverter : ReferenceTypeConverter<ICollection>
    {
        public override bool IsTypeMatch(Type type) => typeof(ICollection).IsAssignableFrom(type);

        protected override ICollection OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var flag = d.Detach<byte>();
            var count = d.Detach<int>();
            var genericType = d.Detach<Type>(out length);

            if (flag == 2)
            {
                var listType = typeof(List<>).MakeGenericType(genericType);
                var list = Activator.CreateInstance(listType);
                if (count == 0)
                {
                    goto Leave;
                }

                if (count != 1)
                    for (int i = 0; i < count - 1; i++)
                    {
                        listType.GetMethod("Add").Invoke(list, new[] { d.Detach(genericType) });
                    }

                listType.GetMethod("Add").Invoke(list, new[] { d.Detach(genericType, out length) });
                Leave:
                return list as ICollection;
            }
            else if (flag == 1)
            {
                var list = new List<object>();

                if (count == 0)
                {
                    return list;
                }

                if (count != 1)
                    for (int i = 0; i < count - 1; i++)
                    {
                        list.Add(d.Detach(genericType));
                    }

                list.Add(d.Detach(genericType, out length));
                return list;
            }

            length = 0;
            return null;
        }
        protected override byte[] OnConvertToBytes(ICollection graph, ConverterPool pool)
        {
            var type = graph.GetType();
            var count = graph.Count;
            var isGeneric = type.IsGenericType;
            var c = pool.Construct();
            if (isGeneric && type.GenericTypeArguments[0] != typeof(object))
            {
                c.Attach<byte>(2);
                c.Attach(count);
                var genericType = type.GenericTypeArguments[0];
                c.Attach(genericType);
                foreach (var row in graph)
                {
                    c.Attach(genericType, row);
                }
            }
            else
            {
                c.Attach<byte>(1);
                c.Attach(count);
                c.Attach(typeof(object));
                foreach (var row in graph)
                {
                    c.Attach(row);
                }
            }

            return c;
        }
    }

}
