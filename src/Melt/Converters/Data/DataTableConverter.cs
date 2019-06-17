
namespace Melt
{
    using System.Data;
    using System.Linq;

    public sealed class DataTableConverter : ReferenceTypeConverter<DataTable>
    {
        protected override DataTable OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var tableName = d.Detach<string>();
            var @namespace = d.Detach<string>();
            var table = new DataTable(tableName, @namespace);

            var columns = d.Detach<DataColumn[]>();
            foreach (var col in columns)
            {
                table.Columns.Add(col);
            }

            var rowCount = d.Detach<int>(out length);
            var colCount = columns.Length;
            if (rowCount == 0)
                goto Leave;

            if (rowCount != 1)
                for (int rowIndex = 0; rowIndex < rowCount - 1; rowIndex++)
                {
                    var row = table.NewRow();
                    foreach (var col in columns)
                    {
                        row[col] = d.Detach(col.DataType);
                    }
                    table.Rows.Add(row);
                }

            var lastRow = table.NewRow();
            for (int columnIndex = 0; columnIndex < columns.Length-1; columnIndex++)
            {
                var column = columns[columnIndex];
                lastRow[column] = d.Detach(column.DataType);
            }
            var lastColumn = columns[columns.Length - 1];
            lastRow[lastColumn] = d.Detach(lastColumn.DataType, out length);
            table.Rows.Add(lastRow);

            Leave:
            table.AcceptChanges();
            return table;
        }

        protected override byte[] OnConvertToBytes(DataTable table, ConverterPool pool)
        {
            var c = pool.Construct();
            c.Attach(table.TableName);
            c.Attach(table.Namespace);

            var columns = table.Columns.Cast<DataColumn>().ToArray();
            c.Attach(columns);

            var rows = table.Rows.Cast<DataRow>().ToArray();
            c.Attach(rows.Length);

            foreach (var row in rows)
            {
                foreach (var col in columns)
                {
                    var item = row[col];
                    c.Attach(col.DataType, item);
                }
            }
            return c;
        }
    }
}
