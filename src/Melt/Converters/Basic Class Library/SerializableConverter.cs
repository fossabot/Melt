namespace Melt
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public sealed class SerializableConverter : InterfaceTypeConverter<ISerializable>
    {
        public override bool CanConvert(Type type) => base.CanConvert(type) || type.IsSerializable;

        private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();

        protected override ISerializable OnConvertFromBytes(byte[] bytes, out int length, ConverterPool pool)
        {
            var d = pool.Deconstruct(bytes);
            var l = d.Detach<int>(out length);

            const int s_intSz = 4;
            using (var ms = new MemoryStream(bytes.AsSpan(s_intSz, length).ToArray()))
            {
                var graph = _binaryFormatter.Deserialize(ms) as ISerializable;
                length += s_intSz;
                return graph;
            }
        }

        protected override byte[] OnConvertToBytes(ISerializable graph, ConverterPool pool)
        {
            using (var ms = new MemoryStream())
            {
                _binaryFormatter.Serialize(ms, graph);
                var payload = ms.ToArray();
                var c = pool.Construct();
                c.Attach(payload.Length);
                c.Attach(payload);
                return c;
            }
        }
    }

}
