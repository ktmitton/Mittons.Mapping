using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.NodeData;

internal class NodeEqualityData : DataSourceGeneratorAttribute<Node, Node>
{
    protected override IEnumerable<Func<(Node, Node)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            },
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            }
        );

        yield return () =>
        (
            new Node()
            {
                Id = 2,
                Keys = [1, 2],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            },
            new Node()
            {
                Id = 2,
                Keys = [1, 2],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            }
        );

        yield return () =>
        (
            new Node()
            {
                Id = 1,
                Keys = [],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            },
            new Node()
            {
                Id = 1,
                Keys = [],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            }
        );

        yield return () =>
        (
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            },
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            }
        );

        yield return () =>
        (
            new Node()
            {
                Id = 1,
                Keys = [5, 6],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            },
            new Node()
            {
                Id = 1,
                Keys = [5, 6],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            }
        );

        yield return () =>
        (
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [7, 8],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            },
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [7, 8],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            }
        );

        yield return () =>
        (
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [3, 4],
                Info = new()
                {
                    Version = 1,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            },
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [3, 4],
                Info = new()
                {
                    Version = 1,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 6,
            }
        );

        yield return () =>
        (
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 9,
                Longitude = 6,
            },
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 9,
                Longitude = 6,
            }
        );

        yield return () =>
        (
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 10,
            },
            new Node()
            {
                Id = 1,
                Keys = [1, 2],
                Values = [3, 4],
                Info = new()
                {
                    Version = 0,
                    Timestamp = 1,
                    ChangeSet = 2,
                    UserId = 3,
                    UserStringId = 4,
                    IsVisible = true,
                },
                Latitude = 5,
                Longitude = 10,
            }
        );
    }
}
