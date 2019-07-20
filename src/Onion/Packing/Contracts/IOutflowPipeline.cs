
namespace Melt.Onion.Packing.Contracts
{
    public interface IOutflowPipeline
    {
        byte[] Outflow(byte[] bytes);
    }
}
