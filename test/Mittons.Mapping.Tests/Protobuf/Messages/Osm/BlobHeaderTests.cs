using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class BlobHeaderTests
{
    [Test]
    [BlobHeaderData]
    public async Task AsBlobHeaderTests(Memory<byte> data, BlobHeader expectedResult)
    {
        var actualResult = data.AsBlobHeader();

        await Assert.That(actualResult.Type).IsEqualTo(expectedResult.Type);
        await Assert.That(actualResult.IndexData?.ToArray()).IsEquivalentTo(expectedResult.IndexData?.ToArray());
        await Assert.That(actualResult.DataSize).IsEqualTo(expectedResult.DataSize);
    }
}
