using System;
using System.Reflection;

namespace Melt.Reflection {
    public interface IILProvider {
        byte[] GetByteArray();
    }

    public class MethodBaseILProvider : IILProvider {
        MethodBase m_method;
        byte[] m_byteArray;

        public MethodBaseILProvider(byte[] il)
        {
            m_byteArray = il;
        }

        public MethodBaseILProvider(MethodBase method) {
            m_method = method;
        }

        public byte[] GetByteArray() {
            if (m_byteArray == null) {
                var methodBody = m_method.GetMethodBody();
                m_byteArray = (methodBody == null) ? new byte[0] : methodBody.GetILAsByteArray();
            }
            return m_byteArray;
        }
    }
}
