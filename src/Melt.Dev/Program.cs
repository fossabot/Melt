
namespace Melt.Dev
{
    using BenchmarkDotNet.Running;
    using Melt.CognitiveServices;
    using Melt.CognitiveServices.Pipeline;
    using Melt.Marshaling.Contracts;
    using Melt.Marshaling.Entity;
    using System;



    class Program
    {

        static void Main(string[] args)
        {
            var summery = BenchmarkRunner.Run<Bm>();

            var s = new Span<byte>();

            Console.WriteLine(s.ToArray());

            Exit();
        }
        
        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
