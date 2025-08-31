using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.HeaderBoundingBoxData;

internal class HeaderBoundingBoxEqualityData : DataSourceGeneratorAttribute<HeaderBoundingBox, HeaderBoundingBox>
{
    protected override IEnumerable<Func<(HeaderBoundingBox, HeaderBoundingBox)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () =>
        (
            new HeaderBoundingBox()
            {
                Left = 0,
                Right = 0,
                Top = 0,
                Bottom = 0,
            },
            new HeaderBoundingBox()
            {
                Left = 0,
                Right = 0,
                Top = 0,
                Bottom = 0,
            }
        );

        yield return () =>
        (
            new HeaderBoundingBox()
            {
                Left = 1,
                Right = 1,
                Top = 1,
                Bottom = 1,
            },
            new HeaderBoundingBox()
            {
                Left = 1,
                Right = 1,
                Top = 1,
                Bottom = 1,
            }
        );

        yield return () =>
        (
            new HeaderBoundingBox()
            {
                Left = 1,
                Right = 0,
                Top = 0,
                Bottom = 0,
            },
            new HeaderBoundingBox()
            {
                Left = 1,
                Right = 0,
                Top = 0,
                Bottom = 0,
            }
        );

        yield return () =>
        (
            new HeaderBoundingBox()
            {
                Left = 0,
                Right = 1,
                Top = 0,
                Bottom = 0,
            },
            new HeaderBoundingBox()
            {
                Left = 0,
                Right = 1,
                Top = 0,
                Bottom = 0,
            }
        );

        yield return () =>
        (
            new HeaderBoundingBox()
            {
                Left = 0,
                Right = 0,
                Top = 1,
                Bottom = 0,
            },
            new HeaderBoundingBox()
            {
                Left = 0,
                Right = 0,
                Top = 1,
                Bottom = 0,
            }
        );

        yield return () =>
        (
            new HeaderBoundingBox()
            {
                Left = 0,
                Right = 0,
                Top = 0,
                Bottom = 1,
            },
            new HeaderBoundingBox()
            {
                Left = 0,
                Right = 0,
                Top = 0,
                Bottom = 1,
            }
        );
    }
}
