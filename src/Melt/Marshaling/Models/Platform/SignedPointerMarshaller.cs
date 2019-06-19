namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;

    public sealed class SignedPointerMarshaller : ValueTypeMarshaller<IntPtr>
    {
        protected override int SpanSize => 4;

        protected override IntPtr OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => new IntPtr(pool.Deconstruct(bytes).Detach<int>());
        protected override byte[] OnConvertToBytes(IntPtr graph, IMarshalingProvider pool) => pool.Construct().Attach((int)graph);
    }
}
