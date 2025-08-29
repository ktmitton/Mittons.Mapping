using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Tests.Extensions;

public class VarIntMemoryExtensionTests
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
    public async Task ToBool(Memory<byte> data, bool expectedValue)
    {
        var actualValue = data.ToBool();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [MethodDataSource(nameof(EnumDataSource))]
    public async Task ToEnum(Memory<byte> data, TestEnum expectedValue)
    {
        var actualValue = data.ToEnum<TestEnum>();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [MethodDataSource(nameof(Int16PositiveDataSource))]
    [MethodDataSource(nameof(Int32PositiveDataSource))]
    [MethodDataSource(nameof(Int32NegativeDataSource))]
    public async Task ToInt32(Memory<byte> data, int expectedValue)
    {
        var actualValue = data.ToInt32();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [MethodDataSource(nameof(Int16PositiveDataSource))]
    [MethodDataSource(nameof(Int32PositiveDataSource))]
    [MethodDataSource(nameof(Int64PositiveDataSource))]
    [MethodDataSource(nameof(Int64NegativeDataSource))]
    public async Task ToInt64(Memory<byte> data, long expectedValue)
    {
        var actualValue = data.ToInt64();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [MethodDataSource(nameof(SInt16DataSource))]
    [MethodDataSource(nameof(SInt32DataSource))]
    public async Task ToSInt32(Memory<byte> data, int expectedValue)
    {
        var actualValue = data.ToSInt32();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [MethodDataSource(nameof(SInt16DataSource))]
    [MethodDataSource(nameof(SInt32DataSource))]
    [MethodDataSource(nameof(SInt64DataSource))]
    public async Task ToSInt64(Memory<byte> data, long expectedValue)
    {
        var actualValue = data.ToSInt64();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [MethodDataSource(nameof(UInt16DataSource))]
    public async Task ToUInt16(Memory<byte> data, ushort expectedValue)
    {
        var actualValue = data.ToUInt16();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [MethodDataSource(nameof(UInt16DataSource))]
    [MethodDataSource(nameof(UInt32DataSource))]
    public async Task ToUInt32(Memory<byte> data, uint expectedValue)
    {
        var actualValue = data.ToUInt32();

        await Assert.That(actualValue).IsEqualTo(expectedValue);
    }

    [Test]
    [MethodDataSource(nameof(UInt16DataSource))]
    [MethodDataSource(nameof(UInt32DataSource))]
    [MethodDataSource(nameof(UInt64DataSource))]
    public async Task ToUInt64(Memory<byte> data, ulong expectedValue)
    {
        var actualValue = data.ToUInt64();

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

    public static IEnumerable<(Memory<byte> data, short expectedResult)> Int16PositiveDataSource()
    {
        yield return (new byte[] { 0x00 }, 0);
        yield return (new byte[] { 0x01 }, 1);
        yield return (new byte[] { 0x02 }, 2);

        yield return (new byte[] { 0x7f }, 127);
        yield return (new byte[] { 0x80, 0x01 }, 128);
        yield return (new byte[] { 0x81, 0x01 }, 129);
        yield return (new byte[] { 0x82, 0x01 }, 130);

        yield return (new byte[] { 0xff, 0x7f }, 16_383);
        yield return (new byte[] { 0x80, 0x80, 0x01 }, 16_384);
        yield return (new byte[] { 0x81, 0x80, 0x01 }, 16_385);
        yield return (new byte[] { 0x82, 0x80, 0x01 }, 16_386);

        yield return (new byte[] { 0xff, 0xff, 0x01 }, short.MaxValue);
    }

    public static IEnumerable<(Memory<byte> data, int expectedResult)> Int32PositiveDataSource()
    {
        yield return (new byte[] { 0xff, 0xff, 0x7f }, 2_097_151);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x01 }, 2_097_152);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x01 }, 2_097_153);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x01 }, 2_097_154);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0x7f }, 268_435_455);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x01 }, 268_435_456);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x01 }, 268_435_457);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x01 }, 268_435_458);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x07 }, int.MaxValue);
    }

    public static IEnumerable<(Memory<byte> data, int expectedResult)> Int32NegativeDataSource()
    {
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x08 }, int.MinValue);
    }

    public static IEnumerable<(Memory<byte> data, long expectedResult)> Int64PositiveDataSource()
    {
        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x7f }, 34_359_738_367);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_368);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_369);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_370);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 4_398_046_511_103);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_104);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_105);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_106);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 562_949_953_421_311);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_312);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_313);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_314);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 72_057_594_037_927_935);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_936);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_937);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_938);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, long.MaxValue);
    }

    public static IEnumerable<(Memory<byte> data, long expectedResult)> Int64NegativeDataSource()
    {
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, long.MinValue);
    }

    public static IEnumerable<(Memory<byte> data, short expectedResult)> SInt16DataSource()
    {
        yield return (new byte[] { 0x00 }, 0);
        yield return (new byte[] { 0x01 }, -1);
        yield return (new byte[] { 0x02 }, 1);
        yield return (new byte[] { 0x03 }, -2);

        yield return (new byte[] { 0x7f }, -64);
        yield return (new byte[] { 0x80, 0x01 }, 64);
        yield return (new byte[] { 0x81, 0x01 }, -65);
        yield return (new byte[] { 0x82, 0x01 }, 65);

        yield return (new byte[] { 0xff, 0x7f }, -8_192);
        yield return (new byte[] { 0x80, 0x80, 0x01 }, 8_192);
        yield return (new byte[] { 0x81, 0x80, 0x01 }, -8_193);
        yield return (new byte[] { 0x82, 0x80, 0x01 }, 8_193);

        yield return (new byte[] { 0xfc, 0xff, 0x03 }, short.MaxValue - 1);
        yield return (new byte[] { 0xfd, 0xff, 0x03 }, short.MinValue + 1);
        yield return (new byte[] { 0xfe, 0xff, 0x03 }, short.MaxValue);
        yield return (new byte[] { 0xff, 0xff, 0x03 }, short.MinValue);
    }

    public static IEnumerable<(Memory<byte> data, int expectedResult)> SInt32DataSource()
    {
        yield return (new byte[] { 0xff, 0xff, 0x7f }, -1_048_576);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x01 }, 1_048_576);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x01 }, -1_048_577);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x01 }, 1_048_577);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0x7f }, -134_217_728);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x01 }, 134_217_728);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x01 }, -134_217_729);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x01 }, 134_217_729);

        yield return (new byte[] { 0xfc, 0xff, 0xff, 0xff, 0x0f }, int.MaxValue - 1);
        yield return (new byte[] { 0xfd, 0xff, 0xff, 0xff, 0x0f }, int.MinValue + 1);
        yield return (new byte[] { 0xfe, 0xff, 0xff, 0xff, 0x0f }, int.MaxValue);
        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x0f }, int.MinValue);
    }

    public static IEnumerable<(Memory<byte> data, long expectedResult)> SInt64DataSource()
    {
        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x7f }, -17_179_869_184);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 17_179_869_184);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x01 }, -17_179_869_185);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x01 }, 17_179_869_185);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, -2_199_023_255_552);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 2_199_023_255_552);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, -2_199_023_255_553);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 2_199_023_255_553);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, -281_474_976_710_656);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 281_474_976_710_656);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, -281_474_976_710_657);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 281_474_976_710_657);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, -36_028_797_018_963_968);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 36_028_797_018_963_968);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, -36_028_797_018_963_969);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 36_028_797_018_963_969);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, -4_611_686_018_427_387_904);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_611_686_018_427_387_904);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, -4_611_686_018_427_387_905);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_611_686_018_427_387_905);

        yield return (new byte[] { 0xfc, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x03 }, long.MaxValue - 1);
        yield return (new byte[] { 0xfd, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x03 }, long.MinValue + 1);
        yield return (new byte[] { 0xfe, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x03 }, long.MaxValue);
        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x03 }, long.MinValue);
    }

    public static IEnumerable<(Memory<byte> data, ushort expectedResult)> UInt16DataSource()
    {
        yield return (new byte[] { 0x00 }, 0);
        yield return (new byte[] { 0x01 }, 1);
        yield return (new byte[] { 0x02 }, 2);

        yield return (new byte[] { 0x7f }, 127);
        yield return (new byte[] { 0x80, 0x01 }, 128);
        yield return (new byte[] { 0x81, 0x01 }, 129);
        yield return (new byte[] { 0x82, 0x01 }, 130);

        yield return (new byte[] { 0xff, 0x7f }, 16_383);
        yield return (new byte[] { 0x80, 0x80, 0x01 }, 16_384);
        yield return (new byte[] { 0x81, 0x80, 0x01 }, 16_385);
        yield return (new byte[] { 0x82, 0x80, 0x01 }, 16_386);

        yield return (new byte[] { 0xff, 0xff, 0x03 }, ushort.MaxValue);
    }

    public static IEnumerable<(Memory<byte> data, uint expectedResult)> UInt32DataSource()
    {
        yield return (new byte[] { 0xff, 0xff, 0x7f }, 2_097_151);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x01 }, 2_097_152);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x01 }, 2_097_153);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x01 }, 2_097_154);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0x7f }, 268_435_455);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x01 }, 268_435_456);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x01 }, 268_435_457);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x01 }, 268_435_458);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x0f }, uint.MaxValue);
    }

    public static IEnumerable<(Memory<byte> data, ulong expectedResult)> UInt64DataSource()
    {
        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x7f }, 34_359_738_367);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_368);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_369);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_370);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 4_398_046_511_103);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_104);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_105);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_106);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 562_949_953_421_311);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_312);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_313);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_314);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 72_057_594_037_927_935);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_936);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_937);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_938);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 9_223_372_036_854_775_807);
        yield return (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 9_223_372_036_854_775_808);
        yield return (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 9_223_372_036_854_775_809);
        yield return (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 9_223_372_036_854_775_810);

        yield return (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x01 }, ulong.MaxValue);
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
