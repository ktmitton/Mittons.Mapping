namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.VarInt;

internal class SInt16Data : DataSourceGeneratorAttribute<byte[], short>
{
    protected override IEnumerable<Func<(byte[], short)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var variation in PositiveData)
        {
            yield return () => variation;
        }

        foreach (var variation in NegativeData)
        {
            yield return () => variation;
        }
    }

    internal static IEnumerable<(byte[], short)> PositiveData
    {
        get
        {
            yield return (new byte[] { 0x00 }, 0);
            yield return (new byte[] { 0x02 }, 1);

            yield return (new byte[] { 0x80, 0x01 }, 64);
            yield return (new byte[] { 0x82, 0x01 }, 65);

            yield return (new byte[] { 0x80, 0x80, 0x01 }, 8_192);
            yield return (new byte[] { 0x82, 0x80, 0x01 }, 8_193);

            yield return (new byte[] { 0xfc, 0xff, 0x03 }, short.MaxValue - 1);
            yield return (new byte[] { 0xfe, 0xff, 0x03 }, short.MaxValue);
        }
    }

    internal static IEnumerable<(byte[], short)> NegativeData
    {
        get
        {
            yield return (new byte[] { 0x01 }, -1);
            yield return (new byte[] { 0x03 }, -2);

            yield return (new byte[] { 0x7f }, -64);
            yield return (new byte[] { 0x81, 0x01 }, -65);

            yield return (new byte[] { 0xff, 0x7f }, -8_192);
            yield return (new byte[] { 0x81, 0x80, 0x01 }, -8_193);

            yield return (new byte[] { 0xfd, 0xff, 0x03 }, short.MinValue + 1);
            yield return (new byte[] { 0xff, 0xff, 0x03 }, short.MinValue);
        }
    }
}
