
namespace Melt.Onion.Packing.Internal
{
    using System.IO;

    internal static class PipelineUtilities
    {
        // from https://stackoverflow.com/questions/7343465/compression-decompression-string-with-c-sharp
        internal static void CopyTo(Stream src, Stream dest, int bufferSz = 4096)
        {
            var bytes = new byte[bufferSz];
            var cnt = default(int);
            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
    }
}
