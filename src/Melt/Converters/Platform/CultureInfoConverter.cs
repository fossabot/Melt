namespace Melt.Converters
{
    using System.Globalization;

    public sealed class CultureInfoConverter : ReferenceTypeConverter<CultureInfo>
    {
        protected override CultureInfo OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            return new CultureInfo(pool.Deconstruct(bytes).Detach<int>(out length));
        }
        
        protected override byte[] OnConvertToBytes(CultureInfo culture, ConverterPool pool)
        {
            return pool.Construct().Attach(culture.LCID);
        }
    }
}
