using Mittons.Mapping.Protobuf.Messages.Osm;
using Mittons.Mapping.Tests.Data.Protobuf.Messages.Osm;

namespace Mittons.Mapping.Tests.Protobuf.Messages.Osm;

public class HeaderBoundingBoxTests
{
    [Test]
    [MatrixDataSource]
    public async Task EqualityTests(
        [MatrixRange<long>(0, 4)] long left,
        [MatrixRange<long>(0, 4)] long right,
        [MatrixRange<long>(0, 4)] long top,
        [MatrixRange<long>(0, 4)] long bottom
    )
    {
        // Arrange
        HeaderBoundingBox leftBoundingBox = new()
        {
            Left = left,
            Right = right,
            Top = top,
            Bottom = bottom
        };

        HeaderBoundingBox rightBoundingBox = new()
        {
            Left = left,
            Right = right,
            Top = top,
            Bottom = bottom
        };

        // Act
        var actualEqualityFunctionResult = leftBoundingBox.Equals(rightBoundingBox);
        var actualEqualityOperatorResult = leftBoundingBox == rightBoundingBox;
        var actualInequalityOperatorResult = leftBoundingBox != rightBoundingBox;

        // Assert
        await Assert.That(actualEqualityFunctionResult).IsTrue();
        await Assert.That(actualEqualityOperatorResult).IsTrue();
        await Assert.That(actualInequalityOperatorResult).IsFalse();
    }

    [Test]
    [Arguments(1, 2, 3, 4, 0, 0, 0, 0)]
    [Arguments(1, 2, 3, 4, 0, 2, 3, 4)]
    [Arguments(1, 2, 3, 4, 1, 0, 3, 4)]
    [Arguments(1, 2, 3, 4, 1, 2, 0, 4)]
    [Arguments(1, 2, 3, 4, 1, 2, 3, 0)]
    public async Task InequalityTests(
        long leftLeft, long leftRight, long leftTop, long leftBottom,
        long rightLeft, long rightRight, long rightTop, long rightBottom
    )
    {
        // Arrange
        HeaderBoundingBox leftBoundingBox = new()
        {
            Left = leftLeft,
            Right = leftRight,
            Top = leftTop,
            Bottom = leftBottom
        };

        HeaderBoundingBox rightBoundingBox = new()
        {
            Left = rightLeft,
            Right = rightRight,
            Top = rightTop,
            Bottom = rightBottom
        };

        // Act
        var actualEqualityFunctionResult = leftBoundingBox.Equals(rightBoundingBox);
        var actualEqualityOperatorResult = leftBoundingBox == rightBoundingBox;
        var actualInequalityOperatorResult = leftBoundingBox != rightBoundingBox;

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
