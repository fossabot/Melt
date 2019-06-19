namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class UnsignedPointerMarshaller : ValueTypeMarshaller<UIntPtr>
    {
        protected override int SpanSize => 4;

        protected override UIntPtr OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => new UIntPtr(pool.Deconstruct(bytes).Detach<uint>());
        protected override byte[] OnConvertToBytes(UIntPtr graph, IMarshalingProvider pool) => pool.Construct().Attach((uint)graph);
    }
}
