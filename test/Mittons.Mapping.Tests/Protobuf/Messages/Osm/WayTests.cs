using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.WayData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class WayTests
{
    [Test]
    [WayEqualityData]
    public async Task EqualityTests(Way left, Way right)
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
    [WayInequalityData]
    public async Task InequalityTests(Way left, Way right)
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
    [WayFromMemoryData]
    public async Task AsWayTests(byte[] source, Way expectedWay)
    {
        var actualResult = new Memory<byte>(source).AsWay();

        await Assert.That(actualResult).IsEquivalentTo(expectedWay);
    }
}
