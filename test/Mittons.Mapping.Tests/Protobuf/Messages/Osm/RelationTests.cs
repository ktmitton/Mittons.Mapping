using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.RelationData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class RelationTests
{
    [Test]
    [RelationEqualityData]
    public async Task EqualityTests(Relation left, Relation right)
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
    [RelationInequalityData]
    public async Task InequalityTests(Relation left, Relation right)
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
    [RelationFromMemoryData]
    public async Task AsRelationTests(byte[] source, Relation expectedRelation)
    {
        var actualResult = new Memory<byte>(source).AsRelation();

        await Assert.That(actualResult).IsEquivalentTo(expectedRelation);
    }
}
