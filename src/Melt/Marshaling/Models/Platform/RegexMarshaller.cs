// Author: Orlys
// Github: https://github.com/Orlys

namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System;
    using System.Text.RegularExpressions;

    public sealed class RegexMarshaller : ReferenceTypeMarshaller<Regex>
    {
        protected override Regex OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            var d = pool.Deconstruct(bytes);
            var options = (RegexOptions)d.Detach<short>();
            var timeSpan = d.Detach<TimeSpan>();
            var regex = d.Detach<string>(out length);
            var regexObject = new Regex(regex, options, timeSpan);
            return regexObject;
        }

        protected override byte[] OnConvertToBytes(Regex graph, IMarshalingProvider pool)
        {
            return pool.Construct().Attach((short)graph.Options).Attach(graph.MatchTimeout).Attach(graph.ToString());
        }
    }

}