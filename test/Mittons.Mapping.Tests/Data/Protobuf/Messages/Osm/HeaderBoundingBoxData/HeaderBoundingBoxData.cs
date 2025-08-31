using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.HeaderBoundingBoxData;

internal class HeaderBoundingBoxFromMemoryData : DataSourceGeneratorAttribute<byte[], HeaderBoundingBox>
{
    protected override IEnumerable<Func<(byte[], HeaderBoundingBox)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () => (
            [
                // Left
                0x08, 0xbf, 0xda, 0xba, 0xcb, 0xbe, 0x04,
                // Right
                0x10, 0xbf, 0xfe, 0x98, 0x82, 0xbd, 0x04,
                // Top
                0x18, 0xe0, 0xc8, 0xc1, 0xc5, 0xa2, 0x02,
                // Bottom
                0x20, 0xc0, 0xff, 0xa6, 0x82, 0xa1, 0x02,
            ],
            new HeaderBoundingBox()
            {
                Left = -77120100000,
                Right = -76909060000,
                Top = 38996030000,
                Bottom = 38791340000,
            }
        );

        yield return () => (
            [
                // Right
                0x10, 0xbf, 0xfe, 0x98, 0x82, 0xbd, 0x04,
                // Left
                0x08, 0xbf, 0xda, 0xba, 0xcb, 0xbe, 0x04,
                // Top
                0x18, 0xe0, 0xc8, 0xc1, 0xc5, 0xa2, 0x02,
                // Bottom
                0x20, 0xc0, 0xff, 0xa6, 0x82, 0xa1, 0x02,
            ],
            new HeaderBoundingBox()
            {
                Left = -77120100000,
                Right = -76909060000,
                Top = 38996030000,
                Bottom = 38791340000,
            }
        );

        yield return () => (
            [
                // Right
                0x10, 0xbf, 0xfe, 0x98, 0x82, 0xbd, 0x04,
                // Top
                0x18, 0xe0, 0xc8, 0xc1, 0xc5, 0xa2, 0x02,
                // Left
                0x08, 0xbf, 0xda, 0xba, 0xcb, 0xbe, 0x04,
                // Bottom
                0x20, 0xc0, 0xff, 0xa6, 0x82, 0xa1, 0x02,
            ],
            new HeaderBoundingBox()
            {
                Left = -77120100000,
                Right = -76909060000,
                Top = 38996030000,
                Bottom = 38791340000,
            }
        );

        yield return () => (
            [
                // Right
                0x10, 0xbf, 0xfe, 0x98, 0x82, 0xbd, 0x04,
                // Top
                0x18, 0xe0, 0xc8, 0xc1, 0xc5, 0xa2, 0x02,
                // Bottom
                0x20, 0xc0, 0xff, 0xa6, 0x82, 0xa1, 0x02,
                // Left
                0x08, 0xbf, 0xda, 0xba, 0xcb, 0xbe, 0x04,
            ],
            new HeaderBoundingBox()
            {
                Left = -77120100000,
                Right = -76909060000,
                Top = 38996030000,
                Bottom = 38791340000,
            }
        );
    }
}
