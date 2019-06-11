
namespace Melt
{
    using System;

    public interface IConverter
    {
        bool IsTypeMatch(Type type);
        byte[] ToBytes(object obj, ConverterPool pool);
        object FromBytes(byte[] bytes, out int spanLength, ConverterPool pool);
    }
}
