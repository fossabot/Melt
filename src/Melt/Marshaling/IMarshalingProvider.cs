// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling
{
    using Melt.Marshaling.Contracts;

    using System;
    using System.ComponentModel;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IMarshalingProvider
    {
        Construct Construct();
        Deconstruct Deconstruct(byte[] bytes);


        IMarshalingProvider Install<T>(T inst) where T : IMarshaller;
        IMarshalingProvider Install<T>() where T : IMarshaller, new();
        

        [EditorBrowsable(EditorBrowsableState.Never)]
        IMarshaller Get(Type type);
        [EditorBrowsable(EditorBrowsableState.Never)]
        IMarshaller Get<T>();
    }
}