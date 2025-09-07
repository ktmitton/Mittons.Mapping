using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.NodeData;

internal class NodeFromMemoryData : DataSourceGeneratorAttribute<byte[], Node>
{
    protected override IEnumerable<Func<(byte[], Node)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
            [
                // Id
                0x08, 0x01, // 1
                // Keys
                0x12, 0x02, 0x03, 0x04, // [3, 4]
                // Values
                0x1A, 0x02, 0x05, 0x06, // [5, 6]
                // Info
                0x22, 0x0c,
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
                // Latitude
                0x40, 0x02, // 1
                // Longitude
                0x48, 0x03, // -2
            ],
            new Node()
            {
                Id = 1,
                Keys = [3, 4],
                Values = [5, 6],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 1,
                Longitude = -2,
            }
        );

        yield return () =>
        (
            [
                // Id
                0x08, 0x01, // 1
                // Keys
                0x12, 0x02, 0x05, 0x06, // [5, 6]
                // Values
                0x1A, 0x02, 0x03, 0x04, // [3, 4]
                // Info
                0x22, 0x0c,
                    // Version
                    0x08, 0x02,
                    // Timestamp
                    0x10, 0x03,
                    // Change Set
                    0x18, 0x04,
                    // User Id
                    0x20, 0x05,
                    // User String Id
                    0x28, 0x06,
                    // Is Visible
                    0x30, 0x00,
                // Latitude
                0x40, 0x03, // -2
                // Longitude
                0x48, 0x02, // 1
            ],
            new Node()
            {
                Id = 1,
                Keys = [5, 6],
                Values = [3, 4],
                Info = new()
                {
                    Version = 2,
                    Timestamp = 3,
                    ChangeSet = 4,
                    UserId = 5,
                    UserStringId = 6,
                    IsVisible = false,
                },
                Latitude = -2,
                Longitude = 1,
            }
        );

        yield return () =>
        (
            [
                // Id
                0x08, 0x01, // 1
                // Keys
                0x12, 0x02, 0x03, 0x04, // [3, 4]
                // Values
                0x1A, 0x02, 0x05, 0x06, // [5, 6]
                // Latitude
                0x40, 0x02, // 1
                // Longitude
                0x48, 0x03, // -2
            ],
            new Node()
            {
                Id = 1,
                Keys = [3, 4],
                Values = [5, 6],
                Latitude = 1,
                Longitude = -2,
            }
        );
    }
}
