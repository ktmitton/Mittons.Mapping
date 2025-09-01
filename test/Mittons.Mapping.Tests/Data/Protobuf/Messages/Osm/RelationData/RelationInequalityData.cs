using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.RelationData;

internal class RelationInequalityData : DataSourceGeneratorAttribute<Relation, Relation>
{
    protected override IEnumerable<Func<(Relation, Relation)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
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
                Keys = [9],
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
                Values = [10],
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
                RoleStringIds = [1, -2, 5],
                MemberIds = [2, -3, 6],
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
            }
        );

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
                MemberIds = [2, -3, 7],
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Relation]
            }
        );

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
                MemberTypes = [Relation.MemberType.Node, Relation.MemberType.Way, Relation.MemberType.Way]
            }
        );
    }
}
