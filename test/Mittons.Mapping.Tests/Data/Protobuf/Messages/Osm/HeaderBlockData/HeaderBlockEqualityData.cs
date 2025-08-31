using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.HeaderBlockData;

internal class HeaderBlockEqualityData : DataSourceGeneratorAttribute<HeaderBlock, HeaderBlock>
{
    private static Func<HeaderBoundingBox?>[] HeaderBoundingBoxes
    {
        get
        {
            return
            [
                () => new HeaderBoundingBox()
                {
                    Left = 0,
                    Right = 0,
                    Top = 0,
                    Bottom = 0
                },
                () => null,
            ];
        }
    }

    private static Func<List<string>?>[] StringListVariations
    {
        get
        {
            return
            [
            #if DEBUG
                () => null,
                () => [],
            #else
                () => null,
                () => [],
                () => [""],
                () => [" "],
                () => ["A"],
                () => ["A", "B"],
            #endif
            ];
        }
    }

    private static Func<string?>[] StringVariations
    {
        get
        {
            return
            [
            #if DEBUG
                () => null,
                () => "",
            #else
                () => null,
                () => "",
                () => "A",
                () => "B",
            #endif
            ];
        }
    }

    private static Func<long?>[] LongVariations
    {
        get
        {
            return
            [
            #if DEBUG
                () => null,
                () => 0,
            #else
                () => null,
                () => 0,
                () => 1,
            #endif
            ];
        }
    }

    protected override IEnumerable<Func<(HeaderBlock, HeaderBlock)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var buildBoundingBox in HeaderBoundingBoxes)
        {
            foreach (var buildRequiredFeature in StringListVariations)
            {
                foreach (var buildOptionalFeature in StringListVariations)
                {
                    foreach (var buildWritingProgram in StringVariations)
                    {
                        foreach (var buildSource in StringVariations)
                        {
                            foreach (var buildOsmosisReplicationTimestamp in LongVariations)
                            {
                                foreach (var buildOsmosisReplicationSequenceNumber in LongVariations)
                                {
                                    foreach (var buildOsmosisReplicationBaseUrl in StringVariations)
                                    {
                                        yield return () => (
                                            new HeaderBlock()
                                            {
                                                BoundingBox = buildBoundingBox(),
                                                RequiredFeatures = buildRequiredFeature(),
                                                OptionalFeatures = buildOptionalFeature(),
                                                WritingProgram = buildWritingProgram(),
                                                Source = buildSource(),
                                                OsmosisReplicationTimestamp = buildOsmosisReplicationTimestamp(),
                                                OsmosisReplicationSequenceNumber = buildOsmosisReplicationSequenceNumber(),
                                                OsmosisReplicationBaseUrl = buildOsmosisReplicationBaseUrl(),
                                            },
                                            new HeaderBlock()
                                            {
                                                BoundingBox = buildBoundingBox(),
                                                RequiredFeatures = buildRequiredFeature(),
                                                OptionalFeatures = buildOptionalFeature(),
                                                WritingProgram = buildWritingProgram(),
                                                Source = buildSource(),
                                                OsmosisReplicationTimestamp = buildOsmosisReplicationTimestamp(),
                                                OsmosisReplicationSequenceNumber = buildOsmosisReplicationSequenceNumber(),
                                                OsmosisReplicationBaseUrl = buildOsmosisReplicationBaseUrl(),
                                            }
                                        );
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
