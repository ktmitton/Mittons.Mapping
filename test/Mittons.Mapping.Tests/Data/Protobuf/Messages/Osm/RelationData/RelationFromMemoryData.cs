using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.RelationData;

internal class RelationFromMemoryData : DataSourceGeneratorAttribute<byte[], Relation>
{
    protected override IEnumerable<Func<(byte[], Relation)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
            [
                // Id
                0x08, 0x01, // 1
                // Keys
                0x10, 0x02, 0x03, 0x04, // [3, 4]
                // Values
                0x18, 0x02, 0x05, 0x06, // [5, 6]
                // Info
                0x20, 0x0c,
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
                // Role String Ids
                0x40, 0x03, 0x02, 0x03, 0x04, // [1, 3, 4]
                // Member Ids
                0x48, 0x03, 0x04, 0x05, 0x06, // [2, (2 + -3) = -1, (-1 + 3) = 2]
                // Member Types
                0x50, 0x03, 0x00, 0x01, 0x02, // [0, 1, 2]
            ],
            new Relation()
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
                RoleStringIds = [2, 3, 4],
                MemberIds = [2, -1, 2],
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation],
            }
        );
    }
}
