namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.VarInt;

internal class UInt32Data : DataSourceGeneratorAttribute<byte[], uint>
{
    protected override IEnumerable<Func<(byte[], uint)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var variation in UInt16Data.PositiveData)
        {
            yield return () => variation;
        }

        foreach (var variation in PositiveData)
        {
            yield return () => variation;
        }
    }

    internal static IEnumerable<(byte[], uint)> PositiveData
    {
        get
        {
            yield return (new byte[] { 0xff, 0xff, 0x7f }, 2_097_151);
            yield return (new byte[] { 0x80, 0x80, 0x80, 0x01 }, 2_097_152);
            yield return (new byte[] { 0x81, 0x80, 0x80, 0x01 }, 2_097_153);
            yield return (new byte[] { 0x82, 0x80, 0x80, 0x01 }, 2_097_154);

            yield return (new byte[] { 0xff, 0xff, 0xff, 0x7f }, 268_435_455);
            yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x01 }, 268_435_456);
            yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x01 }, 268_435_457);
            yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x01 }, 268_435_458);

            yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x0f }, uint.MaxValue);
        }
    }
}
