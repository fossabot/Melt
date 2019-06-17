// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    using System;

    public interface IConverter
    {
        object FromBytes(byte[] bytes, out int spanLength, ConverterPool pool);

        bool CanConvert(Type type);

        byte[] ToBytes(object obj, ConverterPool pool);
    }
}