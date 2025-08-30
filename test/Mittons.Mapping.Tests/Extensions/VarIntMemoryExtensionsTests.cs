using Mittons.Mapping.Extensions;
using Mittons.Mapping.Tests.Data.Protobuf.Wire.VarInt;

namespace Mittons.Mapping.Tests.Extensions;

public class VarIntMemoryExtensionsTests
{
    [Test]
    [MethodDataSource(nameof(VarIntDataSource))]
    public async Task ReadVarInt(Memory<byte> data, Memory<byte> expectedResult, int originalPosition, int expectedPosition)
    {
        int position = originalPosition;

        var actualResult = data.ReadVarInt(ref position);

        await Assert.That(position).IsEqualTo(expectedPosition);
        await Assert.That(actualResult.ToArray()).IsEquivalentTo(expectedResult.ToArray());
    }

    [Test]
    [MethodDataSource(nameof(BoolDataSource))]
    public async Task AsBool(Memory<byte> data, bool expectedValue)
    {
        var actualValue = data.AsBool();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [MethodDataSource(nameof(EnumDataSource))]
    public async Task AsEnum(Memory<byte> data, TestEnum expectedValue)
    {
        var actualValue = data.AsEnum<TestEnum>();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [Int32Data]

    public async Task AsInt32(Memory<byte> data, int expectedValue)
    {
        var actualValue = data.AsInt32();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [Int64Data]
    public async Task AsInt64(Memory<byte> data, long expectedValue)
    {
        var actualValue = data.AsInt64();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [SInt32Data]
    public async Task AsSInt32(Memory<byte> data, int expectedValue)
    {
        var actualValue = data.AsSInt32();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [SInt64Data]
    public async Task AsSInt64(Memory<byte> data, long expectedValue)
    {
        var actualValue = data.AsSInt64();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [UInt16Data]
    public async Task AsUInt16(Memory<byte> data, ushort expectedValue)
    {
        var actualValue = data.AsUInt16();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [UInt32Data]
    public async Task AsUInt32(Memory<byte> data, uint expectedValue)
    {
        var actualValue = data.AsUInt32();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [UInt64Data]
    public async Task AsUInt64(Memory<byte> data, ulong expectedValue)
    {
        var actualValue = data.AsUInt64();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    public static IEnumerable<(Memory<byte> data, Memory<byte> expectedResult, int originalPosition, int expectedPosition)> VarIntDataSource()
    {
        yield return (new byte[] { 0xa1, 0x01 }, new byte[] { 0xa1, 0x01 }, 0, 2);
        yield return (new byte[] { 0x00, 0x00, 0xa1, 0x01 }, new byte[] { 0xa1, 0x01 }, 2, 4);
        yield return (new byte[] { 0xa1, 0x01, 0x00, 0x00 }, new byte[] { 0xa1, 0x01 }, 0, 2);
        yield return (new byte[] { 0x00, 0x00, 0xa1, 0x01, 0x00, 0x00 }, new byte[] { 0xa1, 0x01 }, 2, 4);

        yield return (new byte[] { 0x09 }, new byte[] { 0x09 }, 0, 1);
        yield return (new byte[] { 0xb0, 0x01 }, new byte[] { 0xb0, 0x01 }, 0, 2);
        yield return (new byte[] { 0xaa, 0x01 }, new byte[] { 0xaa, 0x01 }, 0, 2);
        yield return (new byte[] { 0xe0, 0xf3, 0x07 }, new byte[] { 0xe0, 0xf3, 0x07 }, 0, 3);
        yield return (new byte[] { 0x88, 0xdf, 0x03 }, new byte[] { 0x88, 0xdf, 0x03 }, 0, 3);

        yield return (new byte[] { 0xbf, 0xda, 0xba, 0xcb, 0xbe, 0x04 }, new byte[] { 0xbf, 0xda, 0xba, 0xcb, 0xbe, 0x04 }, 0, 6);
        yield return (new byte[] { 0xbf, 0xfe, 0x98, 0x82, 0xbd, 0x04 }, new byte[] { 0xbf, 0xfe, 0x98, 0x82, 0xbd, 0x04 }, 0, 6);
        yield return (new byte[] { 0xe0, 0xc8, 0xc1, 0xc5, 0xa2, 0x02 }, new byte[] { 0xe0, 0xc8, 0xc1, 0xc5, 0xa2, 0x02 }, 0, 6);
        yield return (new byte[] { 0xc0, 0xff, 0xa6, 0x82, 0xa1, 0x02 }, new byte[] { 0xc0, 0xff, 0xa6, 0x82, 0xa1, 0x02 }, 0, 6);
    }

    public static IEnumerable<(Memory<byte> data, bool expectedResult)> BoolDataSource()
    {
        yield return (new byte[] { 0x00 }, false);
        yield return (new byte[] { 0x01 }, true);
        yield return (new byte[] { 0xb0 }, true);
        yield return (new byte[] { 0xa1, 0x00 }, true);
    }

    public static IEnumerable<(Memory<byte> data, TestEnum expectedResult)> EnumDataSource()
    {
        yield return (new byte[] { 0x01 }, TestEnum.Value1);
        yield return (new byte[] { 0x02 }, TestEnum.Value2);
        yield return (new byte[] { 0x03 }, TestEnum.Value3);
    }

    public enum TestEnum
    {
        Value1 = 1,
        Value2 = 2,
        Value3 = 3,
    }
}
