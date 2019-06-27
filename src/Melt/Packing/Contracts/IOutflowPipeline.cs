
namespace Melt.Packing.Contracts
{
    public interface IOutflowPipeline
    {
        byte[] Outflow(byte[] bytes);
    }
}
