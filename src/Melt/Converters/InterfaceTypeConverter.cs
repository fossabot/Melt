
namespace Melt
{
    using System;

    public abstract class InterfaceTypeConverter<TContract> : ReferenceTypeConverter<TContract> where TContract : class
    {
        public override bool CanConvert(Type type) => typeof(TContract).IsAssignableFrom(type);
    }
    
}
