# Melt
##### [English](./readme.en-us.md)

#### 概要

覺得 .Net 內建的封送處理機制 (Marshaling) 對類別、結構中的欄位定義較為繁瑣  
所以就花了一點時間自己造了一套處理該機制的類別庫 - **Melt**  


### 基本使用方式
- #### 前提
  函式庫內已有預先實作 ```IMarshalingProvider``` 介面的編組服務提供者物件 ```Marshallers.Common```。  
  此實體已預先安裝部分預先實作之編組器作為基本轉換的依據，詳細請看[**這裡**](#已實作的支援類型及對應之編組器一覽)。  
  
  #### 編組範例
  ```csharp
  var c = Marshallers.Common.Construct();
  var data1 = ("value-tuple", 'char', 1m, 2u, 3f, 4.0, 5, (byte)6);
  var data2 = 123;
  var bytes = c.Attach(data1).Attach(data2);
  ```

  #### 反編組範例
  ```csharp
  var d = Marshallers.Common.Deconstruct(bytes);
  var data1 = d.Detach<(string String, char Character, decimal Decimal, uint UnsignedInteger, float Single, double Double, int Integer, byte Byte)>();
  var data2 = d.Detach<int>();
  ```


### 編組器
- #### 實作自訂義編組器
  所有編組器都實作 ```IMarshaller``` 介面。  
  一般情況下，繼承以下三個編組器的其一即可滿足基本需求。
  - ```ValueTypeMarshaller<TStruct>``` 抽象類別  
  - ```ReferenceTypeMarshaller<TClass>``` 抽象類別  
  - ```ContractTypeMarshaller<TInterface> ``` 抽象類別
 

- #### 進階基本編組器
  若你想更進一步的自訂編組方法，可以使用以下兩個編組器合約  
  - ```IMarshaller``` 介面
  - ```MarshallerBase<T>``` 基底抽象類別

  從源頭撰寫你要的編組器，並使用 ```IMarshalingProvider.Install``` 方法將你的編組器安裝到編組服務提供者的實體中
   
- #### 基本編組器一覽
  下列編組器皆位於 ```Melt.Marshaling.Contracts``` 命名空間中
   
    | 編組器 | 詳細資料
    | --- | --- |
    | ```IMarshaller``` | 編組器介面，所有編組器必須實作此介面。
    | ```MarshallerBase<T>``` | 提供編組器基本實作的基底類別，此類別為抽象類別。
    | ```ValueTypeMarshaller<TStruct>``` | 提供對 ```struct``` (System.ValueType) 的部分實作，此類別為抽象類別。
    | ```ReferenceTypeMarshaller<TClass>``` | 提供對 ```class``` 的部分實作，此類別為抽象類別。
    | ```ContractTypeMarshaller<TInterface>``` | 提供對 ```interface``` 的部分實作，此類別為抽象類別。

- #### 已實作的支援類型及對應之編組器一覽
  下列編組器皆位於 ```Melt.Marshaling.Entity``` 命名空間中
   
    | 類型 | 編組器 |
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

- ### 待辦清單
  - [ ] 有許多地方需要做記憶體快取
  - [ ] 可自訂的 TypeMap
 
[回首頁](../../../)
