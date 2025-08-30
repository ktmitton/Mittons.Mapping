namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.LengthDelimited;

internal class PackedRepeatedUInt32Data : DataSourceGeneratorAttribute<byte[], uint[]>
{
    protected override IEnumerable<Func<(byte[], uint[])>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var variation in CreateVariations(PositiveData))
        {
            yield return () => variation;
        }
    }

    internal static IEnumerable<(byte[], uint)> PositiveData
    {
        get =>
        [
            (new byte[] { 0xff, 0xff, 0x7f }, 2_097_151),
            (new byte[] { 0x80, 0x80, 0x80, 0x01 }, 2_097_152),
            (new byte[] { 0x81, 0x80, 0x80, 0x01 }, 2_097_153),
            (new byte[] { 0x82, 0x80, 0x80, 0x01 }, 2_097_154),
            (new byte[] { 0xff, 0xff, 0xff, 0x7f }, 268_435_455),
            (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x01 }, 268_435_456),
            (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x01 }, 268_435_457),
            (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x01 }, 268_435_458),
            (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x0f }, uint.MaxValue),
        ];
    }

    private static IEnumerable<(byte[] bytes, uint[] value)> CreateVariations(IEnumerable<(byte[] bytes, uint value)> source)
    {
        foreach (var (bytes, value) in source)
        {
            yield return (bytes, [value]);
        }

        foreach (var (bytes, value) in source.Reverse())
        {
            yield return (bytes, [value]);
        }

        yield return ([.. source.SelectMany(x => x.bytes)], [.. source.Select(x => x.value)]);
    }
}
