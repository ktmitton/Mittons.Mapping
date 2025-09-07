using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.DenseNodeData;

internal class DenseNodesInequalityData : DataSourceGeneratorAttribute<DenseNodes, DenseNodes>
{
    protected override IEnumerable<Func<(DenseNodes, DenseNodes)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
            new DenseNodes()
            {
                Ids = [1],
                Latitudes = [2],
                Longitudes = [3],
                KeyValues = [4],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                ],
            },
            new DenseNodes()
            {
                Ids = [1, 5],
                Latitudes = [2, 6],
                Longitudes = [3, 7],
                KeyValues = [4, 8],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                    new Info
                    {
                        Version = 2,
                        Timestamp = 2,
                        ChangeSet = 2,
                        UserId = 2,
                        UserStringId = 2,
                        IsVisible = true,
                    },
                ],
            }
        );

        yield return () =>
        (
            new DenseNodes()
            {
                Ids = [1],
                Latitudes = [2],
                Longitudes = [3],
                KeyValues = [4],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                ],
            },
            new DenseNodes()
            {
                Ids = [5, 1],
                Latitudes = [2, 6],
                Longitudes = [3, 7],
                KeyValues = [4, 8],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                    new Info
                    {
                        Version = 2,
                        Timestamp = 2,
                        ChangeSet = 2,
                        UserId = 2,
                        UserStringId = 2,
                        IsVisible = true,
                    },
                ],
            }
        );

        yield return () =>
        (
            new DenseNodes()
            {
                Ids = [1],
                Latitudes = [2],
                Longitudes = [3],
                KeyValues = [4],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                ],
            },
            new DenseNodes()
            {
                Ids = [1, 5],
                Latitudes = [6, 2],
                Longitudes = [3, 7],
                KeyValues = [4, 8],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                    new Info
                    {
                        Version = 2,
                        Timestamp = 2,
                        ChangeSet = 2,
                        UserId = 2,
                        UserStringId = 2,
                        IsVisible = true,
                    },
                ],
            }
        );

        yield return () =>
        (
            new DenseNodes()
            {
                Ids = [1],
                Latitudes = [2],
                Longitudes = [3],
                KeyValues = [4],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                ],
            },
            new DenseNodes()
            {
                Ids = [1, 5],
                Latitudes = [2, 6],
                Longitudes = [7, 2],
                KeyValues = [4, 8],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                    new Info
                    {
                        Version = 2,
                        Timestamp = 2,
                        ChangeSet = 2,
                        UserId = 2,
                        UserStringId = 2,
                        IsVisible = true,
                    },
                ],
            }
        );

        yield return () =>
        (
            new DenseNodes()
            {
                Ids = [1],
                Latitudes = [2],
                Longitudes = [3],
                KeyValues = [4],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                ],
            },
            new DenseNodes()
            {
                Ids = [1, 5],
                Latitudes = [2, 6],
                Longitudes = [3, 7],
                KeyValues = [8, 4],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                    new Info
                    {
                        Version = 2,
                        Timestamp = 2,
                        ChangeSet = 2,
                        UserId = 2,
                        UserStringId = 2,
                        IsVisible = true,
                    },
                ],
            }
        );

        yield return () =>
        (
            new DenseNodes()
            {
                Ids = [1],
                Latitudes = [2],
                Longitudes = [3],
                KeyValues = [4],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                ],
            },
            new DenseNodes()
            {
                Ids = [1, 5],
                Latitudes = [2, 6],
                Longitudes = [3, 7],
                KeyValues = [4, 8],
                Infos =
                [
                    new Info
                    {
                        Version = 2,
                        Timestamp = 2,
                        ChangeSet = 2,
                        UserId = 2,
                        UserStringId = 2,
                        IsVisible = true,
                    },
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                ],
            }
        );

        yield return () =>
        (
            new DenseNodes()
            {
                Ids = [1],
                Latitudes = [2],
                Longitudes = [3],
                KeyValues = [4],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                ],
            },
            new DenseNodes()
            {
                Ids = [1, 5],
                Latitudes = [2, 6],
                Longitudes = [3, 7],
                KeyValues = [4, 8],
            }
        );

        yield return () =>
        (
            new DenseNodes()
            {
                Ids = [1],
                Latitudes = [2],
                Longitudes = [3],
                KeyValues = [4],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                ],
            },
            new DenseNodes()
            {
                Ids = [1, 5],
                Latitudes = [2, 6],
                Longitudes = [3, 7],
                KeyValues = [],
                Infos =
                [
                    new Info
                    {
                        Version = 1,
                        Timestamp = 1,
                        ChangeSet = 1,
                        UserId = 1,
                        UserStringId = 1,
                        IsVisible = true,
                    },
                    new Info
                    {
                        Version = 2,
                        Timestamp = 2,
                        ChangeSet = 2,
                        UserId = 2,
                        UserStringId = 2,
                        IsVisible = true,
                    },
                ],
            }
        );
    }
}
