namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.VarInt;

internal class SInt32Data : DataSourceGeneratorAttribute<byte[], int>
{
    protected override IEnumerable<Func<(byte[], int)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var variation in SInt16Data.PositiveData)
        {
            yield return () => variation;
        }

        foreach (var variation in SInt16Data.NegativeData)
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
            yield return (new byte[] { 0x80, 0x80, 0x80, 0x01 }, 1_048_576);
            yield return (new byte[] { 0x82, 0x80, 0x80, 0x01 }, 1_048_577);

            yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x01 }, 134_217_728);
            yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x01 }, 134_217_729);

            yield return (new byte[] { 0xfc, 0xff, 0xff, 0xff, 0x0f }, int.MaxValue - 1);
            yield return (new byte[] { 0xfe, 0xff, 0xff, 0xff, 0x0f }, int.MaxValue);
        }
    }

    internal static IEnumerable<(byte[], int)> NegativeData
    {
        get
        {
            yield return (new byte[] { 0xff, 0xff, 0x7f }, -1_048_576);
            yield return (new byte[] { 0x81, 0x80, 0x80, 0x01 }, -1_048_577);

            yield return (new byte[] { 0xff, 0xff, 0xff, 0x7f }, -134_217_728);
            yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x01 }, -134_217_729);

            yield return (new byte[] { 0xfd, 0xff, 0xff, 0xff, 0x0f }, int.MinValue + 1);
            yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x0f }, int.MinValue);
        }
    }
}
