# Melt
##### [中文](https://github.com/Orlys/Melt/blob/master/docs/readme.zh-tw.md)

#### Motivation
> The .Net framework contains Marshaling mechanism to convert the object to the binary sequence.  
> But that is very difficult and complicated to use. (Maybe just me, HAHA)  
> So I spent some time developing a new library - **Melt**.

#### Supported Types

| Type | Converter | Dependency
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
| ```System.Enum``` | ```EnumerationConverter<TEnum> where TEnum : Enum``` | ```UnsignedByteConverter``` ```UnsignedShortConverter``` ```UnsignedIntegerConverter``` ```UnsignedLongConverter``` ```SignedByteConverter``` ```SignedShortConverter``` ```SignedIntegerConverter``` ```SignedLongConverter``` 
| ```System.Net.IPAddress``` | ```IPAddressConverter``` | ```SignedIntegerConverter```
| ```System.Net.IPEndPoint``` | ```IPEndPointConverter```| ```IPAddressConverter``` ```SignedIntegerConverter```
| ```System.Text.RegularExpression.Regex``` | ```RegexConverter``` | ```SignedIntegerConverter``` ```SignedShortConverter``` ```TimeSpanConverter``` ```UnicodeStringConverter```
| ```System.Array``` | ```ArrayConverter``` | ```SignedIntegerConverter``` ```TypeConverter``` ```ObjectConverter```
| ```System.Collection.IList``` | ```ListConverter``` | ```SignedIntegerConverter``` ```SignedByteConverter``` ```TypeConverter``` ```ObjectConverter```
| <del>```System.Collection.ICollection```</del> | <del>```CollectionConverter```</del> | <del>```UnsignedByteConverter``` ```ObjectConverter``` ```SignedIntegerConverter``` ```TypeConverter```</del> 
| ```System.Object``` | ```ObjectConverter``` | ```*```

[Back to home](https://github.com/Orlys/Melt)