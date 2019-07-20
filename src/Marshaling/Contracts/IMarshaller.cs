// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Contracts
{
    using System;

    public interface IMarshaller
    {
        string Name { get; }

        object FromBytes(byte[] bytes, out int spanLength, IMarshalingProvider pool);

        bool CanMarshal(Type type);

        byte[] ToBytes(object obj, IMarshalingProvider pool);
    }
}