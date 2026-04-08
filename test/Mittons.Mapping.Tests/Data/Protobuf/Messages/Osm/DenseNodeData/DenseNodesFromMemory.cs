using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.DenseNodeData;

internal class DenseNodesFromMemoryData : DataSourceGeneratorAttribute<byte[], Node[]>
{
    protected override IEnumerable<Func<(byte[], Node[])>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () => (
            [
                // Ids
                0x0a, // Field/Datatype Identifier
                0x04,
                0x01, // -1
                0x02, // (-1 + 1) = 0
                0x83, 0x01, // (0 + -66) = -66
                // Dense Info
                0x2a, // Field/Datatype Identifier
                0x23,
                    // Versions
                    0x0a, // Field/Datatype Identifier
                    0x04,
                    0x00, // 0
                    0x01, // 1
                    0x82, 0x01, // 130
                    // Timestamps
                    0x12, // Field/Datatype Identifier
                    0x04,
                    0x01, // -1
                    0x02, // (-1 + 1) = 0
                    0x83, 0x01, // (0 + -66) = -66
                    // Change Sets
                    0x1a, // Field/Datatype Identifier
                    0x04,
                    0x02, // 1
                    0x03, // -2 (1 + -2) = -1
                    0x84, 0x01, // (-1 + 66) = 65
                    // User Ids
                    0x22, // Field/Datatype Identifier
                    0x04,
                    0x03, // -2
                    0x04, // 2 (-2 + 2) = 0
                    0x85, 0x01, // (0 + -67) = -67
                    // User String Ids
                    0x2a, // Field/Datatype Identifier
                    0x04,
                    0x04, // 2
                    0x05, // (2 + -3) = -1
                    0x86, 0x01, // (-1 + 67) = 66
                    // Is Visible Indicators
                    0x32, // Field/Datatype Identifier
                    0x03,
                    0x00, // false
                    0x01, // true
                    0x01, // true
                // Latitudes
                0x42, // Field/Datatype Identifier
                0x04,
                0x01, // -1
                0x02, // (-1 + 1) = 0
                0x83, 0x01, // (0 + -66) = -66
                // Longitudes
                0x4a, // Field/Datatype Identifier
                0x04,
                0x01, // -1
                0x02, // (-1 + 1) = 0
                0x83, 0x01, // (0 + -66) = -66
                // Key/Value Pairs
                0x52, // Field/Datatype Identifier
                0x09,
                0x01, 0x02, 0x00, // [(1, 2)]
                0x00, // []
                0x03, 0x04, 0x05, 0x06, 0x00, // [(3, 4), (5, 6)]
            ],
            [
                new()
                {
                    Id = -1,
                    Info = new()
                    {
                        Version = 0,
                        Timestamp = -1,
                        ChangeSet = 1,
                        UserId = -2,
                        UserStringId = 2,
                        IsVisible = false,
                    },
                    Latitude = -1,
                    Longitude = -1,
                    Keys = [1],
                    Values = [2],
                },
                new()
                {
                    Id = 0,
                    Info = new()
                    {
                        Version = 1,
                        Timestamp = 0,
                        ChangeSet = -1,
                        UserId = 0,
                        UserStringId = -1,
                        IsVisible = true,
                    },
                    Latitude = 0,
                    Longitude = 0,
                    Keys = [],
                    Values = [],
                },
                new()
                {
                    Id = -66,
                    Info = new()
                    {
                        Version = 130,
                        Timestamp = -66,
                        ChangeSet = 65,
                        UserId = -67,
                        UserStringId = 66,
                        IsVisible = true,
                    },
                    Latitude = -66,
                    Longitude = -66,
                    Keys = [3, 5],
                    Values = [4, 6],
                },
            ]
        );
        yield return () => (
            [
                // Ids
                0x0a, // Field/Datatype Identifier
                0x04,
                0x83, 0x01, // -66 = -66
                0x01, // (-66 + -1) = -67
                0x02, // (-67 + 1) = -66
                // Dense Info
                0x2a, // Field/Datatype Identifier
                0x23,
                    // Versions
                    0x0a, // Field/Datatype Identifier
                    0x04,
                    0x01, // 1
                    0x82, 0x01, // 130
                    0x00, // 0
                    // Timestamps
                    0x12, // Field/Datatype Identifier
                    0x04,
                    0x02, // 1
                    0x83, 0x01, // (1 + -66) = -65
                    0x01, // (-65 + -1) = -66
                    // Change Sets
                    0x1a, // Field/Datatype Identifier
                    0x04,
                    0x03, // -2
                    0x84, 0x01, // (-2 + 66) = 64
                    0x02, // (64 + 1) = 65
                    // User Ids
                    0x22, // Field/Datatype Identifier
                    0x04,
                    0x04, // 2
                    0x85, 0x01, // (2 + -67) = -65
                    0x03, // (-65 + -2) = -67
                    // User String Ids
                    0x2a, // Field/Datatype Identifier
                    0x04,
                    0x05, // -3
                    0x86, 0x01, // (-3 + 67) = 64
                    0x04, // (64 + 2) = 66
                    // Is Visible Indicators
                    0x32, // Field/Datatype Identifier
                    0x03,
                    0x01, // true
                    0x01, // true
                    0x00, // false
                // Latitudes
                0x42, // Field/Datatype Identifier
                0x04,
                0x83, 0x01, // -66 = -66
                0x01, // (-66 + -1) = -67
                0x02, // (-67 + 1) = -66
                // Longitudes
                0x4a, // Field/Datatype Identifier
                0x04,
                0x83, 0x01, // -66 = -66
                0x01, // (-66 + -1) = -67
                0x02, // (-67 + 1) = -66
                // Key/Value Pairs
                0x52, // Field/Datatype Identifier
                0x09,
                0x03, 0x04, 0x05, 0x06, 0x00, // [(3, 4), (5, 6)]
                0x01, 0x02, 0x00, // [(1, 2)]
                0x00, // []
            ],
            [
                new()
                {
                    Id = -66,
                    Info = new()
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = -2,
                        UserId = 2,
                        UserStringId = -3,
                        IsVisible = true,
                    },
                    Latitude = -66,
                    Longitude = -66,
                    Keys = [3, 5],
                    Values = [4, 6],
                },
                new()
                {
                    Id = -67,
                    Info = new()
                    {
                        Version = 130,
                        Timestamp = -65,
                        ChangeSet = 64,
                        UserId = -65,
                        UserStringId = 64,
                        IsVisible = true,
                    },
                    Latitude = -67,
                    Longitude = -67,
                    Keys = [1],
                    Values = [2],
                },
                new()
                {
                    Id = -66,
                    Info = new()
                    {
                        Version = 0,
                        Timestamp = -66,
                        ChangeSet = 65,
                        UserId = -67,
                        UserStringId = 66,
                        IsVisible = false,
                    },
                    Latitude = -66,
                    Longitude = -66,
                    Keys = [],
                    Values = [],
                },
            ]
        );
        yield return () => (
            [
                // Ids
                0x0a, // Field/Datatype Identifier
                0x04,
                0x83, 0x01, // -66 = -66
                0x01, // (-66 + -1) = -67
                0x02, // (-67 + 1) = -66
                // Dense Info
                0x2a, // Field/Datatype Identifier
                0x23,
                    // Versions
                    0x0a, // Field/Datatype Identifier
                    0x04,
                    0x01, // 1
                    0x82, 0x01, // 130
                    0x00, // 0
                    // Timestamps
                    0x12, // Field/Datatype Identifier
                    0x04,
                    0x02, // 1
                    0x83, 0x01, // (1 + -66) = -65
                    0x01, // (-65 + -1) = -66
                    // Change Sets
                    0x1a, // Field/Datatype Identifier
                    0x04,
                    0x03, // -2
                    0x84, 0x01, // (-2 + 66) = 64
                    0x02, // (64 + 1) = 65
                    // User Ids
                    0x22, // Field/Datatype Identifier
                    0x04,
                    0x04, // 2
                    0x85, 0x01, // (2 + -67) = -65
                    0x03, // (-65 + -2) = -67
                    // User String Ids
                    0x2a, // Field/Datatype Identifier
                    0x04,
                    0x05, // -3
                    0x86, 0x01, // (-3 + 67) = 64
                    0x04, // (64 + 2) = 66
                    // Is Visible Indicators
                    0x32, // Field/Datatype Identifier
                    0x03,
                    0x01, // true
                    0x01, // true
                    0x00, // false
                // Latitudes
                0x42, // Field/Datatype Identifier
                0x04,
                0x83, 0x01, // -66 = -66
                0x01, // (-66 + -1) = -67
                0x02, // (-67 + 1) = -66
                // Longitudes
                0x4a, // Field/Datatype Identifier
                0x04,
                0x83, 0x01, // -66 = -66
                0x01, // (-66 + -1) = -67
                0x02, // (-67 + 1) = -66
                // Key/Value Pairs
                0x52, // Field/Datatype Identifier
                0x00
            ],
            [
                new()
                {
                    Id = -66,
                    Info = new()
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = -2,
                        UserId = 2,
                        UserStringId = -3,
                        IsVisible = true,
                    },
                    Latitude = -66,
                    Longitude = -66,
                    Keys = [],
                    Values = [],
                },
                new()
                {
                    Id = -67,
                    Info = new()
                    {
                        Version = 130,
                        Timestamp = -65,
                        ChangeSet = 64,
                        UserId = -65,
                        UserStringId = 64,
                        IsVisible = true,
                    },
                    Latitude = -67,
                    Longitude = -67,
                    Keys = [],
                    Values = [],
                },
                new()
                {
                    Id = -66,
                    Info = new()
                    {
                        Version = 0,
                        Timestamp = -66,
                        ChangeSet = 65,
                        UserId = -67,
                        UserStringId = 66,
                        IsVisible = false,
                    },
                    Latitude = -66,
                    Longitude = -66,
                    Keys = [],
                    Values = [],
                },
            ]
        );
        yield return () => (
            [
                // Ids
                0x0a, // Field/Datatype Identifier
                0x04,
                0x83, 0x01, // -66 = -66
                0x01, // (-66 + -1) = -67
                0x02, // (-67 + 1) = -66
                // Dense Info
                0x2a, // Field/Datatype Identifier
                0x23,
                    // Versions
                    0x0a, // Field/Datatype Identifier
                    0x04,
                    0x01, // 1
                    0x82, 0x01, // 130
                    0x00, // 0
                    // Timestamps
                    0x12, // Field/Datatype Identifier
                    0x04,
                    0x02, // 1
                    0x83, 0x01, // (1 + -66) = -65
                    0x01, // (-65 + -1) = -66
                    // Change Sets
                    0x1a, // Field/Datatype Identifier
                    0x04,
                    0x03, // -2
                    0x84, 0x01, // (-2 + 66) = 64
                    0x02, // (64 + 1) = 65
                    // User Ids
                    0x22, // Field/Datatype Identifier
                    0x04,
                    0x04, // 2
                    0x85, 0x01, // (2 + -67) = -65
                    0x03, // (-65 + -2) = -67
                    // User String Ids
                    0x2a, // Field/Datatype Identifier
                    0x04,
                    0x05, // -3
                    0x86, 0x01, // (-3 + 67) = 64
                    0x04, // (64 + 2) = 66
                    // Is Visible Indicators
                    0x32, // Field/Datatype Identifier
                    0x03,
                    0x01, // true
                    0x01, // true
                    0x00, // false
                // Latitudes
                0x42, // Field/Datatype Identifier
                0x04,
                0x83, 0x01, // -66 = -66
                0x01, // (-66 + -1) = -67
                0x02, // (-67 + 1) = -66
                // Longitudes
                0x4a, // Field/Datatype Identifier
                0x04,
                0x83, 0x01, // -66 = -66
                0x01, // (-66 + -1) = -67
                0x02, // (-67 + 1) = -66
            ],
            [
                new()
                {
                    Id = -66,
                    Info = new()
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = -2,
                        UserId = 2,
                        UserStringId = -3,
                        IsVisible = true,
                    },
                    Latitude = -66,
                    Longitude = -66,
                    Keys = [],
                    Values = [],
                },
                new()
                {
                    Id = -67,
                    Info = new()
                    {
                        Version = 130,
                        Timestamp = -65,
                        ChangeSet = 64,
                        UserId = -65,
                        UserStringId = 64,
                        IsVisible = true,
                    },
                    Latitude = -67,
                    Longitude = -67,
                    Keys = [],
                    Values = [],
                },
                new()
                {
                    Id = -66,
                    Info = new()
                    {
                        Version = 0,
                        Timestamp = -66,
                        ChangeSet = 65,
                        UserId = -67,
                        UserStringId = 66,
                        IsVisible = false,
                    },
                    Latitude = -66,
                    Longitude = -66,
                    Keys = [],
                    Values = [],
                },
            ]
        );
    }
}
