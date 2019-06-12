// Author: Orlys
// Github: https://github.com/Orlys
namespace Melt
{
    using System;

    public sealed class EnumerationConverter<TEnum> : ConverterBase<TEnum> where TEnum : Enum
    {
        private readonly byte[] _defaultValueBytes;

        private readonly Type _underlyingType = Enum.GetUnderlyingType(typeof(TEnum));

        protected override byte[] DefaultValueBytes => _defaultValueBytes;

        public EnumerationConverter()
        {
            var value = Convert.ChangeType(default(TEnum), _underlyingType);
            _defaultValueBytes = GetBytes(value);
        }

        protected override TEnum OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            return (TEnum)pool.Deconstruct(bytes).Detach(_underlyingType, out length);
        }

        protected override byte[] OnConvertToBytes(TEnum graph, ConverterPool pool)
        {
            return pool.Construct().Attach(_underlyingType, graph);
        }

        private byte[] GetBytes(object value)
        {
            switch (value)
            {
                case sbyte @sbyte: return BitConverter.GetBytes(@sbyte);
                case byte @byte: return BitConverter.GetBytes(@byte);
                case short @short: return BitConverter.GetBytes(@short);
                case ushort @ushort: return BitConverter.GetBytes(@ushort);
                case int @int: return BitConverter.GetBytes(@int);
                case uint @uint: return BitConverter.GetBytes(@uint);
                case long @long: return BitConverter.GetBytes(@long);
                case ulong @ulong: return BitConverter.GetBytes(@ulong);
            }

            throw new NotSupportedException();
        }
    }
}