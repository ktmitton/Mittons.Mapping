using Mittons.Mapping.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Data.Protobuf.Messages;

internal class BlobHeaderData : DataSourceGeneratorAttribute<byte[], BlobHeader>
{
    protected override IEnumerable<Func<(byte[], BlobHeader)>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        yield return () => (
            [
                0x0a, 0x09, 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72, // Type = "OSMHeader"
                0x18, 0xb0, 0x01,                                                 // DataSize = 176
            ],
            new BlobHeader(type: "OSMHeader", dataSize: 176)
        );

        yield return () => (
            [
                0x18, 0xb0, 0x01,                                                 // DataSize = 176
                0x0a, 0x09, 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72, // Type = "OSMHeader"
            ],
            new BlobHeader(type: "OSMHeader", dataSize: 176)
        );

        yield return () => (
            [
                0x0a, 0x07, 0x4f, 0x53, 0x4d, 0x44, 0x61, 0x74, 0x61, // Type = "OSMData"
                0x18, 0x90, 0xdf, 0x03,                               // DataSize = 61,328
            ],
            new BlobHeader(type: "OSMData", dataSize: 61_328)
        );

        yield return () => (
            [
                0x18, 0x90, 0xdf, 0x03,                               // DataSize = 61,328
                0x0a, 0x07, 0x4f, 0x53, 0x4d, 0x44, 0x61, 0x74, 0x61, // Type = "OSMData"
            ],
            new BlobHeader(type: "OSMData", dataSize: 61_328)
        );

        yield return () => (
            [
                0x0a, 0x09, 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72, // Type = "OSMHeader"
                0x12, 0x09, 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72, // IndexData = "OSMHeader"
                0x18, 0xb0, 0x01,                                                 // DataSize = 176
            ],
            new BlobHeader(type: "OSMHeader", dataSize: 176, indexData: "OSMHeader"u8.ToArray())
        );

        yield return () => (
            [
                0x0a, 0x09, 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72, // Type = "OSMHeader"
                0x12, 0x03, 0x00, 0x00, 0x00,                                     // IndexData = [0,0,0]
                0x18, 0xb0, 0x01,                                                 // DataSize = 176
            ],
            new BlobHeader(type: "OSMHeader", dataSize: 176, indexData: new byte[] { 0x00, 0x00, 0x00})
        );
    }
}
