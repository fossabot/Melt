
namespace Melt.Onion.Packing
{
    using Melt.Onion.Packing.Contracts;
    using System.Collections.Generic;

    public sealed class Unpack
    {
        private readonly Stack<IOutflowPipeline> _outflows;

        public Unpack()
        {
            _outflows = new Stack<IOutflowPipeline>();
        }

        public Unpack Install(IOutflowPipeline outflow)
        {
            _outflows.Push(outflow);
            return this;
        }

        public byte[] Outflow(byte[] bytes)
        {
            while (_outflows.TryPop(out var outflow))
            {
                bytes = outflow.Outflow(bytes);
            }
            return bytes;
        }
    }


}
