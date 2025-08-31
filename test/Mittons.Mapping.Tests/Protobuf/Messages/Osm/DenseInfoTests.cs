using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.DenseInfoData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class DenseInfoTests
{
    [Test]
    [DenseInfoFromMemoryData]
    public async Task AsDenseInfoTests(byte[] source, Info[] expectedInfo)
    {
        Info[] actualResult = [.. new Memory<byte>(source).AsDenseInfo()];

        await Assert.That(actualResult).IsEquivalentTo(expectedInfo);
    }
}
