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
| ```System.Guid``` | ```GuidConverter``` |
| ```System.DateTime``` | ```DateTimeConverter``` | ```SignedLongConverter``` 
| ```System.String``` | ```UnicodeStringConverter``` | ```SignedLongConverter``` ```SignedIntegerConverter```
| ```System.Type``` | ```TypeConverter``` | ```UnicodeStringConverter```
| ```System.Uri``` | ```UriConverter``` | ```UnicodeStringConverter```
| ```System.Text.StringBuilder``` | ```StringBuilderConverter``` | ```UnicodeStringConverter```
| ```System.Enum``` | ```EnumerationConverter<TEnum> where TEnum : Enum``` | ```UnsignedByteConverter``` ```UnsignedShortConverter``` ```UnsignedIntegerConverter``` ```UnsignedLongConverter``` ```SignedByteConverter``` ```SignedShortConverter``` ```SignedIntegerConverter``` ```SignedLongConverter``` 
| ```System.Net.IPAddress``` | ```IPAddressConverter``` | 
| ```System.Net.IPEndPoint```| ```IPEndPointConverter```|```IPAddressConverter``` ```SignedIntegerConverter```
| ```System.Object``` | ```ObjectConverter``` | ```*```

[回首頁](../../../)
