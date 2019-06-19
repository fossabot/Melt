// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Internal
{
    using Melt.Marshaling;

    internal sealed class BinaryStreamView
    {
        public BinaryStreamView(Construct construct)
        {
            this.BinaryStream = construct;
        }

        public byte[] BinaryStream { get; }

    }
}