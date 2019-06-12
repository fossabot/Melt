# Melt
##### [中文](./readme.zh-tw.md)

#### Movation
> The .Net framework contains Marshaling mechanism to convert the object to the binary sequence.  
> But that is very difficult and complicated to use. (Maybe just me, HAHA)
> So I spent some time developing a new library.

#### Supported Types

| Type | Converter | Dependency
| --- | --- | :---: |
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
| ```System.String``` | ```UnicodeStringConverter``` |
| ```System.Guid``` | ```GuidConverter``` |
| ```System.DateTime``` | ```DateTimeConverter``` | ```SignedLongConverter```
| ```System.Type``` | ```TypeConverter``` | ```UnicodeStringConverter```
| ```System.Uri``` | ```UriConverter``` | ```UnicodeStringConverter```
| ```System.Text.StringBuilder``` | ```StringBuilderConverter``` | ```UnicodeStringConverter```
| ```System.Object``` | ```ObjectConverter``` | *

[Back to home](../../../)