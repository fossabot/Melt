
namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;
    using System.Collections;
    using System.Linq;
    
    public sealed class ValueTupleMarshaller : TupleTypeMarshaller
    {
        private readonly static Type[] s_rollTypes =
        {
            typeof(ValueTuple<,,,,,,,>),
            typeof(ValueTuple<>),
            typeof(ValueTuple<,>),
            typeof(ValueTuple<,,>),
            typeof(ValueTuple<,,,>),
            typeof(ValueTuple<,,,,>),
            typeof(ValueTuple<,,,,,>),
            typeof(ValueTuple<,,,,,,>)
        };
        protected override Type[] RollTypes => s_rollTypes;
    }
}
