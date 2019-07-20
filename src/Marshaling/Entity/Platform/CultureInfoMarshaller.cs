namespace Melt.Marshaling.Entity
{
    using Melt.Marshaling.Contracts;
    using System.Globalization;

    public sealed class CultureInfoMarshaller : ReferenceTypeMarshaller<CultureInfo>
    {
        protected override CultureInfo OnConvertFromBytes(byte[] bytes, out int length, IMarshalingProvider pool)
        {
            return new CultureInfo(pool.Deconstruct(bytes).Detach<int>(out length));
        }
        
        protected override byte[] OnConvertToBytes(CultureInfo culture, IMarshalingProvider pool)
        {
            return pool.Construct().Attach(culture.LCID);
        }
    }
}
