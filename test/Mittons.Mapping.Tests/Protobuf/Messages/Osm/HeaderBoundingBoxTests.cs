using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.HeaderBoundingBoxData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class HeaderBoundingBoxTests
{
    [Test]
    [HeaderBoundingBoxEqualityData]
    public async Task EqualityTests(HeaderBoundingBox left, HeaderBoundingBox right)
    {
        // Arrange

        // Act
        var actualEqualityFunctionResult = left.Equals(right);
        var actualEqualityOperatorResult = left == right;
        var actualInequalityOperatorResult = left != right;

        // Assert
        await Assert.That(actualEqualityFunctionResult).IsTrue();
        await Assert.That(actualEqualityOperatorResult).IsTrue();
        await Assert.That(actualInequalityOperatorResult).IsFalse();
    }

    [Test]
    [HeaderBoundingBoxInequalityData]
    public async Task InequalityTests(HeaderBoundingBox left, HeaderBoundingBox right)
    {
        // Arrange

        // Act
        var actualEqualityFunctionResult = left.Equals(right);
        var actualEqualityOperatorResult = left == right;
        var actualInequalityOperatorResult = left != right;

        // Assert
        await Assert.That(actualEqualityFunctionResult).IsFalse();
        await Assert.That(actualEqualityOperatorResult).IsFalse();
        await Assert.That(actualInequalityOperatorResult).IsTrue();
    }

    [Test]
    [HeaderBoundingBoxFromMemoryData]
    public async Task AsHeaderBoundingBoxTests(byte[] source, HeaderBoundingBox expectedBoundingBox)
    {
        HeaderBoundingBox actualResult = new Memory<byte>(source).AsHeaderBoundingBox();

        await Assert.That(actualResult).IsEqualTo(expectedBoundingBox);
    }
}
