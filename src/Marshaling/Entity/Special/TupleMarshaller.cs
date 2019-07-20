
namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class TupleMarshaller : TupleTypeMarshaller
    {
        private readonly static Type[] s_rollTypes =
        {
            typeof(Tuple<,,,,,,,>),
            typeof(Tuple<>),
            typeof(Tuple<,>),
            typeof(Tuple<,,>),
            typeof(Tuple<,,,>),
            typeof(Tuple<,,,,>),
            typeof(Tuple<,,,,,>),
            typeof(Tuple<,,,,,,>)
        };
        protected override Type[] RollTypes => s_rollTypes;
    }
}
