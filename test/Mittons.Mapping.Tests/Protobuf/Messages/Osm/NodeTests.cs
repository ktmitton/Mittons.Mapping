using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.NodeData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class NodeTests
{
    [Test]
    [NodeEqualityData]
    public async Task EqualityTests(Node left, Node right)
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
    [NodeInequalityData]
    public async Task InequalityTests(Node left, Node right)
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
    [NodeFromMemoryData]
    public async Task AsNodeTests(byte[] source, Node expectedNode)
    {
        Node actualResult = new Memory<byte>(source).AsNode();

        await Assert.That(actualResult).IsEqualTo(expectedNode);
    }
}
