# Melt
##### [中文](./readme.zh-tw.md)

#### Motivation
> The .Net framework contains Marshaling mechanism to convert the object to the binary sequence.  
> But that is very difficult and complicated to use. (Maybe just me, HAHA)  
> So I spent some time developing a new library - **Melt**.

#### Supported Types

| Type | Marshaller | Dependency
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

 
[Back to home](../../../)