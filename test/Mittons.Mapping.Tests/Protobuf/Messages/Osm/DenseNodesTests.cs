using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.DenseNodeData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class DenseNodesTests
{
    [Test]
    [DenseNodesFromMemoryData]
    public async Task ReadDenseNodeTests(byte[] source, Node[] expectedNodes)
    {
        var actualResult = new Memory<byte>(source).ReadDenseNode();

        await Assert.That(actualResult).IsEquivalentTo(expectedNodes);
    }
}
