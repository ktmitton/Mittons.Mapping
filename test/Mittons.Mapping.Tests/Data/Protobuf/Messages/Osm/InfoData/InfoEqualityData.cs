using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.InfoData;

internal class InfoEqualityData : DataSourceGeneratorAttribute<Info, Info>
{
    protected override IEnumerable<Func<(Info, Info)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            },
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 0,
                Timestamp = 0,
                ChangeSet = 0,
                UserId = 0,
                UserStringId = 0,
                IsVisible = false,
            },
            new Info()
            {
                Version = 0,
                Timestamp = 0,
                ChangeSet = 0,
                UserId = 0,
                UserStringId = 0,
                IsVisible = false,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Timestamp = null,
                ChangeSet = null,
                UserId = null,
                UserStringId = null,
            },
            new Info()
            {
                Timestamp = null,
                ChangeSet = null,
                UserId = null,
                UserStringId = null,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 0,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            },
            new Info()
            {
                Version = 0,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = 0,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            },
            new Info()
            {
                Version = 1,
                Timestamp = 0,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 0,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            },
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 0,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 0,
                UserStringId = 1,
                IsVisible = true,
            },
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 0,
                UserStringId = 1,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 0,
                IsVisible = true,
            },
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 0,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = false,
            },
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = false,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            },
            new Info()
            {
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = null,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            },
            new Info()
            {
                Version = 1,
                Timestamp = null,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = null,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            },
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = null,
                UserId = 1,
                UserStringId = 1,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = null,
                UserStringId = 1,
                IsVisible = true,
            },
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = null,
                UserStringId = 1,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = null,
                IsVisible = true,
            },
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = null,
                IsVisible = true,
            }
        );

        yield return () =>
        (
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
            },
            new Info()
            {
                Version = 1,
                Timestamp = 1,
                ChangeSet = 1,
                UserId = 1,
                UserStringId = 1,
            }
        );
    }
}
