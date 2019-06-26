namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System.Numerics;

    public sealed class BigIntegerMarshaller : ValueTypeMarshaller<BigInteger>
    {
        protected override byte[] OnConvertToBytes(BigInteger graph, IMarshalingProvider pool)
        {
            var bi = graph.ToByteArray();
            var c = pool.Construct();
            c.Attach(bi.Length);
            for (int i = 0; i < bi.Length; i++)
            {
                c.Attach(bi[i]);
            }
            return c;
        }
        protected override BigInteger OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            var d = pool.Deconstruct(bytes);
            var len = d.Detach<int>(out length);
            var array = new byte[len];
            if (len == 0)
                goto Leave;
            if (len != 1)
            {
                for (int i = 0; i < len-1; i++)
                {
                    array[i] = d.Detach<byte>();
                }
            }
            array[len-1] = d.Detach<byte>(out length);

            Leave:
            return new BigInteger(array);
        }

        protected override int SpanSize => throw new System.NotImplementedException();

        protected override BigInteger OnConvertFromBytes(byte[] bytes, IMarshalingProvider pool) => throw new System.NotImplementedException();
    }
}
