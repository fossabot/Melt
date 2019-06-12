// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt
{
    public sealed class UnsignedByteConverter : ValueTypeConverter<byte>
    {
        protected override int SpanSize => 1;

        protected override byte OnConvertFromBytes(byte[] bytes, ConverterPool pool) => bytes[0];

        protected override byte[] OnConvertToBytes(byte graph, ConverterPool pool) => new byte[1] { graph };
    }

    /*
    public sealed class Object : ReferenceTypeConverter<object>
    {
        public override bool IsTypeMatch(Type type) => true;
        protected override byte[] OnConvertToBytes(object graph, ConverterPool pool) => pool.Get(graph.GetType()).ToBytes();
        protected override object OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool) => throw new NotImplementedException();

        protected override byte[] DefaultValueBytes => ConverterCommonFields.Null;
    }
    */
}