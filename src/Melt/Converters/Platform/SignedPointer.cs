namespace Melt.Converters
{
    using System;

    public sealed class SignedPointer : ValueTypeConverter<IntPtr>
    {
        protected override int SpanSize => 4;

        protected override IntPtr OnConvertFromBytes(byte[] bytes, ConverterPool pool) => new IntPtr(pool.Deconstruct(bytes).Detach<int>());
        protected override byte[] OnConvertToBytes(IntPtr graph, ConverterPool pool) => pool.Construct().Attach((int)graph);
    }
}
