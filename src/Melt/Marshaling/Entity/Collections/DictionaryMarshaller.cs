
namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class DictionaryMarshaller : ContractTypeMarshaller<IDictionary>
    {
        public override bool CanMarshal(Type type) => base.CanMarshal(type);
        protected override IDictionary OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            var d = pool.Deconstruct(bytes);
            var flag = d.Detach<byte>();
            if(flag == 2)
            {
                var count = d.Detach<int>();
                var keyType = d.Detach<Type>();
                var valueType = d.Detach<Type>(out length);
                var dictType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);
                var dict = Activator.CreateInstance(dictType) as IDictionary;
                if(count == 0)
                {
                    goto Leave;
                }

                if(count != 1)
                {
                    for (int i = 0; i < count-1; i++)
                    {
                        var currentKey = d.Detach(keyType);
                        var currentValue = d.Detach(valueType);
                        dict.Add(currentKey, currentValue);
                    }
                }

                var lastKey = d.Detach(keyType);
                var lastValue = d.Detach(valueType, out length);
                dict.Add(lastKey, lastValue);

                Leave:
                return dict;
                    
            }
            else if(flag == 1)
            {
                var count = d.Detach<int>();
                var dictType = d.Detach<Type>(out length);
                var dict = Activator.CreateInstance(dictType) as IDictionary;
                if (count == 0)
                {
                    goto Leave;
                }

                if (count != 1)
                {
                    for (int i = 0; i < count - 1; i++)
                    {
                        var currentKey = d.Detach<object>();
                        var currentValue = d.Detach<object>();
                        dict.Add(currentKey, currentValue);
                    }
                }

                var lastKey = d.Detach<object>();
                var lastValue = d.Detach<object>(out length);
                dict.Add(lastKey, lastValue);

                Leave:
                return dict;
            }
            throw new NotSupportedException();
        }

        private static readonly Type[] s_dictTypes = { typeof(Dictionary<,>), typeof(IDictionary<,>) };

        protected override byte[] OnConvertToBytes(IDictionary dict, IMarshalingProvider pool)
        {
            var type = dict.GetType();
            var c = pool.Construct();
            if(type.IsGenericType && s_dictTypes.Contains(type.GetGenericTypeDefinition()))
            {
                c.Attach<byte>(2); // Strong Type Convertion
                c.Attach(dict.Count);
                var ga = type.GetGenericArguments();
                var keyType = ga[0];
                var valyeType = ga[1];
                c.Attach(keyType);
                c.Attach(valyeType);

                foreach (DictionaryEntry entry in dict)
                {
                    c.Attach(keyType, entry.Key);
                    c.Attach(valyeType, entry.Value);
                }

            }
            else
            {
                c.Attach<byte>(1); // Weak Type Convertion
                c.Attach(dict.Count);
                c.Attach(type);

                foreach (DictionaryEntry entry in dict)
                {
                    c.Attach(entry.Key);
                    c.Attach(entry.Value);
                }
            }
            return c;
        }
    }
    
}
