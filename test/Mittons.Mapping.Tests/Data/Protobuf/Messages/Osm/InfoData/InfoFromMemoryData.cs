using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.InfoData;

internal class InfoFromMemoryData : DataSourceGeneratorAttribute<byte[], Info>
{
    protected override IEnumerable<Func<(byte[], Info)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
            [
                // Version
                0x08, 0x00,
                // Timestamp
                0x10, 0x01,
                // Change Set
                0x18, 0x02,
                // User Id
                0x20, 0x03,
                // User String Id
                0x28, 0x04,
                // Is Visible
                0x30, 0x01,
            ],
            new Info()
            {
                Version = 0,
                Timestamp = 1,
                ChangeSet = 2,
                UserId = 3,
                UserStringId = 4,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            [
                // Version
                0x08, 0x01,
                // Timestamp
                0x10, 0x02,
                // Change Set
                0x18, 0x03,
                // User Id
                0x20, 0x04,
                // User String Id
                0x28, 0x05,
                // Is Visible
                0x30, 0x00,
            ],
            new Info()
            {
                Version = 1,
                Timestamp = 2,
                ChangeSet = 3,
                UserId = 4,
                UserStringId = 5,
                IsVisible = false,
            }
        );

        yield return () =>
        (
            [
                // Timestamp
                0x10, 0x01,
                // Change Set
                0x18, 0x02,
                // User Id
                0x20, 0x03,
                // User String Id
                0x28, 0x04,
            ],
            new Info()
            {
                Version = -1,
                Timestamp = 1,
                ChangeSet = 2,
                UserId = 3,
                UserStringId = 4,
                IsVisible = true,
            }
        );
    }
}
