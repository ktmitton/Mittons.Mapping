namespace Mittons.Mapping.Tests.Data.Protobuf.Wire.LengthDelimited;

internal class StringData : DataSourceGeneratorAttribute<byte[], string>
{
    protected override IEnumerable<Func<(byte[], string)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () => ("OSMHeader"u8.ToArray(), "OSMHeader");
        yield return () => ("OSMData"u8.ToArray(), "OSMData");
    }
}
