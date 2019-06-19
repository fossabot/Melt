namespace Melt.Converters
{
    using System;

    public sealed class UnsignedPointer : ValueTypeConverter<UIntPtr>
    {
        protected override int SpanSize => 4;

        protected override UIntPtr OnConvertFromBytes(byte[] bytes, ConverterPool pool) => new UIntPtr(pool.Deconstruct(bytes).Detach<uint>());
        protected override byte[] OnConvertToBytes(UIntPtr graph, ConverterPool pool) => pool.Construct().Attach((uint)graph);
    }
}
