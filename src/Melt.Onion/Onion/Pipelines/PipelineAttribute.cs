
namespace Melt.Onion.Pipeline
{
    using Melt.Onion.Packing.Contracts;
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class PipelineAttribute : Attribute
    {
        public PipelineAttribute(Type pipelineType)
        {
            if (pipelineType == null)
                return;

            if (pipelineType.IsSubclassOf(typeof(PipelineBase)) && !pipelineType.IsAbstract && !pipelineType.IsInterface)
            {
                var ctor = pipelineType.GetConstructor(Type.EmptyTypes);

                if (ctor.Invoke(null) is PipelineBase inst && inst.SelfValidate())
                {
                    this.Pipeline = inst;
                    this.IsInvaildAttribute = false;
                    return;
                }
            }

        }

        public PipelineAttribute(Type pipelineType, object arg, params object[] argv)
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
                            this.IsInvaildAttribute = false;
                            return;
                        }
                    }
                }
            }
        }

        public bool IsInvaildAttribute { get; } = true;

        public PipelineBase Pipeline { get; }
    }
}
