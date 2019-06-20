// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using Melt.Marshaling;
    using Melt.Marshaling.Contracts;
    using Melt.Marshaling.Internal;

    /// <summary>
    /// 
    /// </summary>
    public partial class Marshallers : IMarshalingProvider, ICloneable
    {
        private readonly HashSet<IMarshaller> _marshallers;

        private Marshallers()
        {
            _marshallers = new HashSet<IMarshaller>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Construct Construct()
        {
            return new Construct(this);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public Deconstruct Deconstruct(byte[] bytes)
        {
            return new Deconstruct(bytes, this);
        }


        public IMarshalingProvider Install<T>(T inst) where T : IMarshaller
        {
            if (_marshallers.Add(inst))
            {
                Debug.WriteLine($"Install: [{_marshallers.Count}]({inst})");
            }
            return this;
        }

        public IMarshalingProvider Install<T>() where T : IMarshaller, new()
        {
            return Install(new T());
        }
        

        [DebuggerNonUserCode]
        public IMarshaller Get(Type type)
        {
            foreach (var c in _marshallers)
            {
                if (c.CanMarshal(type))
                {
                    return c;
                }
            }

            throw new Exception($"Can not convert type '{type}' because marshaller not found.");
        }
        
        [DebuggerNonUserCode]
        public IMarshaller Get<T>()
        {
            return Get(typeof(T));
        }

        object ICloneable.Clone()
        {
            var pool = new Marshallers();
            foreach (var c in _marshallers)
            {
                pool._marshallers.Add(c);
            }
            return pool;
        }
    }
}