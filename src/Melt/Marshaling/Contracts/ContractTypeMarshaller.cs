
namespace Melt.Marshaling.Contracts
{
    using System;

    public abstract class ContractTypeMarshaller<TInterface> : ReferenceTypeMarshaller<TInterface> where TInterface : class
    {
        public override bool CanMarshal(Type type) => typeof(TInterface).IsAssignableFrom(type);
    }
    
}
