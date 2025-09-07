using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.DenseNodeData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class DenseNodesTests
{
    [Test]
    [DenseNodesEqualityData]
    public async Task EqualityTests(DenseNodes left, DenseNodes right)
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
    [DenseNodesInequalityData]
    public async Task InequalityTests(DenseNodes left, DenseNodes right)
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
    [DenseNodesFromMemoryData]
    public async Task AsDenseNodesTests(byte[] source, Node[] expectedNodes)
    {
        var actualResult = new Memory<byte>(source).AsDenseNodes();

        await Assert.That(actualResult).IsEquivalentTo(expectedNodes);
    }
}
