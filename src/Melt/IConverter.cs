// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public interface IConverter
    {
        object FromBytes(byte[] bytes, out int spanLength, ConverterPool pool);

        bool IsTypeMatch(Type type);

        byte[] ToBytes(object obj, ConverterPool pool);
    }
}