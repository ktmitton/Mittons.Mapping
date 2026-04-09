using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.PrimitiveGroupData;

internal class PrimitiveGroupEqualityData : DataSourceGeneratorAttribute<PrimitiveGroup, PrimitiveGroup>
{
    protected override IEnumerable<Func<(PrimitiveGroup, PrimitiveGroup)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        Node node1 = new()
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
        };

        Node node2 = new()
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
        };

        Way way1 = new()
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
        };

        Way way2 = new()
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
        };

        Relation relations1 = new()
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
        };

        Relation relations2 = new()
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
        };

        long changeSet1 = 1;

        long changeSet2 = 2;

        yield return () =>
        (
            new PrimitiveGroup()
            {
                Nodes = [node1],
                Ways = [],
                Relations = [],
                ChangeSets = [],
            },
            new PrimitiveGroup()
            {
                Nodes = [node1],
                Ways = [],
                Relations = [],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            new PrimitiveGroup()
            {
                Nodes = [node1, node2],
                Ways = [],
                Relations = [],
                ChangeSets = [],
            },
            new PrimitiveGroup()
            {
                Nodes = [node1, node2],
                Ways = [],
                Relations = [],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [way1],
                Relations = [],
                ChangeSets = [],
            },
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [way1],
                Relations = [],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [way1, way2],
                Relations = [],
                ChangeSets = [],
            },
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [way1, way2],
                Relations = [],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [relations1],
                ChangeSets = [],
            },
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [relations1],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [relations1, relations2],
                ChangeSets = [],
            },
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [relations1, relations2],
                ChangeSets = [],
            }
        );

        yield return () =>
        (
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [],
                ChangeSets = [changeSet1],
            },
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [],
                ChangeSets = [changeSet1],
            }
        );

        yield return () =>
        (
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [],
                ChangeSets = [changeSet1, changeSet2],
            },
            new PrimitiveGroup()
            {
                Nodes = [],
                Ways = [],
                Relations = [],
                ChangeSets = [changeSet1, changeSet2],
            }
        );
    }
}
