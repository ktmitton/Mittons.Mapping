using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class HeaderBlockTests
{
    [Test]
    [HeaderBlockEqualityData]
    public async Task EqualityTests(HeaderBlock left, HeaderBlock right)
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
    [HeaderBlockInequalityData]
    public async Task InequalityTests(HeaderBlock left, HeaderBlock right)
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
    [HeaderBoundingBoxData]
    public async Task AsHeaderBoundingBoxTests(byte[] source, HeaderBoundingBox expectedBoundingBox)
    {
        HeaderBoundingBox actualResult = new Memory<byte>(source).AsHeaderBoundingBox();

        await Assert.That(actualResult).IsEqualTo(expectedBoundingBox);
    }
}
