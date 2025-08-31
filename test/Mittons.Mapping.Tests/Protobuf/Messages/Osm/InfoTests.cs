using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm.InfoData;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class InfoTests
{
    [Test]
    [InfoEqualityData]
    public async Task EqualityTests(Info left, Info right)
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
    [InfoInequalityData]
    public async Task InequalityTests(Info left, Info right)
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
    [InfoFromMemoryData]
    public async Task AsInfoTests(byte[] source, Info expectedInfo)
    {
        Info actualResult = new Memory<byte>(source).AsInfo();

        await Assert.That(actualResult).IsEqualTo(expectedInfo);
    }
}
