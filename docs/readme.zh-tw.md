# Melt
##### [English](./readme.en-us.md)

#### 來由
> 覺得 .Net 內建的封送處理機制 (Marshaling) 很不太好用  
> 所以就花了一點時間自己造了一套處理該機制的類別庫 - **Melt**

#### 支援類型一覽
| 類型 | 轉換器 | 依賴於
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
| ```System.String``` | ```UnicodeStringConverter``` | ```SignedLongConverter``` ```SignedIntegerConverter```
| ```System.IntPtr``` | ```SignedPointerConverter``` | ```SignedLongConverter```
| ```System.UIntPtr``` | ```UnsignedPointerConverter``` | ```SignedLongConverter```
| ```System.Guid``` | ```GuidConverter``` |
| ```System.DateTime``` | ```DateTimeConverter``` | ```SignedLongConverter``` 
| ```System.TimeSpan``` | ```TimeSpanConverter``` | ```SignedLongConverter``` 
| ```System.Uri``` | ```UriConverter``` | ```UnicodeStringConverter```
| ```System.Text.StringBuilder``` | ```StringBuilderConverter``` | ```UnicodeStringConverter```
| ```System.Net.IPAddress``` | ```IPAddressConverter``` | ```SignedIntegerConverter```
| ```System.Net.IPEndPoint``` | ```IPEndPointConverter```| ```IPAddressConverter``` ```SignedIntegerConverter```
| ```System.Text.RegularExpression.Regex``` | ```RegexConverter``` | ```SignedIntegerConverter``` ```SignedShortConverter``` ```TimeSpanConverter``` ```UnicodeStringConverter```
| ```System.Globalization.CultureInfo``` | ```CultureInfoConverter``` | ```SignedIntegerConverter``` 
| ```System.Array``` | ```ArrayConverter``` | ```SignedIntegerConverter``` ```TypeConverter``` ```ObjectConverter```
| ```System.Collection.IList``` | ```ListConverter``` | ```SignedIntegerConverter``` ```SignedByteConverter``` ```TypeConverter``` ```ObjectConverter```
| ```System.Collection.IDictionary``` | ```DictionaryConverter``` | ```SignedIntegerConverter``` ```SignedByteConverter``` ```TypeConverter``` ```ObjectConverter```
| <del>```System.Collection.ICollection```</del> | <del>```CollectionConverter```</del> | <del>```UnsignedByteConverter```</del> <del>```ObjectConverter```</del> <del>```SignedIntegerConverter```</del> <del>```TypeConverter```</del> 
| ```System.Data.DataColumn``` | ```DataColumnConverter``` | ```TypeConverter``` ```UnicodeStringConverter```
| ```System.Data.DataTable``` | ```DataTableConverter``` | ```DataColumnConverter``` ```ArrayConverter``` ```ObjectConverter```
| ```System.Data.DataSet``` | ```DataSetConverter``` | ```DataTableConverter``` ```ArrayConverter```
| ```System.Object``` | ```ObjectConverter``` | ```*```
| ```System.Type``` | ```TypeConverter``` | ```UnicodeStringConverter```
| ```System.Enum``` | ```EnumerationConverter``` | ```TypeConverter``` ```ObjectConverter``` 
| ```System.ValueTuple<T1...Tn>``` | ```ValueTupleConverter``` | ```ObjectConverter``` ```SignedIntegerConverter```
| ```System.Enum``` | ```EnumerationConverter<TEnum> where TEnum : Enum``` | ```UnsignedByteConverter``` ```UnsignedShortConverter``` ```UnsignedIntegerConverter``` ```UnsignedLongConverter``` ```SignedByteConverter``` ```SignedShortConverter``` ```SignedIntegerConverter``` ```SignedLongConverter``` 


[回首頁](../../../)
