namespace Melt
{
    using System;


    public sealed class EnumerationConverter<TEnum> : ConverterBase<TEnum> where TEnum : Enum
    {   

        protected override byte[] OnConvertToBytes(TEnum graph, ConverterPool pool)
        {
            return pool.Construct().Attach(_underlyingType, graph);
        }
        protected override TEnum OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            return (TEnum)pool.Deconstruct(bytes).Detach(_underlyingType, out length);
        }

        protected override byte[] DefaultValueBytes => _defaultValueBytes;
        
        private readonly byte[] _defaultValueBytes;
        private readonly Type _underlyingType = Enum.GetUnderlyingType(typeof(TEnum));


        public EnumerationConverter()
        {
            var value = Convert.ChangeType(default(TEnum), _underlyingType);
            _defaultValueBytes = GetBytes(value);
        }

        
        private byte[] GetBytes(object value)
        {
            switch (value)
            {
                case sbyte _1: return BitConverter.GetBytes(_1);
                case byte _2: return BitConverter.GetBytes(_2);
                case short _3: return BitConverter.GetBytes(_3);
                case ushort _4: return BitConverter.GetBytes(_4);
                case int _5: return BitConverter.GetBytes(_5);
                case uint _6: return BitConverter.GetBytes(_6);
                case long _7: return BitConverter.GetBytes(_7);
                case ulong _8: return BitConverter.GetBytes(_8);
            }

            throw new NotSupportedException();
        }
        
    }
}
