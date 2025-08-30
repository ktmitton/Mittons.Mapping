namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.LengthDelimited;

internal class PackedRepeatedInt64Data : DataSourceGeneratorAttribute<byte[], long[]>
{
    protected override IEnumerable<Func<(byte[], long[])>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var variation in CreateVariations([..PackedRepeatedInt32Data.PositiveData]))
        {
            yield return () => variation;
        }

        foreach (var variation in CreateVariations([.. PositiveData, .. NegativeData]))
            {
                yield return () => variation;
            }
    }

    internal static IEnumerable<(byte[], long)> PositiveData
    {
        get =>
        [
            ([0xff, 0xff, 0xff, 0xff, 0x7f], 34_359_738_367),
            ([0x80, 0x80, 0x80, 0x80, 0x80, 0x01], 34_359_738_368),
            ([0x81, 0x80, 0x80, 0x80, 0x80, 0x01], 34_359_738_369),
            ([0x82, 0x80, 0x80, 0x80, 0x80, 0x01], 34_359_738_370),
            ([0xff, 0xff, 0xff, 0xff, 0xff, 0x7f], 4_398_046_511_103),
            ([0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01], 4_398_046_511_104),
            ([0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01], 4_398_046_511_105),
            ([0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01], 4_398_046_511_106),
            ([0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f], 562_949_953_421_311),
            ([0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01], 562_949_953_421_312),
            ([0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01], 562_949_953_421_313),
            ([0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01], 562_949_953_421_314),
            ([0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f], 72_057_594_037_927_935),
            ([0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01], 72_057_594_037_927_936),
            ([0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01], 72_057_594_037_927_937),
            ([0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01], 72_057_594_037_927_938),
            ([0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f], long.MaxValue),
        ];
    }

    internal static IEnumerable<(byte[], long)> NegativeData
    {
        get =>
        [
            ([0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01], long.MinValue),
        ];
    }

    private static IEnumerable<(byte[] bytes, long[] value)> CreateVariations(IEnumerable<(byte[] bytes, long value)> source)
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
