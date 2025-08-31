using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.BlobData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class BlobTests
{
    [Test]
    [BlobFromMemoryData]
    public async Task AsBlobTests(byte[] source, byte[] expectedMessageData, byte[] expectedDecompressedData, int expectedUncompressedSize)
    {
        var actualResult = new Memory<byte>(source).AsBlob();

        await Assert.That(actualResult.UncompressedSize).IsEqualTo(expectedUncompressedSize);
        await Assert.That(actualResult.MessageData.ToArray()).IsEquivalentTo(expectedMessageData);
    }
}
