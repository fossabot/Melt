# Melt
##### [English](./readme.en-us.md)

#### �ӥ�
> ı�o .Net ���ت��ʰe�B�z���� (Marshaling) �ܤ��Ӧn��  
> �ҥH�N��F�@�I�ɶ��ۤv�y�F�@�M�B�z�Ӿ�����O�w - **Melt**

#### �䴩�����@��
##### �ݹ�@
- [ ] DataSet
- [ ] DataTable
- [ ] ISerializable 
- [ ] ITuple
- [x] IDictionary
- [ ] ISet
- [ ] Exception

##### �w��@
| ���� | �ഫ�� | �̿��
| --- | --- | --- |
| --- | --- | --- |
| ```System.Boolean``` | ```BooleanConverter``` |
| ```System.Char``` | ```CharacterConverter``` |
| ```System.Byte``` | ```UnsignedByteConverter``` |
| ```System.UInt16``` | ```UnsignedShortConverter``` |
| ```System.UInt32``` | ```UnsignedIntegerConverter``` |
| ```System.UInt64``` | ```UnsignedLongConverter``` |
| ```System.SByte``` | ```SignedByteConverter``` |
| ```System.Int16``` | ```SignedShortConverter``` |
| ```System.Int32``` | ```SignedIntegerConverter``` |
| ```System.Int64``` | ```SignedLongConverter``` |
| ```System.Double``` | ```DoubleConverter``` |
| ```System.Single``` | ```SingleConverter``` |
| ```System.Decimal``` | ```DecimalConverter``` |
| ```System.Guid``` | ```GuidConverter``` |
| ```System.DateTime``` | ```DateTimeConverter``` | ```SignedLongConverter``` 
| ```System.TimeSpan``` | ```TimeSpanConverter``` | ```SignedLongConverter``` 
| ```System.String``` | ```UnicodeStringConverter``` | ```SignedLongConverter``` ```SignedIntegerConverter```
| ```System.Type``` | ```TypeConverter``` | ```UnicodeStringConverter```
| ```System.Uri``` | ```UriConverter``` | ```UnicodeStringConverter```
| ```System.Text.StringBuilder``` | ```StringBuilderConverter``` | ```UnicodeStringConverter```
| ```System.Enum``` | ```EnumerationConverter``` | ```TypeConverter``` ```ObjectConverter``` 
| ```System.Enum``` | ```EnumerationConverter<TEnum> where TEnum : Enum``` | ```UnsignedByteConverter``` ```UnsignedShortConverter``` ```UnsignedIntegerConverter``` ```UnsignedLongConverter``` ```SignedByteConverter``` ```SignedShortConverter``` ```SignedIntegerConverter``` ```SignedLongConverter``` 
| ```System.Net.IPAddress``` | ```IPAddressConverter``` | ```SignedIntegerConverter```
| ```System.Net.IPEndPoint``` | ```IPEndPointConverter```| ```IPAddressConverter``` ```SignedIntegerConverter```
| ```System.Text.RegularExpression.Regex``` | ```RegexConverter``` | ```SignedIntegerConverter``` ```SignedShortConverter``` ```TimeSpanConverter``` ```UnicodeStringConverter```
| ```System.Array``` | ```ArrayConverter``` | ```SignedIntegerConverter``` ```TypeConverter``` ```ObjectConverter```
| ```System.Collection.IList``` | ```ListConverter``` | ```SignedIntegerConverter``` ```SignedByteConverter``` ```TypeConverter``` ```ObjectConverter```
| <del>```System.Collection.ICollection```</del> | <del>```CollectionConverter```</del> | <del>```UnsignedByteConverter```</del> <del>```ObjectConverter```</del> <del>```SignedIntegerConverter```</del> <del>```TypeConverter```</del> 
| ```System.Object``` | ```ObjectConverter``` | ```*```


[�^����](../../../)
