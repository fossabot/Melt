
namespace Melt.Onion.Packing
{
    using Melt.Onion.Packing.Contracts;
    using System.Collections.Generic;

    public sealed class Pack
    {
        private readonly Queue<IInflowPipeline> _inflows;

        public Pack()
        {
            _inflows = new Queue<IInflowPipeline>();
        }

        public Pack Install(IInflowPipeline inflow)
        {
            _inflows.Enqueue(inflow);
            return this;
        }

        public byte[] Inflow(byte[] bytes)
        {
            while (_inflows.TryDequeue(out var inflow))
            {
                bytes = inflow.Inflow(bytes);
            }
            return bytes;
        }
    }
}
