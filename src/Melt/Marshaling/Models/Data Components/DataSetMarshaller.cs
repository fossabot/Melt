
namespace Melt.Marshaling.Models
{
    using Melt.Marshaling.Contracts;
    using System.Data;
    using System.Linq;

    public sealed class DataSetMarshaller : ReferenceTypeMarshaller<DataSet>
    {
        protected override DataSet OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            var d = pool.Deconstruct(bytes);
            var dataSetName = d.Detach<string>();
            var dataSet = new DataSet(dataSetName);
            var tables = d.Detach<DataTable[]>(out length);
            dataSet.Tables.AddRange(tables);
            return dataSet;
        }

        protected override byte[] OnConvertToBytes(DataSet dataSet, IMarshalingProvider pool)
        {
            var c = pool.Construct();
            c.Attach(dataSet.DataSetName);
            var tables = dataSet.Tables.Cast<DataTable>().ToArray();
            return c.Attach(tables);
        }
    }
}
