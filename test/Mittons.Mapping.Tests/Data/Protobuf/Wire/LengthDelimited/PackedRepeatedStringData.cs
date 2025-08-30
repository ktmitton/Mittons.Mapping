namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.LengthDelimited;

internal class PackedRepeatedStringData : DataSourceGeneratorAttribute<byte[], string[]>
{
    protected override IEnumerable<Func<(byte[], string[])>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        IEnumerable<(byte[] bytes, string value)> datapoints = [
            (new byte[] { 0x09, 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72, }, "OSMHeader"),
            (new byte[] { 0x07, 0x4f, 0x53, 0x4d, 0x44, 0x61, 0x74, 0x61 }, "OSMData"),
        ];

        foreach (var variation in CreateVariations(datapoints))
        {
            yield return () => variation;
        }
    }

    private static IEnumerable<(byte[] bytes, string[] value)> CreateVariations(IEnumerable<(byte[] bytes, string value)> source)
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
