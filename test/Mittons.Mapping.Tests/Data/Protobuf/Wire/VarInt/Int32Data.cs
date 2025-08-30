namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.VarInt;

internal class Int32Data : DataSourceGeneratorAttribute<byte[], int>
{
    protected override IEnumerable<Func<(byte[], int)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var variation in Int16Data.PositiveData)
        {
            yield return () => variation;
        }

        foreach (var variation in PositiveData)
        {
            yield return () => variation;
        }

        foreach (var variation in NegativeData)
        {
            yield return () => variation;
        }
    }

    internal static IEnumerable<(byte[], int)> PositiveData
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

            yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x07 }, int.MaxValue);
        }
    }

    internal static IEnumerable<(byte[], int)> NegativeData
    {
        get
        {
            yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x08 }, int.MinValue);
        }
    }
}
