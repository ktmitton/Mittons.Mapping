namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.LengthDelimited;

internal class PackedRepeatedSInt32Data : DataSourceGeneratorAttribute<byte[], int[]>
{
    protected override IEnumerable<Func<(byte[], int[])>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var variation in CreateVariations([.. PositiveData, .. NegativeData]))
        {
            yield return () => variation;
        }
    }

    internal static IEnumerable<(byte[], int)> PositiveData
    {
        get =>
        [
            ([0x80, 0x80, 0x80, 0x01], 1_048_576),
            ([0x82, 0x80, 0x80, 0x01], 1_048_577),
            ([0x80, 0x80, 0x80, 0x80, 0x01], 134_217_728),
            ([0x82, 0x80, 0x80, 0x80, 0x01], 134_217_729),
            ([0xfc, 0xff, 0xff, 0xff, 0x0f], int.MaxValue - 1),
            ([0xfe, 0xff, 0xff, 0xff, 0x0f], int.MaxValue),
        ];
    }

    internal static IEnumerable<(byte[], int)> NegativeData
    {
        get =>
        [
            ([0xff, 0xff, 0x7f], -1_048_576),
            ([0x81, 0x80, 0x80, 0x01], -1_048_577),
            ([0xff, 0xff, 0xff, 0x7f], -134_217_728),
            ([0x81, 0x80, 0x80, 0x80, 0x01], -134_217_729),
            ([0xfd, 0xff, 0xff, 0xff, 0x0f], int.MinValue + 1),
            ([0xff, 0xff, 0xff, 0xff, 0x0f], int.MinValue),
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
