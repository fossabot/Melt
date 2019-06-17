
namespace Melt
{
    using System;
    using System.Data;

    public sealed class DataColumnConverter : ReferenceTypeConverter<DataColumn>
    {
        protected override DataColumn OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var columnName = d.Detach<string>();
            var dataType = d.Detach<Type>();
            var expr = d.Detach<string>();
            var columnMapping = (MappingType)d.Detach<byte>();
            var column = new DataColumn(columnName, dataType, expr, columnMapping)
            {
                AllowDBNull = d.Detach<bool>(),
                AutoIncrement = d.Detach<bool>(),
                AutoIncrementSeed = d.Detach<long>(),
                AutoIncrementStep = d.Detach<long>(),
                Caption = d.Detach<string>(),
                DateTimeMode = (DataSetDateTime)d.Detach<byte>(),
                MaxLength = d.Detach<int>(),
                Namespace = d.Detach<string>(),
                ReadOnly = d.Detach<bool>(),
                Unique = d.Detach<bool>(out length)
            };
            return column;
        }
        protected override byte[] OnConvertToBytes(DataColumn column, ConverterPool pool)
        {
            var c = pool.Construct()
                .Attach(column.ColumnName)
                .Attach(column.DataType)
                .Attach(column.Expression)
                .Attach((byte)column.ColumnMapping)

                .Attach(column.AllowDBNull)
                .Attach(column.AutoIncrement)
                .Attach(column.AutoIncrementSeed)
                .Attach(column.AutoIncrementStep)
                .Attach(column.Caption)
                .Attach((byte)column.DateTimeMode)
                .Attach(column.MaxLength)
                .Attach(column.Namespace)
                .Attach(column.ReadOnly)
                .Attach(column.Unique);
            return c;
        }
    }
}
