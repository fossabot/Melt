
namespace Melt.CognitiveServices
{
    using Melt.CognitiveServices.Pipeline;
    using Melt.Marshaling;
    using Melt.Packing.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public abstract partial class Cognitive<TSelf> where TSelf : Cognitive<TSelf>, new()
    {
        private readonly static IList<IPipeline> s_pipes;

        static Cognitive()
        {
            var type = typeof(TSelf);

            var pipes = type.GetCustomAttributes<PipelineAttribute>();
            s_pipes = new List<IPipeline>();
            foreach (var p in pipes)
            {
                if (p.IsInvaildAttribute)
                    continue;

                s_pipes.Add(p.Pipeline);
            }
        }

        protected Cognitive()
        {
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

            var pool = MarshalingProvider;
            var marshaller = new RuntimeGeneratedmarshaller(carrieds, pool);
            pool.Install(marshaller);
        }
        protected delegate object MemberSelector(TSelf @this);

        protected abstract IEnumerable<Expression<MemberSelector>> GetFlowControl();


        protected virtual IMarshalingProvider MarshalingProvider => Marshallers.Common;
    }
}
