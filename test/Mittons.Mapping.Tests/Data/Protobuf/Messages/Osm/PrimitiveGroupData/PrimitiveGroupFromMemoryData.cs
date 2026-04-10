using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.PrimitiveGroupData;

internal class PrimitiveGroupFromMemoryData : DataSourceGeneratorAttribute<byte[], PrimitiveGroup>
{
    protected override IEnumerable<Func<(byte[], PrimitiveGroup)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
            [
                0x0a, // Node
                0x1e, // Repeated Length
                    0x0a, // Field/Wire
                    0x1c, // Node Length
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
            new PrimitiveGroup()
            {
                Nodes = [
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
                ],
                Ways = [],
                Relations = [],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            [
                0x0a, // Node
                0x3c, // Repeated Length
                    0x0a, // Field/Wire
                    0x1c, // Node Length
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
                    0x0a, // Field/Wire
                    0x1c, // Node Length
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
            new PrimitiveGroup()
            {
                Nodes = [
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
                    },
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
                ],
                Ways = [],
                Relations = [],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            [
                0x0a, // Node
                0x1e, // Repeated Length
                    0x0a, // Field/Wire
                    0x1c, // Node Length
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
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [
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
                    },
                ],
                Relations = [],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            [
                0x1a, // Node
                0x33, // Repeated Length (2 + 18 + 31 = 51)
                    0x1a, // Field/Wire
                    0x12, // Node Length (18)
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
                    0x1a, // Field/Wire
                    0x1f, // Node Length (31)
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
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [
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
                    },
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
                    },
                ],
                Relations = [],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            [
                0x22, // Node
                0x1e, // Repeated Length
                    0x22, // Field/Wire
                    0x15, // Node Length (21)
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
                        0x40, 0x03, 0x02, 0x03, 0x04, // [2, 3, 4]
                        // Member Ids
                        0x48, 0x03, 0x04, 0x05, 0x06, // [2, (2 + -3) = -1, (-1 + 3) = 2]
                        // Member Types
                        0x50, 0x03, 0x00, 0x01, 0x02, // [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
            ],
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [
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
                        MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
                    },
                ],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            [
                0x22, // Node
                0x2c, // Repeated Length (2 + 21 + 21 = 44)
                    0x22, // Field/Wire
                    0x15, // Node Length (21)
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
                        0x40, 0x03, 0x02, 0x03, 0x04, // [2, 3, 4]
                        // Member Ids
                        0x48, 0x03, 0x04, 0x05, 0x06, // [2, (2 + -3) = -1, (-1 + 3) = 2]
                        // Member Types
                        0x50, 0x03, 0x00, 0x01, 0x02, // [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
                    0x22, // Field/Wire
                    0x15, // Node Length (21)
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
                        0x40, 0x03, 0x02, 0x03, 0x04, // [2, 3, 4]
                        // Member Ids
                        0x48, 0x03, 0x04, 0x05, 0x06, // [2, (2 + -3) = -1, (-1 + 3) = 2]
                        // Member Types
                        0x50, 0x03, 0x00, 0x01, 0x02, // [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
            ],
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [
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
                        RoleStringIds = [1, -2, 4],
                        MemberIds = [2, -3, 6],
                        MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
                    },
                    new Relation()
                    {
                        Id = 2,
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
                        RoleStringIds = [1, -2, 4],
                        MemberIds = [2, -3, 6],
                        MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
                    },
                ],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            [
                0x2a, // Node
                0x04, // Repeated Length (2 + 2 = 4)
                    0x2a, // Field/Wire
                    0x01, // Node Length (1)
                        0x08, 0x01, // 1
            ],
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [],
                ChangeSets = [1],
            }
        );

        yield return () =>
        (
            [
                0x2a, // Node
                0x06, // Repeated Length (2 + 2 + 2 = 6)
                    0x2a, // Field/Wire
                        0x08, 0x01, // 1
                    0x2a, // Field/Wire
                        0x08, 0x02, // 2
            ],
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [],
                ChangeSets = [1, 2],
            }
        );
    }
}
