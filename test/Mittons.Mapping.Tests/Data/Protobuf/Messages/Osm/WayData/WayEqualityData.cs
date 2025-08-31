using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.WayData;

internal class WayEqualityData : DataSourceGeneratorAttribute<Way, Way>
{
    protected override IEnumerable<Func<(Way, Way)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
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
                References = [1, -2],
                Latitudes = [2, -3],
                Longitudes = [3, -4]
            },
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
                References = [1, -2],
                Latitudes = [2, -3],
                Longitudes = [3, -4]
            }
        );

        yield return () =>
        (
            new Way()
            {
                Id = 2,
                Keys = [4, 5],
                Values = [6, 7],
                Info = new()
                {
                    Version = 1,
                    Timestamp = 2,
                    ChangeSet = 3,
                    UserId = 4,
                    UserStringId = 5,
                    IsVisible = false,
                },
                References = [2, 3],
                Latitudes = [4, 6],
                Longitudes = [1, 5]
            },
            new Way()
            {
                Id = 2,
                Keys = [4, 5],
                Values = [6, 7],
                Info = new()
                {
                    Version = 1,
                    Timestamp = 2,
                    ChangeSet = 3,
                    UserId = 4,
                    UserStringId = 5,
                    IsVisible = false,
                },
                References = [2, 3],
                Latitudes = [4, 6],
                Longitudes = [1, 5]
            }
        );

        yield return () =>
        (
            new Way()
            {
                Id = 1,
                Keys = [3, 4],
                Values = [5, 6],
                References = [1, -2],
                Latitudes = [2, -3],
                Longitudes = [3, -4]
            },
            new Way()
            {
                Id = 1,
                Keys = [3, 4],
                Values = [5, 6],
                References = [1, -2],
                Latitudes = [2, -3],
                Longitudes = [3, -4]
            }
        );
    }
}
