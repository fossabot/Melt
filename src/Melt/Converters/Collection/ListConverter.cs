
namespace Melt
{
    using System;
    using System.Collections;

    public sealed class ListConverter : ReferenceTypeConverter<IList>
    {
        public override bool IsTypeMatch(Type type) => (!type.IsArray) && typeof(IList).IsAssignableFrom(type);
        protected override byte[] OnConvertToBytes(IList list, ConverterPool pool)
        {
            var c = pool.Construct();
            var type = list.GetType();
            if(type.IsGenericType)
            {
                var generic = type.GetGenericArguments()[0];    // <TYPE>
                var typeDef = type.GetGenericTypeDefinition();  // IList<>

                c.Attach<byte>(2);
                c.Attach(generic);
                c.Attach(typeDef);

                c.Attach(list.Count);
                foreach (var item in list)
                {
                    c.Attach(generic, item);
                }
            }
            else // IList<object>
            {
                var typeWithoutGeneric = type;

                c.Attach<byte>(1);
                c.Attach(type);
                
                c.Attach(list.Count);
                foreach (object item in list)
                {
                    c.Attach(item);
                }
            }
            return c;
        }
        protected override IList OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var flag = d.Detach<byte>();

            if (flag == 2)
            {
                var generic = d.Detach<Type>();
                var typeDef = d.Detach<Type>();
                var count = d.Detach<int>(out length);

                var listType = typeDef.MakeGenericType(generic);
                var list = (IList)Activator.CreateInstance(listType);
                if (count == 0)
                    goto Leave;

                if (count != 1)
                    for (int i = 0; i < count - 1; i++)
                        list.Add(d.Detach(generic));

                list.Add(d.Detach(generic, out length));
                Leave:              
                return list;
            }
            else if (flag == 1)
            {
                var listType = d.Detach<Type>();
                var count = d.Detach<int>(out length);

                var list = (IList)Activator.CreateInstance(listType);

                if (count == 0)
                    goto Leave;                

                if (count != 1)
                    for (int i = 0; i < count - 1; i++)
                        list.Add(d.Detach<object>());
                
                list.Add(d.Detach<object>(out length));
                Leave:
                return list;
            }

            throw new NotSupportedException();
        }
    }
    
}
