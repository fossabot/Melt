# Melt
##### [English](./readme.en-us.md)

#### 來由
> 覺得 .Net 內建的封送處理機制 (Marshaling) 很不太好用  
> 所以就花了一點時間自己造了一套處理該機制的類別庫 - **Melt**

#### 支援類型一覽

##### 基本
| 編組器 | 詳細資料
| --- | --- |
| ```MarshallerBase<T>``` | 提供編組器的基底類別，此類別為抽象類別。
| ```ValueTypeMarshaller<TStruct>``` | 提供對 ```struct``` (System.ValueType) 的部分實作，此類別為抽象類別。
| ```ReferenceTypeMarshaller<TClass>``` | 提供對 ```class``` 的部分實作，此類別為抽象類別。
| ```ContractTypeMarshaller<TInterface>``` | 提供對 ```interface``` 的部分實作，此類別為抽象類別。


| 類型 | 編組器 | 依賴於
| --- | --- | --- |
| ```System.Boolean``` | ```BooleanMarshaller``` |
| ```System.Char``` | ```CharacterMarshaller``` |
| ```System.Byte``` | ```UnsignedByteMarshaller``` |
| ```System.UInt16``` | ```UnsignedShortMarshaller``` |
| ```System.UInt32``` | ```UnsignedIntegerMarshaller``` |
| ```System.UInt64``` | ```UnsignedLongMarshaller``` |
| ```System.SByte``` | ```SignedByteMarshaller``` |
| ```System.Int16``` | ```SignedShortMarshaller``` |
| ```System.Int32``` | ```SignedIntegerMarshaller``` |
| ```System.Int64``` | ```SignedLongMarshaller``` |
| ```System.Double``` | ```DoubleMarshaller``` |
| ```System.Single``` | ```SingleMarshaller``` |
| ```System.Decimal``` | ```DecimalMarshaller``` |
| ```System.String``` | ```UnicodeStringMarshaller``` | ```SignedLongMarshaller``` ```SignedIntegerMarshaller```
| ```System.IntPtr``` | ```SignedPointerMarshaller``` | ```SignedIntegerMarshaller```
| ```System.UIntPtr``` | ```UnsignedPointerMarshaller``` | ```SignedIntegerMarshaller```
| ```System.Guid``` | ```GuidMarshaller``` |
| ```System.DateTime``` | ```DateTimeMarshaller``` | ```SignedLongMarshaller``` 
| ```System.TimeSpan``` | ```TimeSpanMarshaller``` | ```SignedLongMarshaller``` 
| ```System.Uri``` | ```UriMarshaller``` | ```UnicodeStringMarshaller```
| ```System.Text.StringBuilder``` | ```StringBuilderMarshaller``` | ```UnicodeStringMarshaller```
| ```System.Net.IPAddress``` | ```IPAddressMarshaller``` | ```SignedIntegerMarshaller```
| ```System.Net.IPEndPoint``` | ```IPEndPointMarshaller```| ```IPAddressMarshaller``` ```SignedIntegerMarshaller```
| ```System.Text.RegularExpression.Regex``` | ```RegexMarshaller``` | ```SignedIntegerMarshaller``` ```SignedShortMarshaller``` ```TimeSpanMarshaller``` ```UnicodeStringMarshaller```
| ```System.Globalization.CultureInfo``` | ```CultureInfoMarshaller``` | ```SignedIntegerMarshaller``` 
| ```System.Array``` | ```ArrayMarshaller``` | ```SignedIntegerMarshaller``` ```TypeMarshaller``` ```ObjectMarshaller```
| ```System.Collection.IList``` | ```ListMarshaller``` | ```SignedIntegerMarshaller``` ```SignedByteMarshaller``` ```TypeMarshaller``` ```ObjectMarshaller```
| ```System.Collection.IDictionary``` | ```DictionaryMarshaller``` | ```SignedIntegerMarshaller``` ```SignedByteMarshaller``` ```TypeMarshaller``` ```ObjectMarshaller```
| ```System.Data.DataColumn``` | ```DataColumnMarshaller``` | ```TypeMarshaller``` ```UnicodeStringMarshaller```
| ```System.Data.DataTable``` | ```DataTableMarshaller``` | ```DataColumnMarshaller``` ```ArrayMarshaller``` ```ObjectMarshaller```
| ```System.Data.DataSet``` | ```DataSetMarshaller``` | ```DataTableMarshaller``` ```ArrayMarshaller```
| ```System.Object``` | ```ObjectMarshaller``` | ```*```
| ```System.Type``` | ```TypeMarshaller``` | ```UnicodeStringMarshaller```
| ```System.Enum``` | ```EnumerationMarshaller``` | ```TypeMarshaller``` ```ObjectMarshaller``` 
| ```System.Nullable<TStruct>``` | ```NullableMarshaller``` | ```ObjectMarshaller```
| ```System.ValueTuple<T1...Tn>``` | ```ValueTupleMarshaller``` | ```ObjectMarshaller``` ```SignedIntegerMarshaller```
| ```System.Enum``` | ```EnumerationMarshaller<TEnum> where TEnum : Enum``` | ```UnsignedByteMarshaller``` ```UnsignedShortMarshaller``` ```UnsignedIntegerMarshaller``` ```UnsignedLongMarshaller``` ```SignedByteMarshaller``` ```SignedShortMarshaller``` ```SignedIntegerMarshaller``` ```SignedLongMarshaller``` 

 
[回首頁](../../../)
