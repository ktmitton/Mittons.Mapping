using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.DenseInfoData;

internal class DenseInfoFromMemoryData : DataSourceGeneratorAttribute<byte[], Info[]>
{
    protected override IEnumerable<Func<(byte[], Info[])>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () => (
            [
                // Versions
                0x08, // Field/Datatype Identifier
                0x04,
                0x00, // 0
                0x01, // 1
                0x82, 0x01, // 130
                // Timestamps
                0x10, // Field/Datatype Identifier
                0x04,
                0x01, // -1
                0x02, // (-1 + 1) = 0
                0x83, 0x01, // (0 + -66) = -66
                // Change Sets
                0x18, // Field/Datatype Identifier
                0x04,
                0x02, // 1
                0x03, // -2 (1 + -2) = -1
                0x84, 0x01, // (-1 + 66) = 65
                // User Ids
                0x20, // Field/Datatype Identifier
                0x04,
                0x03, // -2
                0x04, // 2 (-2 + 2) = 0
                0x85, 0x01, // (0 + -67) = -67
                // User String Ids
                0x28, // Field/Datatype Identifier
                0x04,
                0x04, // 2
                0x05, // (2 + -3) = -1
                0x86, 0x01, // (-1 + 67) = 66
                // Is Visible Indicators
                0x30, // Field/Datatype Identifier
                0x03,
                0x00, // false
                0x01, // true
                0x01, // true
            ],
            [
                new()
                {
                    Version = 0,
                    Timestamp = -1,
                    ChangeSet = 1,
                    UserId = -2,
                    UserStringId = 2,
                    IsVisible = false,
                },
                new()
                {
                    Version = 1,
                    Timestamp = 0,
                    ChangeSet = -1,
                    UserId = 0,
                    UserStringId = -1,
                    IsVisible = true,
                },
                new()
                {
                    Version = 130,
                    Timestamp = -66,
                    ChangeSet = 65,
                    UserId = -67,
                    UserStringId = 66,
                    IsVisible = true,
                },
            ]
        );

        yield return () => (
            [
                // Versions
                0x08, // Field/Datatype Identifier
                0x04,
                0x01, // 1
                0x82, 0x01, // 130
                0x00, // 0
                // Timestamps
                0x10, // Field/Datatype Identifier
                0x04,
                0x02, // 1
                0x83, 0x01, // (1 + -66) = -65
                0x01, // (-65 + -1) = -66
                // Change Sets
                0x18, // Field/Datatype Identifier
                0x04,
                0x03, // -2
                0x84, 0x01, // (-2 + 66) = 64
                0x02, // (64 + 1) = 65
                // User Ids
                0x20, // Field/Datatype Identifier
                0x04,
                0x04, // 2
                0x85, 0x01, // (2 + -67) = -65
                0x03, // (-65 + -2) = -67
                // User String Ids
                0x28, // Field/Datatype Identifier
                0x04,
                0x05, // -3
                0x86, 0x01, // (-3 + 67) = 64
                0x04, // (64 + 2) = 66
                // Is Visible Indicators
                0x30, // Field/Datatype Identifier
                0x03,
                0x01, // true
                0x01, // true
                0x00, // false
            ],
            [
                new()
                {
                    Version = 1,
                    Timestamp = 1,
                    ChangeSet = -2,
                    UserId = 2,
                    UserStringId = -3,
                    IsVisible = true,
                },
                new()
                {
                    Version = 130,
                    Timestamp = -65,
                    ChangeSet = 64,
                    UserId = -65,
                    UserStringId = 64,
                    IsVisible = true,
                },
                new()
                {
                    Version = 0,
                    Timestamp = -66,
                    ChangeSet = 65,
                    UserId = -67,
                    UserStringId = 66,
                    IsVisible = false,
                },
            ]
        );
    }
}
