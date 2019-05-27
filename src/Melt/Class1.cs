
namespace Melt
{
    using System;

    public abstract class ConverterBase
    {
        protected abstract Type Consult { get; }

        public virtual bool TypeMatch(Type type)
        {
            return this.Consult.FullName == type.FullName;
        }

        protected abstract object OnConvertFromBytes(byte[] bytes, IConverterPool pool);

        protected abstract byte[] OnConvertToBytes(object graph, IConverterPool pool);


        public byte[] ToBytes(object graph)
        {

        }

        public object FromBytes(byte[] bytes)
        {

        }

    }
    public interface IConverterPool
    {

    }
}
