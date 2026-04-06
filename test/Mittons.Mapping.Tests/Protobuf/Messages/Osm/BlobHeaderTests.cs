using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.BlobHeaderData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class BlobHeaderTests
{
    [Test]
    [BlobHeaderFromMemoryData]
    public async Task AsBlobHeaderTests(Memory<byte> data, BlobHeader expectedResult)
    {
        // Arrange
        var expectedIndexData = expectedResult.IndexData?.ToArray();

        // Act
        var actualResult = data.AsBlobHeader();

        // Assert
        var actualIndexData = actualResult.IndexData?.ToArray();

        await Assert.That(actualResult.Type).IsEqualTo(expectedResult.Type);

        if (expectedIndexData is null)
        {
            await Assert.That(actualIndexData).IsNull();
        }
        else
        {
            await Assert.That(actualIndexData).IsNotNull();
            await Assert.That(actualIndexData).IsEquivalentTo(expectedIndexData);
        }

        await Assert.That(actualResult.DataSize).IsEqualTo(expectedResult.DataSize);
    }
}
