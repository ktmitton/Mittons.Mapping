namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.VarInt;

internal class UInt16Data : DataSourceGeneratorAttribute<byte[], ushort>
{
    protected override IEnumerable<Func<(byte[], ushort)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var variation in PositiveData)
        {
            yield return () => variation;
        }
    }

    internal static IEnumerable<(byte[], ushort)> PositiveData
    {
        get
        {
            yield return (new byte[] { 0x00 }, 0);
            yield return (new byte[] { 0x01 }, 1);
            yield return (new byte[] { 0x02 }, 2);

            yield return (new byte[] { 0x7f }, 127);
            yield return (new byte[] { 0x80, 0x01 }, 128);
            yield return (new byte[] { 0x81, 0x01 }, 129);
            yield return (new byte[] { 0x82, 0x01 }, 130);

            yield return (new byte[] { 0xff, 0x7f }, 16_383);
            yield return (new byte[] { 0x80, 0x80, 0x01 }, 16_384);
            yield return (new byte[] { 0x81, 0x80, 0x01 }, 16_385);
            yield return (new byte[] { 0x82, 0x80, 0x01 }, 16_386);

            yield return (new byte[] { 0xff, 0xff, 0x03 }, ushort.MaxValue);
        }
    }
}
