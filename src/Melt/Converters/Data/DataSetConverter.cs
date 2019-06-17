﻿
namespace Melt
{
    using System.Data;
    using System.Linq;

    public sealed class DataSetConverter : ReferenceTypeConverter<DataSet>
    {
        protected override DataSet OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var dataSetName = d.Detach<string>();
            var dataSet = new DataSet(dataSetName);
            var tables = d.Detach<DataTable[]>(out length);
            dataSet.Tables.AddRange(tables);
            return dataSet;
        }

        protected override byte[] OnConvertToBytes(DataSet dataSet, ConverterPool pool)
        {
            var c = pool.Construct();
            c.Attach(dataSet.DataSetName);
            var tables = dataSet.Tables.Cast<DataTable>().ToArray();
            return c.Attach(tables);
        }
    }
}
