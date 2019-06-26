# Melt
##### [中文](./readme.zh-tw.md)

### Motivation
> The .Net framework contains Marshaling mechanism to convert the object to the binary sequence.  
> But that is very difficult and complicated to use. (Maybe just me, HAHA)  
> So I spent some time developing a new library - **Melt**.

### How to
- #### First
  The Melt provides the instance ```Marshallers.Common``` which implemented the interface ```IMarshalingProvider```.  
  And the instance pre-install some of the marshallers for basically marshaling, see [**here**](#Supported%20%Types%20%And%20%Mapping%20%Marshallers).
  
- #### Sample for Marshaling
  ```csharp
  var c = Marshallers.Common.Construct();
  var data1 = ("value-tuple", 'char', 1m, 2u, 3f, 4.0, 5, (byte)6);
  var data2 = 123;
  var bytes = c.Attach(data1).Attach(data2);
  ```

- #### Sample for Unmarshaling
  ```csharp
  var d = Marshallers.Common.Deconstruct(bytes);
  var data1 = d.Detach<(string String, char Character, decimal Decimal, uint UnsignedInteger, float Single, double Double, int Integer, byte Byte)>();
  var data2 = d.Detach<int>();
  ```

### Marshallers
- #### Implemented customize marshaller
  All of the marshallers implemented the interface ```IMarshaller```.  
  In ordinary, implement or inherit above one can  what you want to do.  
  
- #### Advance usage
  Using both below of the marshaller contracts for customize your advantures marshaller.  
  - ```IMarshaller``` interface  
  - ```MarshallerBase<T>``` abstract class  

  Writen source code for your marshaller, and using ```IMarshalingProvider.Install``` method 
  to installs your marshaller to instance of the marshaling provider.  

- #### Basic Marshallers
  All of the below marshallers are under the namespace ```Melt.Marshaling.Contracts```.
   
    | Marshaller | Verbose
    | --- | --- |
    | ```IMarshaller``` | The marshaller interface.
    | ```MarshallerBase<T>``` | Provides the basically features for marshaller, this class is an abstract class.
    | ```ValueTypeMarshaller<TStruct>``` | Provides the partical implementation features for ```struct```, this class is an abstract class.
    | ```ReferenceTypeMarshaller<TClass>``` | Provides the partical implementation features for ```class```, this class is an abstract class.
    | ```ContractTypeMarshaller<TInterface>``` | Provides the partical implementation features for ```interface```, this class is an abstract class.

- #### Supported Types And Mapping Marshallers
  All of the below marshallers are under the namespace ```Melt.Marshaling.Entity```.

  | Type | Marshaller |
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

- ### Todo List
  - [ ] Memory cache
  - [ ] Customize TypeMap
 
[Back to home](../../../)