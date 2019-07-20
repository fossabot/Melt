
namespace Melt.Dev
{
    using BenchmarkDotNet.Running;
    using Melt.Packing;
    using Melt.Packing.Entity;
    using System;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using Marshallers = Melt.Marshaling.Marshallers;

    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var s = new UdpClient(600, AddressFamily.InterNetworkV6);
                var comm = Marshallers.Common;
                while (true)
                {
                    var client = await s.ReceiveAsync();
                    var m = client.Buffer;
                    Console.WriteLine(m.Length);
                    var up = new Unpack();
                    up.Install(new GZipPipeline());
                    m = up.Outflow(m);
                    var c = comm.Deconstruct(m);
                    var f = c.Detach<byte>();
                    if (f == 0xF7)
                    {
                        Console.WriteLine(client.RemoteEndPoint);
                        Console.WriteLine("connected");
                    }
                    else if (f == 0xCE)
                    {
                        Console.WriteLine("disconnect");
                        return;
                    }
                    else
                        Console.WriteLine("unknown");

                }
            });
            Task.Delay(200).Wait();

            var cx = new UdpClient(751, AddressFamily.InterNetworkV6);
            cx.Connect("localhost", 600);
            var p = new Pack();
            p.Install(new GZipPipeline());
            var data = p.Inflow(new byte[] { 0xF7 });

            cx.Send(data, data.Length);

            Exit();

            var r = default(BenchmarkDotNet.Reports.Summary);
            r = BenchmarkRunner.Run<Bm.ConstructBm>();
            r = BenchmarkRunner.Run<Bm.DeconstructBm>();

            Exit();
        }
        
        static void Exit()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
