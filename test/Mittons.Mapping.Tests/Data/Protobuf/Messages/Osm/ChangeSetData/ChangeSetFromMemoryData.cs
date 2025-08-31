namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.ChangeSetData;

internal class ChangeSetFromMemoryData : DataSourceGeneratorAttribute<byte[], long>
{
    protected override IEnumerable<Func<(byte[], long)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () => (
            [
                0x00, // 0
            ],
            0
        );

        yield return () => (
            [
                0x01, // 1
            ],
            1
        );

        yield return () => (
            [
                0x82, 0x01, // 130
            ],
            130
        );
    }
}
