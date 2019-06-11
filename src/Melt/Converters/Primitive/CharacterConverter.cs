
namespace Melt
{
    using System;

    #region Primitive Type


    public sealed class CharacterConverter : ValueTypeConverter<char>
    {
        protected override byte[] OnConvertToBytes(char graph, ConverterPool pool) => BitConverter.GetBytes(graph);
        protected override char OnConvertFromBytes(byte[] bytes, ConverterPool pool) => BitConverter.ToChar(bytes, 0);
        protected override int SpanSize => 2;
    }
    
    #endregion
}