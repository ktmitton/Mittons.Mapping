using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.HeaderBlockData;

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
    [HeaderBlockFromMemoryData]
    public async Task AsHeaderBlockTests(byte[] source, HeaderBlock expectedHeaderBlock)
    {
        HeaderBlock actualResult = new Memory<byte>(source).AsHeaderBlock();

        await Assert.That(actualResult).IsEqualTo(expectedHeaderBlock);
    }
}
