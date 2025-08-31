using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.ChangeSetData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class ChangeSetTests
{
    [Test]
    [ChangeSetFromMemoryData]
    public async Task AsChangeSetTests(byte[] source, long expectedChangeSet)
    {
        long actualResult = new Memory<byte>(source).AsChangeSet();

        await Assert.That(actualResult).IsEqualTo(expectedChangeSet);
    }
}
