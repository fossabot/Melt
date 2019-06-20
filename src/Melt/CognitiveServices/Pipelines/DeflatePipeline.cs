﻿
namespace Melt.CognitiveServices.Pipeline
{
    using System.IO.Compression;
    using System.IO;

    public class DeflatePipeline : PipelineBase
    {
        internal protected override byte[] Encode(byte[] bytes)
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

        internal protected override byte[] Decode(byte[] bytes)
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