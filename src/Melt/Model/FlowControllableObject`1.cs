
namespace Melt.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;

    public abstract class FlowControllableObject<TSelf> where TSelf : FlowControllableObject<TSelf>, new()
    {
        protected delegate object MemberSelector(TSelf @this);

        public FlowControllableObject() : this(ConverterPool.Global)
        {
        }

        public FlowControllableObject(ConverterPool pool)
        {
            if (pool == null)
                throw new ArgumentNullException(nameof(pool));

            var carrieds = new List<DelegateCarried>();
            foreach (var control in GetFlowControl().ToArray())
            {
                var member = control.Body as MemberExpression;
                if (member == null)
                {
                    var convert = control.Body as UnaryExpression;
                    member = convert.Operand as MemberExpression;
                }

                // todo: Expression Binder
                if (member.Member is PropertyInfo property)
                {
                    if (!property.CanRead)
                    {
                        throw new Exception("The property can't be read.");
                    }
                    if (!property.CanWrite)
                    {
                        throw new Exception("The property can't be write.");
                    }

                    carrieds.Add(new DelegateCarried(property.GetValue, property.SetValue, property.PropertyType));
                }

                if (member.Member is FieldInfo field)
                {
                    if (field.IsInitOnly)
                    {
                        throw new Exception("The field can't be assign because it was init-only.");
                    }
                    carrieds.Add(new DelegateCarried(field.GetValue, field.SetValue, field.FieldType));
                }
            }

            var converter = new RuntimeGeneratedConverter(carrieds, pool);
            pool.Install(converter);
        }

        private sealed class DelegateCarried
        {
            internal DelegateCarried(Func<object, object> getValue, Action<object, object> setValue, Type type)
            {
                this.GetValue = getValue;
                this.SetValue = setValue;
                this.Type = type;
            }

            internal Func<object, object> GetValue { get; }
            internal Action<object, object> SetValue { get; }
            internal Type Type { get; }
        }



        private sealed class RuntimeGeneratedConverter : ReferenceTypeConverter<TSelf>
        {
            private readonly List<DelegateCarried> _carrieds;
            private readonly ConverterPool _pool;


            internal RuntimeGeneratedConverter(List<DelegateCarried> carrieds, ConverterPool pool)
            {
                this._carrieds = carrieds;
                this._pool = pool;
            }
            public override string Name => typeof(TSelf).FullName + " + " + nameof(RuntimeGeneratedConverter);

            protected override TSelf OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
            {
                var obj = new TSelf();
                var q = new Queue<DelegateCarried>(_carrieds);
                var d = pool.Deconstruct(bytes);
                var carried = default(DelegateCarried);
                var value = default(object);
                while (q.Count > 1)
                {
                    carried = q.Dequeue();
                    value = d.Detach(carried.Type);
                    carried.SetValue(obj, value);
                }

                carried = q.Dequeue();
                value = d.Detach(carried.Type, out length);
                carried.SetValue(obj, value);

                return obj;
            }

            protected override byte[] OnConvertToBytes(TSelf graph, ConverterPool pool)
            {
                var c = pool.Construct();
                foreach (var carried in _carrieds)
                {
                    var getter = carried.GetValue(graph);
                    c.Attach(getter.GetType(), getter);
                }
                return c;
            }
        }

        protected abstract IEnumerable<Expression<MemberSelector>> GetFlowControl();
    }
}
