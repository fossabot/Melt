// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Internal
{
    internal sealed class ConstructObjectView
    {
        private readonly Construct _construct;

        public ConstructObjectView(Construct construct)
        {
            this._construct = construct;
            this.BinaryStream = (byte[])construct;
        }

        public byte[] BinaryStream { get; }

    }
}