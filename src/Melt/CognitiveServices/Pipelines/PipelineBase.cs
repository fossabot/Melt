
namespace Melt.CognitiveServices.Pipeline
{
    using System;
    using System.Collections.Generic;

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
