using Mittons.Mapping.Extensions;
using Mittons.Mapping.Tests.Data.Protobuf.Wire.LengthDelimited;

namespace Mittons.Mapping.Tests.Extensions;

public class LengthDelimitedMemoryExtensionsTests
{
    [Test]
    [MethodDataSource(nameof(LengthDelimitedDataSource))]
    public async Task ReadLengthDelimited(Memory<byte> data, Memory<byte> expectedResult, int originalPosition, int expectedPosition)
    {
        int position = originalPosition;

        var actualResult = data.ReadLengthDelimited(ref position);

        await Assert.That(position).IsEqualTo(expectedPosition);
        await Assert.That(actualResult.ToArray()).IsEquivalentTo(expectedResult.ToArray());
    }

    [Test]
    [StringData]
    public async Task AsString(Memory<byte> data, string expectedResult)
    {
        var actualResult = data.AsString();

        await Assert.That(actualResult).IsEqualTo(expectedResult);
    }

    [Test]
    [BytesData]
    public async Task AsBytes(Memory<byte> data, byte[] expectedResult)
    {
        var actualResult = data.AsBytes();

        await Assert.That(actualResult).IsEquivalentTo(expectedResult);
    }

    // [Test]
    // [MethodDataSource(nameof(EmbeddedMessagesDatasource))]
    // public async Task AsEmbeddedMessages(Memory<byte> data, byte[] expectedResult)
    // {
    //     var actualResult = data.AsEmbeddedMessages();

    //     await Assert.That(actualResult).IsEqualTo(expectedResult);
    // }

    [Test]
    [PackedRepeatedStringData]
    public async Task AsPackedRepeatedStringFields(Memory<byte> data, string[] expectedResult)
    {
        var actualResult = data.AsPackedRepeatedStringFields();

        await Assert.That(actualResult).IsEquivalentTo(expectedResult);
    }

    [Test]
    [PackedRepeatedInt32Data]
    public async Task AsPackedRepeatedInt32Fields(Memory<byte> data, int[] expectedResult)
    {
        var actualResult = data.AsPackedRepeatedInt32Fields();

        await Assert.That(actualResult).IsEquivalentTo(expectedResult);
    }

    [Test]
    [PackedRepeatedInt64Data]
    public async Task AsPackedRepeatedInt64Fields(Memory<byte> data, long[] expectedResult)
    {
        var actualResult = data.AsPackedRepeatedInt64Fields();

        await Assert.That(actualResult).IsEquivalentTo(expectedResult);
    }

    [Test]
    [PackedRepeatedSInt32Data]
    public async Task AsPackedRepeatedSInt32Fields(Memory<byte> data, int[] expectedResult)
    {
        var actualResult = data.AsPackedRepeatedSInt32Fields();

        await Assert.That(actualResult).IsEquivalentTo(expectedResult);
    }

    [Test]
    [PackedRepeatedSInt64Data]
    public async Task AsPackedRepeatedSInt64Fields(Memory<byte> data, long[] expectedResult)
    {
        var actualResult = data.AsPackedRepeatedSInt64Fields();

        await Assert.That(actualResult).IsEquivalentTo(expectedResult);
    }

    [Test]
    [PackedRepeatedUInt32Data]
    public async Task AsPackedRepeatedUInt32Fields(Memory<byte> data, uint[] expectedResult)
    {
        var actualResult = data.AsPackedRepeatedUInt32Fields();

        await Assert.That(actualResult).IsEquivalentTo(expectedResult);
    }

    [Test]
    [PackedRepeatedUInt64Data]
    public async Task AsPackedRepeatedUInt64Fields(Memory<byte> data, ulong[] expectedResult)
    {
        var actualResult = data.AsPackedRepeatedUInt64Fields();

        await Assert.That(actualResult).IsEquivalentTo(expectedResult);
    }

    public static IEnumerable<(Memory<byte> data, Memory<byte> expectedResult, int originalPosition, int expectedPosition)> LengthDelimitedDataSource()
    {
        yield return (
            new byte[] { 0x09, 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72 },
            new byte[] { 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72 },
            0,
            10
        );
        yield return (
            new byte[] { 0x00, 0x00, 0x09, 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72 },
            new byte[] { 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72 },
            2,
            12
        );
        yield return (
            new byte[] { 0x09, 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72, 0x00, 0x00 },
            new byte[] { 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72 },
            0,
            10
        );
        yield return (
            new byte[] { 0x00, 0x00, 0x09, 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72, 0x00, 0x00 },
            new byte[] { 0x4f, 0x53, 0x4d, 0x48, 0x65, 0x61, 0x64, 0x65, 0x72 },
            2,
            12
        );

        yield return (
            new byte[] { 0x10, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f },
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f },
            0,
            17
        );
        yield return (
            new byte[] { 0x00, 0x00, 0x10, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f },
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f },
            2,
            19
        );
        yield return (
            new byte[] { 0x10, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x00, 0x00 },
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f },
            0,
            17
        );
        yield return (
            new byte[] { 0x00, 0x00, 0x10, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x00, 0x00 },
            new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f },
            2,
            19
        );
    }

    public static IEnumerable<(byte[] data, byte[] expectedResult)> EmbeddedMessagesDatasource()
    {
        yield return (new byte[] { 0x10, 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f }, new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f });
    }

    public static IEnumerable<(byte[] data, uint[] expectedResult)> PackedRepeatedUInt32DataSource()
    {
        IEnumerable<(byte[] bytes, uint value)> datapoints = [
            (new byte[] { 0xff, 0xff, 0x7f }, 2_097_151),
            (new byte[] { 0x80, 0x80, 0x80, 0x01 }, 2_097_152),
            (new byte[] { 0x81, 0x80, 0x80, 0x01 }, 2_097_153),
            (new byte[] { 0x82, 0x80, 0x80, 0x01 }, 2_097_154),
            (new byte[] { 0xff, 0xff, 0xff, 0x7f }, 268_435_455),
            (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x01 }, 268_435_456),
            (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x01 }, 268_435_457),
            (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x01 }, 268_435_458),
            (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x0f }, uint.MaxValue),
        ];

        foreach (var variation in CreateVariations(datapoints))
        {
            yield return variation;
        }
    }

    public static IEnumerable<(byte[] data, ulong[] expectedResult)> PackedRepeatedUInt64DataSource()
    {
        IEnumerable<(byte[] bytes, ulong value)> datapoints = [
            (new byte[] { 0xff, 0xff, 0xff, 0xff, 0x7f }, 34_359_738_367),
            (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_368),
            (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_369),
            (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x01 }, 34_359_738_370),
            (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 4_398_046_511_103),
            (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_104),
            (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_105),
            (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 4_398_046_511_106),
            (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 562_949_953_421_311),
            (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_312),
            (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_313),
            (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 562_949_953_421_314),
            (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 72_057_594_037_927_935),
            (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_936),
            (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_937),
            (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 72_057_594_037_927_938),
            (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, 9_223_372_036_854_775_807),
            (new byte[] { 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 9_223_372_036_854_775_808),
            (new byte[] { 0x81, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 9_223_372_036_854_775_809),
            (new byte[] { 0x82, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x01 }, 9_223_372_036_854_775_810),
            (new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x01 }, ulong.MaxValue),
        ];

        foreach (var variation in CreateVariations(datapoints))
        {
            yield return variation;
        }
    }

    private static IEnumerable<(byte[] bytes, uint[] value)> CreateVariations(IEnumerable<(byte[] bytes, uint value)> source)
    {
        foreach (var (bytes, value) in source)
        {
            yield return (bytes, [value]);
        }

        foreach (var (bytes, value) in source.Reverse())
        {
            yield return (bytes, [value]);
        }

        yield return ([.. source.SelectMany(x => x.bytes)], [.. source.Select(x => x.value)]);
    }

    private static IEnumerable<(byte[] bytes, ulong[] value)> CreateVariations(IEnumerable<(byte[] bytes, ulong value)> source)
    {
        foreach (var (bytes, value) in source)
        {
            yield return (bytes, [value]);
        }

        foreach (var (bytes, value) in source.Reverse())
        {
            yield return (bytes, [value]);
        }

        yield return ([.. source.SelectMany(x => x.bytes)], [.. source.Select(x => x.value)]);
    }
}
