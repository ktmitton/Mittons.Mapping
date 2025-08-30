namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.LengthDelimited;

internal class BytesData : DataSourceGeneratorAttribute<byte[], byte[]>
{
    protected override IEnumerable<Func<(byte[], byte[])>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () => (new byte[] { 0x01, 0x02, 0x03 }, new byte[] { 0x01, 0x02, 0x03 });
        yield return () => (new byte[] { 0x04, 0x05, 0x06 }, new byte[] { 0x04, 0x05, 0x06 });
    }
}
