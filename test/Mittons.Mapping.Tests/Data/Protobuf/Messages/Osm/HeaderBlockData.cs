using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm;

internal class HeaderBlockData : DataSourceGeneratorAttribute<byte[], HeaderBlock>
{
    protected override IEnumerable<Func<(byte[], HeaderBlock)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () => (
            [
                // Header Bounding Box
                0x0a, 0x1c, 0x08, 0xbf, 0xda, 0xba, 0xcb, 0xbe, 0x04, 0x10, 0xbf, 0xfe, 0x98, 0x82, 0xbd, 0x04,
                0x18, 0xe0, 0xc8, 0xc1, 0xc5, 0xa2, 0x02, 0x20, 0xc0, 0xff, 0xa6, 0x82, 0xa1, 0x02,
                // ???
                0x22, 0x0e, 0x4f, 0x73, 0x6d, 0x53, 0x63, 0x68, 0x65, 0x6d, 0x61, 0x2d, 0x56, 0x30, 0x2e, 0x36,
                0x22, 0x0a, 0x44, 0x65, 0x6e, 0x73, 0x65, 0x4e, 0x6f, 0x64, 0x65, 0x73, 0x82, 0x01, 0x0c, 0x6f,
                0x73, 0x6d, 0x69, 0x75, 0x6d, 0x2f, 0x31, 0x2e, 0x35, 0x2e, 0x31, 0x80, 0x02, 0xe6, 0xd3, 0xfc,
                0xd0, 0x05, 0x88, 0x02, 0xb5, 0x0d, 0x92, 0x02, 0x4a, 0x68, 0x74, 0x74, 0x70, 0x3a, 0x2f, 0x2f,
                0x64, 0x6f, 0x77, 0x6e, 0x6c, 0x6f, 0x61, 0x64, 0x2e, 0x67, 0x65, 0x6f, 0x66, 0x61, 0x62, 0x72,
                0x69, 0x6b, 0x2e, 0x64, 0x65, 0x2f, 0x6e, 0x6f, 0x72, 0x74, 0x68, 0x2d, 0x61, 0x6d, 0x65, 0x72,
                0x69, 0x63, 0x61, 0x2f, 0x75, 0x73, 0x2f, 0x64, 0x69, 0x73, 0x74, 0x72, 0x69, 0x63, 0x74, 0x2d,
                0x6f, 0x66, 0x2d, 0x63, 0x6f, 0x6c, 0x75, 0x6d, 0x62, 0x69, 0x61, 0x2d, 0x75, 0x70, 0x64, 0x61,
                0x74, 0x65, 0x73,
            ],
            new HeaderBlock()
        );
    }
}

internal class HeaderBlockEqualityData : DataSourceGeneratorAttribute<HeaderBlock, HeaderBlock>
{
    private Func<HeaderBoundingBox?>[] _headerBoundingBoxes =>
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

    private Func<List<string>>[] _stringListVariations =>
    [
        () => [],
        () => [""],
        () => [" "],
        () => ["A"],
        () => ["A", "B"],
    ];

    private Func<string?>[] _stringVariations =>
    [
        () => null,
        () => "",
        () => "A",
        () => "B",
    ];

    private Func<long?>[] _longVariations =>
    [
        () => null,
        () => 0,
        () => 1,
    ];

    protected override IEnumerable<Func<(HeaderBlock, HeaderBlock)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var buildBoundingBox in _headerBoundingBoxes)
        {
            foreach (var buildRequiredFeature in _stringListVariations)
            {
                foreach (var buildOptionalFeature in _stringListVariations)
                {
                    foreach (var buildWritingProgram in _stringVariations)
                    {
                        foreach (var buildSource in _stringVariations)
                        {
                            foreach (var buildOsmosisReplicationTimestamp in _longVariations)
                            {
                                foreach (var buildOsmosisReplicationSequenceNumber in _longVariations)
                                {
                                    foreach (var buildOsmosisReplicationBaseUrl in _stringVariations)
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

internal class HeaderBlockInequalityData : DataSourceGeneratorAttribute<HeaderBlock, HeaderBlock>
{
    private Func<HeaderBoundingBox?>[] _headerBoundingBoxes =>
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

    private Func<List<string>?>[] _stringListVariations =>
    [
        () => null,
        () => [],
        () => ["A"],
        () => ["A", "B"],
    ];

    private Func<string?>[] _stringVariations =>
    [
        () => null,
        () => "A",
        () => "B",
    ];

    private Func<long?>[] _longVariations =>
    [
        () => null,
        () => 0,
        () => 1,
    ];

    protected override IEnumerable<Func<(HeaderBlock, HeaderBlock)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        foreach (var buildBoundingBox in _headerBoundingBoxes)
        {
            foreach (var buildRequiredFeature in _stringListVariations)
            {
                foreach (var buildOptionalFeature in _stringListVariations)
                {
                    foreach (var buildWritingProgram in _stringVariations)
                    {
                        foreach (var buildSource in _stringVariations)
                        {
                            foreach (var buildOsmosisReplicationTimestamp in _longVariations)
                            {
                                foreach (var buildOsmosisReplicationSequenceNumber in _longVariations)
                                {
                                    foreach (var buildOsmosisReplicationBaseUrl in _stringVariations)
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
                                                BoundingBox = new HeaderBoundingBox()
                                                {
                                                    Left = Math.Abs(buildBoundingBox()?.Left ?? 0) - 1,
                                                    Right = Math.Abs(buildBoundingBox()?.Right ?? 0) - 1,
                                                    Top = Math.Abs(buildBoundingBox()?.Top ?? 0) - 1,
                                                    Bottom = Math.Abs(buildBoundingBox()?.Bottom ?? 0) - 1
                                                },
                                                RequiredFeatures = buildRequiredFeature(),
                                                OptionalFeatures = buildOptionalFeature(),
                                                WritingProgram = buildWritingProgram(),
                                                Source = buildSource(),
                                                OsmosisReplicationTimestamp = buildOsmosisReplicationTimestamp(),
                                                OsmosisReplicationSequenceNumber = buildOsmosisReplicationSequenceNumber(),
                                                OsmosisReplicationBaseUrl = buildOsmosisReplicationBaseUrl(),
                                            }
                                        );

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
                                                RequiredFeatures = [.. buildRequiredFeature() ?? [], "DIFFERENT"],
                                                OptionalFeatures = buildOptionalFeature(),
                                                WritingProgram = buildWritingProgram(),
                                                Source = buildSource(),
                                                OsmosisReplicationTimestamp = buildOsmosisReplicationTimestamp(),
                                                OsmosisReplicationSequenceNumber = buildOsmosisReplicationSequenceNumber(),
                                                OsmosisReplicationBaseUrl = buildOsmosisReplicationBaseUrl(),
                                            }
                                        );

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
                                                OptionalFeatures = [.. buildRequiredFeature() ?? [], "DIFFERENT"],
                                                WritingProgram = buildWritingProgram(),
                                                Source = buildSource(),
                                                OsmosisReplicationTimestamp = buildOsmosisReplicationTimestamp(),
                                                OsmosisReplicationSequenceNumber = buildOsmosisReplicationSequenceNumber(),
                                                OsmosisReplicationBaseUrl = buildOsmosisReplicationBaseUrl(),
                                            }
                                        );

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
                                                WritingProgram = $"+{buildWritingProgram()}",
                                                Source = buildSource(),
                                                OsmosisReplicationTimestamp = buildOsmosisReplicationTimestamp(),
                                                OsmosisReplicationSequenceNumber = buildOsmosisReplicationSequenceNumber(),
                                                OsmosisReplicationBaseUrl = buildOsmosisReplicationBaseUrl(),
                                            }
                                        );

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
                                                Source = $"+{buildSource()}",
                                                OsmosisReplicationTimestamp = buildOsmosisReplicationTimestamp(),
                                                OsmosisReplicationSequenceNumber = buildOsmosisReplicationSequenceNumber(),
                                                OsmosisReplicationBaseUrl = buildOsmosisReplicationBaseUrl(),
                                            }
                                        );

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
                                                OsmosisReplicationTimestamp = Math.Abs(buildOsmosisReplicationTimestamp() ?? 0) - 1,
                                                OsmosisReplicationSequenceNumber = buildOsmosisReplicationSequenceNumber(),
                                                OsmosisReplicationBaseUrl = buildOsmosisReplicationBaseUrl(),
                                            }
                                        );

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
                                                OsmosisReplicationSequenceNumber = Math.Abs(buildOsmosisReplicationSequenceNumber() ?? 0) - 1,
                                                OsmosisReplicationBaseUrl = buildOsmosisReplicationBaseUrl(),
                                            }
                                        );

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
                                                OsmosisReplicationBaseUrl = $"+{buildOsmosisReplicationBaseUrl()}",
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
