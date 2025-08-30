namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.VarInt;

internal class Int64Data : DataSourceGeneratorAttribute<byte[], long>
{
    protected override IEnumerable<Func<(byte[], long)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var variation in Int16Data.PositiveData)
        {
            yield return () => variation;
        }

        foreach (var variation in Int32Data.PositiveData)
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

    internal static IEnumerable<(byte[], long)> PositiveData
    {
        get
        {
            yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x7f }, 34_359_738_367);
            yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_368);
            yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_369);
            yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_370);

            yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 4_398_046_511_103);
            yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_104);
            yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_105);
            yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_106);

            yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 562_949_953_421_311);
            yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_312);
            yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_313);
            yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_314);

            yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 72_057_594_037_927_935);
            yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_936);
            yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_937);
            yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_938);

            yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, long.MaxValue);
        }
    }

    internal static IEnumerable<(byte[], long)> NegativeData
    {
        get
        {
            yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, long.MinValue);
        }
    }
}
