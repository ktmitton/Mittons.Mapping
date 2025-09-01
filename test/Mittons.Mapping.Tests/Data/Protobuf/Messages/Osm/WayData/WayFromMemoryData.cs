using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.WayData;

internal class WayFromMemoryData : DataSourceGeneratorAttribute<byte[], Way>
{
    protected override IEnumerable<Func<(byte[], Way)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
            [
                // Id
                0x09, 0x01, // 1
                // Keys
                0x11, 0x02, 0x03, 0x04, // [3, 4]
                // Values
                0x19, 0x02, 0x05, 0x06, // [5, 6]
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
                // References
                0x41, 0x02, 0x02, 0x03, // [1, (1 + -2) = -1]
                // Latitudes
                0x49, 0x02, 0x04, 0x05, // [2, (2 + -3) = -1]
                // Longitudes
                0x51, 0x02, 0x06, 0x07, // [3, (3 + -4) = -1]
            ],
            new Way()
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
                References = [1, -1],
                Latitudes = [2, -1],
                Longitudes = [3, -1],
            }
        );

        yield return () =>
        (
            [
                // Id
                0x09, 0x02, // 2
                // Keys
                0x11, 0x01, 0x05, // [5]
                // Values
                0x19, 0x01, 0x07, // [7]
                // Info
                0x22, 0x0c,
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
                // References
                0x41, 0x01, 0x04, // [2]
                // Latitudes
                0x49, 0x01, 0x06, // [3]
                // Longitudes
                0x51, 0x01, 0x08, // [4]
            ],
            new Way()
            {
                Id = 2,
                Keys = [5],
                Values = [7],
                Info = new()
                {
                    Version = 1,
                    Timestamp = 2,
                    ChangeSet = 3,
                    UserId = 4,
                    UserStringId = 5,
                    IsVisible = false,
                },
                References = [2],
                Latitudes = [3],
                Longitudes = [4],
            }
        );

        yield return () =>
        (
            [
                // Keys
                0x11, 0x02, 0x03, 0x04, // [3, 4]
                // Values
                0x19, 0x02, 0x05, 0x06, // [5, 6]
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
                // References
                0x41, 0x02, 0x02, 0x03, // [1, (1 + -2) = -1]
                // Latitudes
                0x49, 0x02, 0x04, 0x05, // [2, (2 + -3) = -1]
                // Longitudes
                0x51, 0x02, 0x06, 0x07, // [3, (3 + -4) = -1]
            ],
            new Way()
            {
                Id = -1,
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
                References = [1, -1],
                Latitudes = [2, -1],
                Longitudes = [3, -1],
            }
        );

        yield return () =>
        (
            [
                // Id
                0x09, 0x01, // 1
                // Values
                0x19, 0x02, 0x05, 0x06, // [5, 6]
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
                // References
                0x41, 0x02, 0x02, 0x03, // [1, (1 + -2) = -1]
                // Latitudes
                0x49, 0x02, 0x04, 0x05, // [2, (2 + -3) = -1]
                // Longitudes
                0x51, 0x02, 0x06, 0x07, // [3, (3 + -4) = -1]
            ],
            new Way()
            {
                Id = 1,
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
                References = [1, -1],
                Latitudes = [2, -1],
                Longitudes = [3, -1],
            }
        );

        yield return () =>
        (
            [
                // Id
                0x09, 0x01, // 1
                // Keys
                0x11, 0x02, 0x03, 0x04, // [3, 4]
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
                // References
                0x41, 0x02, 0x02, 0x03, // [1, (1 + -2) = -1]
                // Latitudes
                0x49, 0x02, 0x04, 0x05, // [2, (2 + -3) = -1]
                // Longitudes
                0x51, 0x02, 0x06, 0x07, // [3, (3 + -4) = -1]
            ],
            new Way()
            {
                Id = 1,
                Keys = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                References = [1, -1],
                Latitudes = [2, -1],
                Longitudes = [3, -1],
            }
        );

        yield return () =>
        (
            [
                // Id
                0x09, 0x01, // 1
                // Keys
                0x11, 0x02, 0x03, 0x04, // [3, 4]
                // Values
                0x19, 0x02, 0x05, 0x06, // [5, 6]
                // References
                0x41, 0x02, 0x02, 0x03, // [1, (1 + -2) = -1]
                // Latitudes
                0x49, 0x02, 0x04, 0x05, // [2, (2 + -3) = -1]
                // Longitudes
                0x51, 0x02, 0x06, 0x07, // [3, (3 + -4) = -1]
            ],
            new Way()
            {
                Id = 1,
                Keys = [3, 4],
                Values = [5, 6],
                References = [1, -1],
                Latitudes = [2, -1],
                Longitudes = [3, -1],
            }
        );

        yield return () =>
        (
            [
                // Id
                0x09, 0x01, // 1
                // Keys
                0x11, 0x02, 0x03, 0x04, // [3, 4]
                // Values
                0x19, 0x02, 0x05, 0x06, // [5, 6]
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
                // Latitudes
                0x49, 0x02, 0x04, 0x05, // [2, (2 + -3) = -1]
                // Longitudes
                0x51, 0x02, 0x06, 0x07, // [3, (3 + -4) = -1]
            ],
            new Way()
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
                Latitudes = [2, -1],
                Longitudes = [3, -1],
            }
        );

        yield return () =>
        (
            [
                // Id
                0x09, 0x01, // 1
                // Keys
                0x11, 0x02, 0x03, 0x04, // [3, 4]
                // Values
                0x19, 0x02, 0x05, 0x06, // [5, 6]
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
                // References
                0x41, 0x02, 0x02, 0x03, // [1, (1 + -2) = -1]
                // Longitudes
                0x51, 0x02, 0x06, 0x07, // [3, (3 + -4) = -1]
            ],
            new Way()
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
                References = [1, -1],
                Longitudes = [3, -1],
            }
        );

        yield return () =>
        (
            [
                // Id
                0x09, 0x01, // 1
                // Keys
                0x11, 0x02, 0x03, 0x04, // [3, 4]
                // Values
                0x19, 0x02, 0x05, 0x06, // [5, 6]
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
                // References
                0x41, 0x02, 0x02, 0x03, // [1, (1 + -2) = -1]
                // Latitudes
                0x49, 0x02, 0x04, 0x05, // [2, (2 + -3) = -1]
            ],
            new Way()
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
                References = [1, -1],
                Latitudes = [2, -1],
            }
        );
    }
}
