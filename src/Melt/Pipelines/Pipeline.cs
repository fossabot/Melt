
namespace Melt.Pipelines
{
    using System;
    using System.IO.Compression;
    using System.IO;
    using System.Collections.Generic;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class MarshalPipelineAttribute : Attribute
    {
        public MarshalPipelineAttribute(Type pipelineType)
        {
            if (pipelineType == null)
                return;

            if (pipelineType.IsSubclassOf(typeof(PipelineBase)) && !pipelineType.IsAbstract && !pipelineType.IsInterface)
            {
                var ctor = pipelineType.GetConstructor(Type.EmptyTypes);

                if (ctor.Invoke(null) is PipelineBase inst && inst.SelfValidate())
                {
                    this.Pipeline = inst;
                    this.NotSupported = false;
                    return;
                }
            }

        }

        public MarshalPipelineAttribute(Type pipelineType, object arg, params object[] argv)
        {
            if (pipelineType == null)
                return;

            var args = new object[argv.Length + 1];
            args[0] = arg;
            Array.Copy(argv, 0, args, 1, argv.Length);


            if (pipelineType.IsSubclassOf(typeof(PipelineBase)) && !pipelineType.IsAbstract && !pipelineType.IsInterface)
            {
                var ctors = pipelineType.GetConstructors();
                foreach (var ctor in ctors)
                {
                    var ps = ctor.GetParameters();
                    if (ps.Length == args.Length)
                    {
                        var flag = false;
                        for (int i = 0; i < args.Length; i++)
                        {
                            if (args[i] == null)
                                continue;
                            if (args[i].GetType() != ps[i].ParameterType)
                            {
                                flag = true;
                                break;
                            }
                        }

                        if (flag)
                            continue;
                        else if (ctor.Invoke(null) is PipelineBase inst && inst.SelfValidate())
                        {
                            this.Pipeline = inst;
                            this.NotSupported = false;
                            return;
                        }
                    }
                }
            }
        }

        public bool NotSupported { get; } = true;

        public PipelineBase Pipeline { get; }
    }
    public class GZipPipeline : PipelineBase
    {
        internal protected override byte[] Encode(byte[] bytes)
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

        internal protected override byte[] Decode(byte[] bytes)
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

    public abstract class PipelineBase
    {
        internal protected abstract byte[] Encode(byte[] bytes);

        internal protected abstract byte[] Decode(byte[] bytes);


        internal bool SelfValidate()
        {
            var rnd = Guid.NewGuid().ToByteArray();
            var holder = this.Encode(rnd);
            var rnd2 = this.Decode(holder);
            return rnd.AsSpan().SequenceEqual(rnd2.AsSpan());
        }
    }
}
