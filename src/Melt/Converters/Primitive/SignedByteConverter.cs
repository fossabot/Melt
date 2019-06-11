
namespace Melt
{
    using System;
    #region Primitive Type
    public sealed class SignedByteConverter : ValueTypeConverter<sbyte>
    {
        protected override byte[] OnConvertToBytes(sbyte graph, ConverterPool pool) => BitConverter.GetBytes(graph);
        protected override int SpanSize => 2;
        protected override sbyte OnConvertFromBytes(byte[] bytes, ConverterPool pool) => (sbyte)BitConverter.ToChar(bytes, 0);
    }
    #endregion
}