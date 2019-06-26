# Melt
##### [中文](./readme.zh-tw.md)

#### Motivation
> The .Net framework contains Marshaling mechanism to convert the object to the binary sequence.  
> But that is very difficult and complicated to use. (Maybe just me, HAHA)  
> So I spent some time developing a new library - **Melt**.

#### Supported Types

	| Type | Marshaller | Dependency
	| --- | --- | 
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
    | ```System.String``` | ```UnicodeStringMarshaller``` | 
    | ```System.IntPtr``` | ```SignedPointerMarshaller``` |
    | ```System.UIntPtr``` | ```UnsignedPointerMarshaller``` |
    | ```System.Guid``` | ```GuidMarshaller``` |
    | ```System.DateTime``` | ```DateTimeMarshaller``` |
    | ```System.TimeSpan``` | ```TimeSpanMarshaller``` |
    | ```System.Uri``` | ```UriMarshaller``` |
    | ```System.Text.StringBuilder``` | ```StringBuilderMarshaller``` |
    | ```System.Net.IPAddress``` | ```IPAddressMarshaller``` |
    | ```System.Net.IPEndPoint``` | ```IPEndPointMarshaller```|
    | ```System.Text.RegularExpression.Regex``` | ```RegexMarshaller``` |
    | ```System.Globalization.CultureInfo``` | ```CultureInfoMarshaller``` |
    | ```System.Numerics.BigInteger``` | ```BigIntegerMarshaller``` |
	| ```System.Array``` | ```ArrayMarshaller``` |
    | ```System.Collection.IList``` | ```ListMarshaller``` |
    | ```System.Collection.IDictionary``` | ```DictionaryMarshaller``` |
    | ```System.Data.DataColumn``` | ```DataColumnMarshaller``` | 
    | ```System.Data.DataTable``` | ```DataTableMarshaller``` | 
    | ```System.Data.DataSet``` | ```DataSetMarshaller``` |
    | ```System.Object``` | ```ObjectMarshaller``` |
    | ```System.Type``` | ```TypeMarshaller``` |
    | ```System.Enum``` | ```EnumerationMarshaller``` |
    | ```System.Nullable<TStruct>``` | ```NullableMarshaller``` |
    | ```System.Tuple<T1...Tn>``` | ```TupleMarshaller``` |
    | ```System.ValueTuple<T1...Tn>``` | ```ValueTupleMarshaller``` |
    | ```System.Enum``` | ```EnumerationMarshaller<TEnum> where TEnum : Enum``` | 

 
[Back to home](../../../)