namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.LengthDelimited;

internal class PackedRepeatedInt32Data : DataSourceGeneratorAttribute<byte[], int[]>
{
    protected override IEnumerable<Func<(byte[], int[])>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var variation in CreateVariations([..PositiveData, ..NegativeData]))
        {
            yield return () => variation;
        }
    }

    internal static IEnumerable<(byte[], int)> PositiveData
    {
        get =>
        [
            ([0xff, 0xff, 0x7f], 2_097_151),
            ([0x80, 0x80, 0x80, 0x01], 2_097_152),
            ([0x81, 0x80, 0x80, 0x01], 2_097_153),
            ([0x82, 0x80, 0x80, 0x01], 2_097_154),
            ([0xff, 0xff, 0xff, 0x7f], 268_435_455),
            ([0x80, 0x80, 0x80, 0x80, 0x01], 268_435_456),
            ([0x81, 0x80, 0x80, 0x80, 0x01], 268_435_457),
            ([0x82, 0x80, 0x80, 0x80, 0x01], 268_435_458),
            ([0xff, 0xff, 0xff, 0xff, 0x07], int.MaxValue),
        ];
    }

    internal static IEnumerable<(byte[], int)> NegativeData
    {
        get =>
        [
            ([0x80, 0x80, 0x80, 0x80, 0x08], int.MinValue)
        ];
    }

    private static IEnumerable<(byte[] bytes, int[] value)> CreateVariations(IEnumerable<(byte[] bytes, int value)> source)
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
