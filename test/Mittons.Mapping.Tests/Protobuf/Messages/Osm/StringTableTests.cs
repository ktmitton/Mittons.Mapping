using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.StringTableData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class StringTableTests
{
    [Test]
    [StringTableFromMemoryData]
    public async Task AsStringTableTests(byte[] source, string[] expectedStrings)
    {
        IEnumerable<string> actualResult = new Memory<byte>(source).AsStringTable();

        await Assert.That(actualResult).IsEquivalentTo(expectedStrings);
    }
}
