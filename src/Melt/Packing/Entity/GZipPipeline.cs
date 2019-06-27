
namespace Melt.Packing.Entity
{
    using System.IO.Compression;
    using System.IO;
    using Melt.Packing.Contracts;
    using Melt.Packing.Internal;

    public class GZipPipeline : PipelineBase
    {
        protected override byte[] InflowImpl(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
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
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    PipelineUtilities.CopyTo(gs, mso);
                }

                return mso.ToArray();
            }
        }
    }
}
