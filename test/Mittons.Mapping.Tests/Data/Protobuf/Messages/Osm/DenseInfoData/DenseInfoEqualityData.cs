using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.DenseInfoData;

internal class DenseInfoEqualityData : DataSourceGeneratorAttribute<DenseInfo, DenseInfo>
{
    protected override IEnumerable<Func<(DenseInfo, DenseInfo)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
            new DenseInfo()
            {
                Versions = [],
                Timestamps = [],
                ChangeSets = [],
                UserIds = [],
                UserStringIds = [],
                IsVisibles = [],
            },
            new DenseInfo()
            {
                Versions = [],
                Timestamps = [],
                ChangeSets = [],
                UserIds = [],
                UserStringIds = [],
                IsVisibles = [],
            }
        );

        yield return () =>
        (
            new DenseInfo()
            {
                Versions = [0],
                Timestamps = [1],
                ChangeSets = [2],
                UserIds = [3],
                UserStringIds = [4],
                IsVisibles = [true],
            },
            new DenseInfo()
            {
                Versions = [5, 10],
                Timestamps = [6, 11],
                ChangeSets = [7, 12],
                UserIds = [8, 13],
                UserStringIds = [9, 14],
                IsVisibles = [false, true],
            }
        );
    }
}
