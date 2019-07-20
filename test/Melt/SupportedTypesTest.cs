
namespace Melt.UnitTest
{
    using Melt.Marshaling;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using FluentAssertions;
    using System.Text;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Text.RegularExpressions;
    using System.Globalization;
    using System.Numerics;
    using System.Collections.Generic;
    using System.Collections;
    using System.Data;
    using System.Linq;

    [TestClass]
    public class SupportedTypesTest
    {
        private IMarshalingProvider p;
        public TestContext TestContext { get; set; }

        private void EquivalentToClass<T>(T data)
        {
            byte[] c = p.Construct().Attach(data);

            var d = p.Deconstruct(c);
            var wrapped = d.Detach<T>(out var len);

            data?.Should().BeEquivalentTo(wrapped);
            c.Length.Should().Be(len);

            BuildCtx(wrapped, len);
        }

        private void EquivalentToStruct<T>(T data) where T : struct
        {
            byte[] c = p.Construct().Attach(data);

            var d = p.Deconstruct(c);
            var wrapped = d.Detach<T>(out var len);

            data.Should().Be(wrapped);
            c.Length.Should().Be(len);

            BuildCtx(wrapped, len);
        }
        private void EquivalentToCollection<T>(T collection) where T : IEnumerable
        {
            byte[] bytes = p.Construct().Attach(collection);
            var wrapped = p.Deconstruct(bytes).Detach<T>(out var len);

            collection?.Should().BeEquivalentTo(wrapped);
            bytes.Length.Should().Be(len);

            BuildCtx(wrapped, len);
        }

        private void BuildCtx(object value, int len)
        {
            TestContext.WriteLine("Type: {0}", value?.GetType());
            TestContext.WriteLine("Value: {0}", value);
            TestContext.WriteLine("Length: {0}", len);
            TestContext.WriteLine("");
        }

        private DataTable table;

        [TestInitialize]
        public void Init()
        {
            p = Marshallers.Common;
            table = new DataTable("Test");
            table.Columns.Add("Test1");
            table.Columns.Add("Test2");

            for (int i = 0; i < 10; i++)
            {
                var row = table.NewRow();
                row[0] = i;
                row[1] = 1 << i;
                table.Rows.Add(row);
            }
        }

        [TestMethod]
        public void BooleanMarshallerTest() => EquivalentToStruct(true);

        [TestMethod]
        public void CharacterMarshallerTest() => EquivalentToStruct(char.MaxValue);

        [TestMethod]
        public void UnsignedByteMarshallerTest() => EquivalentToStruct(byte.MaxValue);

        [TestMethod]
        public void UnsignedShortMarshallerTest() => EquivalentToStruct(ushort.MaxValue);

        [TestMethod]
        public void UnsignedIntegerMarshallerTest() => EquivalentToStruct(uint.MaxValue);

        [TestMethod]
        public void UnsignedLongMarshallerTest() => EquivalentToStruct(ulong.MaxValue);

        [TestMethod]
        public void SignedByteMarshallerTest() => EquivalentToStruct(sbyte.MaxValue);

        [TestMethod]
        public void SignedShortMarshallerTest() => EquivalentToStruct(short.MaxValue);

        [TestMethod]
        public void SignedIntegerMarshallerTest() => EquivalentToStruct(int.MaxValue);

        [TestMethod]
        public void SignedLongMarshallerTest() => EquivalentToStruct(long.MaxValue);

        [TestMethod]
        public void DoubleMarshallerTest() => EquivalentToStruct(double.MaxValue);

        [TestMethod]
        public void SingleMarshallerTest() => EquivalentToStruct(float.MaxValue);

        [TestMethod]
        public void DecimalMarshallerTest() => EquivalentToStruct(decimal.MaxValue);

        [TestMethod]
        public void UnicodeStringMarshallerTest() => EquivalentToClass("Test");

        [TestMethod]
        public void SignedPointerMarshallerTest() => EquivalentToStruct(new IntPtr(1234567890));

        [TestMethod]
        public void UnsignedPointerMarshallerTest() => EquivalentToStruct(new UIntPtr(1234567890));

        [TestMethod]
        public void GuidMarshallerTest() => EquivalentToStruct(Guid.NewGuid());

        [TestMethod]
        public void DateTimeMarshallerTest() => EquivalentToStruct(DateTime.Now);

        [TestMethod]
        public void TimeSpanMarshallerTest() => EquivalentToStruct(DateTime.Now - DateTime.Now);

        [TestMethod]
        public void UriMarshallerTest() => EquivalentToClass(new Uri("http://test.com"));

        [TestMethod]
        public void StringBuilderMarshallerTest() => EquivalentToClass(new StringBuilder("ABC"));

        [TestMethod]
        public void IPAddressMarshallerTest1() => EquivalentToClass(IPAddress.Parse("127.0.0.1"));

        [TestMethod]
        public void IPAddressMarshallerTest2() => EquivalentToClass(IPAddress.Parse("::1"));

        [TestMethod]
        public void IPEndPointMarshallerTest1() => EquivalentToClass(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888));

        [TestMethod]
        public void IPEndPointMarshallerTest2() => EquivalentToClass(new IPEndPoint(IPAddress.Parse("::1"), 8888));

        [TestMethod]
        public void PhysicalAddressMarshallerTest() => EquivalentToClass(PhysicalAddress.Parse("112233445566"));

        [TestMethod]
        public void CultureInfoMarshallerTest() => EquivalentToClass(CultureInfo.CurrentCulture);

        [TestMethod]
        public void BigIntegerMarshallerTest() => EquivalentToStruct(BigInteger.Parse("99999999999999999999999999999999999999999999999999"));

        [TestMethod]
        public void ArrayMarshallerTest() => EquivalentToCollection(new object[] { "1", 2, 3u, 4f });

        [TestMethod]
        public void ListMarshallerTest() => EquivalentToCollection(new List<object> { "1", 2, 3u, 4f });

        [TestMethod]
        public void DictionaryMarshallerTest() => EquivalentToCollection(new Dictionary<int, object> { [0] = "1", [2] = 2, [4] = 3u, [6] = 4f });

        [TestMethod]
        public void DataColumnMarshallerTest()
        {
            var raw = table.Columns[0];

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<DataColumn>(out var len);

            Assert.AreEqual(raw.ColumnName, wrapped.ColumnName);
            Assert.AreEqual(len, bytes.Length);

            BuildCtx(wrapped, len);
        }

        [TestMethod]
        public void DataTableMarshallerTest() {

            var raw = table;

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<DataTable>(out var len);

            Assert.AreEqual(raw.TableName, wrapped.TableName);
            
            raw.Rows.Cast<DataRow>().SelectMany(x=>x.ItemArray)
                .Should().BeEquivalentTo(wrapped.Rows.Cast<DataRow>().SelectMany(x => x.ItemArray));

            Assert.AreEqual(len, bytes.Length);
            BuildCtx(wrapped, len);
        }

        [TestMethod]
        public void DataSetMarshallerTest()
        {
            var ds = new DataSet("TestSet");
            ds.Tables.Add(table);

            var raw = ds;

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<DataSet>(out var len);

            Assert.AreEqual(raw.DataSetName, wrapped.DataSetName);
            Assert.AreEqual(raw.Tables[0].TableName, wrapped.Tables[0].TableName);

            raw.Tables[0].Rows.Cast<DataRow>().SelectMany(x => x.ItemArray)
                .Should().BeEquivalentTo(wrapped.Tables[0].Rows.Cast<DataRow>().SelectMany(x => x.ItemArray));


        }

        [TestMethod]
        public void EnumerationMarshallerTest() => EquivalentToStruct(DayOfWeek.Sunday);

        [TestMethod]
        public void TupleMarshallerTest() => EquivalentToClass(Tuple.Create("1", 2, 3u, 4f));

        [TestMethod]
        public void ValueTupleMarshallerTest() => EquivalentToClass(("1", 2, 3u, 4f));

        [TestMethod]
        public void NullableMarshallerTest()
        {
            int? raw = 123;

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<int?>(out var len);

            Assert.AreEqual(raw.ToString(), wrapped.ToString());
            Assert.AreEqual(len, bytes.Length);

            BuildCtx(wrapped, len);

            raw = null;
            bytes = p.Construct().Attach(raw);
            wrapped = p.Deconstruct(bytes).Detach<int?>(out len);

            Assert.IsNull(wrapped);
            Assert.AreEqual(len, bytes.Length);

            BuildCtx(wrapped, len);
        }

        [TestMethod]
        public void ObjectMarshallerTest() => EquivalentToClass(123);

        [TestMethod]
        public void RegexMarshallerTest()
        {
            var raw = new Regex("[A-Z][a-z]+");

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<Regex>(out var len);

            Assert.IsTrue(wrapped.IsMatch("Orlys"));
            Assert.AreEqual(raw.ToString(), wrapped.ToString());
            Assert.AreEqual(len, bytes.Length);

            BuildCtx(wrapped, len);
        }

        [TestMethod]
        public void TypeMarshallerTest()
        {
            var raw = new SupportedTypesTest().GetType();

            byte[] bytes = p.Construct().Attach(raw);
            var wrapped = p.Deconstruct(bytes).Detach<Type>(out int len);
            Assert.AreEqual(raw, wrapped);
            Assert.AreEqual(len, bytes.Length);

            BuildCtx(wrapped, len);
        }
    }
}