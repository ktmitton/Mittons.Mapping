using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.RelationData;

internal class RelationEqualityData : DataSourceGeneratorAttribute<Relation, Relation>
{
    protected override IEnumerable<Func<(Relation, Relation)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        // Basic Equality
        yield return () =>
        (
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
            }
        );

        // Change Id
        yield return () =>
        (
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
            }
        );

        // Change Keys
        yield return () =>
        (
            new Relation()
            {
                Id = 1,
                Keys = [1, 2],
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
                Id = 1,
                Keys = [1, 2],
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
            }
        );

        // Change Values
        yield return () =>
        (
            new Relation()
            {
                Id = 1,
                Keys = [3, 4],
                Values = [1, 2],
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
                Id = 1,
                Keys = [3, 4],
                Values = [1, 2],
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
            }
        );

        // Change Info
        yield return () =>
        (
            new Relation()
            {
                Id = 1,
                Keys = [3, 4],
                Values = [5, 6],
                Info = new()
                {
                    Version = 1,
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
                Id = 1,
                Keys = [3, 4],
                Values = [5, 6],
                Info = new()
                {
                    Version = 1,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                RoleStringIds = [1, -2, 4],
                MemberIds = [2, -3, 6],
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
            }
        );

        // Change String Ids
        yield return () =>
        (
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
                RoleStringIds = [1, -2, 5],
                MemberIds = [2, -3, 6],
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
            },
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
                RoleStringIds = [1, -2, 5],
                MemberIds = [2, -3, 6],
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
            }
        );

        // Change Member Ids
        yield return () =>
        (
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
                MemberIds = [2, -3, 9],
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
            },
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
                MemberIds = [2, -3, 9],
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
            }
        );

        // Change Member Types
        yield return () =>
        (
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
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Node]
            },
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
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Node]
            }
        );
    }
}
