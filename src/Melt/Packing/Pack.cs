
namespace Melt.Packing
{
    using Melt.Marshaling;
    using Melt.Packing.Contracts;
    using System.Collections.Generic;
    using System.Text;

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
