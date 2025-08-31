using System.Text;

namespace Mittons.Mapping.Extensions;

public static class ReadLengthDelimitedMemoryExtensions
{
    public static string ReadString(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsString();

    public static byte[] ReadBytes(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsBytes();

    public static IEnumerable<string> ReadPackedRepeatedStrings(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedStringFields();

    public static IEnumerable<int> ReadPackedInt32(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedInt32Fields();

    public static IEnumerable<long> ReadPackedInt64(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedInt64Fields();

    public static IEnumerable<int> ReadPackedSInt32(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedSInt32Fields();

    public static IEnumerable<long> ReadPackedSInt64(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedSInt64Fields();

    public static IEnumerable<uint> ReadPackedUInt32(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedUInt32Fields();

    public static IEnumerable<ulong> ReadPackedUInt64(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedUInt64Fields();

    internal static Memory<byte> ReadLengthDelimited(this Memory<byte> memory, ref int memoryPosition)
    {
        var length = memory.ReadVarInt(ref memoryPosition).AsUInt16();

        Memory<byte> result = memory.Slice(memoryPosition, length);

        memoryPosition += length;

        return result;
    }

    internal static string AsString(this Memory<byte> memory)
    {
        return Encoding.UTF8.GetString(memory.Span);
    }

    internal static byte[] AsBytes(this Memory<byte> memory)
    {
        return memory.ToArray();
    }

    internal static byte[] AsEmbeddedMessages(this Memory<byte> memory)
    {
        throw new NotImplementedException();
    }

    internal static IEnumerable<string> AsPackedRepeatedStringFields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadLengthDelimited(ref memoryPosition);

            yield return lengthDelimited.AsString();
        }
    }

    internal static IEnumerable<int> AsPackedRepeatedInt32Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsInt32();
        }
    }

    internal static IEnumerable<long> AsPackedRepeatedInt64Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsInt64();
        }
    }

    internal static IEnumerable<int> AsPackedRepeatedSInt32Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsSInt32();
        }
    }

    internal static IEnumerable<long> AsPackedRepeatedSInt64Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsSInt64();
        }
    }

    internal static IEnumerable<uint> AsPackedRepeatedUInt32Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsUInt32();
        }
    }

    internal static IEnumerable<ulong> AsPackedRepeatedUInt64Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsUInt64();
        }
    }
}
