
namespace Melt.Onion.Packing.Entity
{
    using System.IO.Compression;
    using System.IO;
    using Melt.Onion.Packing.Contracts;
    using Melt.Onion.Packing.Internal;

    public class DeflatePipeline : PipelineBase
    {
        protected override byte[] InflowImpl(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new DeflateStream(mso, CompressionMode.Compress))
                {
                    PipelineUtilities.CopyTo(msi, gs);
                }

                return mso.ToArray();
            }
        }

        protected override byte[] OutflowImpl(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new DeflateStream(msi, CompressionMode.Decompress))
                {
                    PipelineUtilities.CopyTo(gs, mso);
                }

                return mso.ToArray();
            }
        }


    }
}
