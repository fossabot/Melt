
namespace Melt.Onion.Packing.Contracts
{
    using System;
    using System.Linq;

    public abstract class PipelineBase : IPipeline
    {
        byte[] IInflowPipeline.Inflow(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return Array.Empty<byte>();
            return InflowImpl(bytes);
        }
        byte[] IOutflowPipeline.Outflow(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return Array.Empty<byte>();
            return OutflowImpl(bytes);
        }

        protected abstract byte[] InflowImpl(byte[] bytes);

        protected abstract byte[] OutflowImpl (byte[] bytes);


        internal bool SelfValidate()
        {
            var rnd = Guid.NewGuid().ToByteArray();
            var holder = InflowImpl(rnd);
            var rnd2 = OutflowImpl(holder);
            return rnd.SequenceEqual(rnd2);
        }

    }


}
