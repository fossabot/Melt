
namespace Melt.Dev
{
    using Melt.CognitiveServices;
    using Melt.CognitiveServices.Pipeline;
    using Melt.Marshaling;
    using Melt.Marshaling.Contracts;
    using Melt.Marshaling.Entity;
    using Melt.Marshaling.Extensions;
    using System;


    class Program
    {
         enum MyEnum
        {
            A = -100,
            D = 66
        }

        static void Main(string[] args)
        {
            var s = Marshallers.Common;
            s.Install<TupleMarshaller>();
            var k = Tuple.Create(10,20);

            var v = s.Construct().Attach(k);

            var j = s.Deconstruct(v).Detach<Tuple<int, int>>();

            Console.WriteLine(j);
            Exit();
        }
        
        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
