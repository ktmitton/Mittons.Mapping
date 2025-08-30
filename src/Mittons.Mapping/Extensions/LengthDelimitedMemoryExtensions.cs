using System.Text;

namespace Mittons.Mapping.Extensions;

public static class ReadLengthDelimitedMemoryExtensions
{
    public static Memory<byte> ReadLengthDelimited(this Memory<byte> memory, ref int memoryPosition)
    {
        var length = memory.ReadVarInt(ref memoryPosition).AsUInt16();

        Memory<byte> result = memory.Slice(memoryPosition, length);

        memoryPosition += length;

        return result;
    }

    public static string AsString(this Memory<byte> memory)
    {
        return Encoding.UTF8.GetString(memory.Span);
    }

    public static byte[] AsBytes(this Memory<byte> memory)
    {
        return memory.ToArray();
    }

    public static byte[] AsEmbeddedMessages(this Memory<byte> memory)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<string> AsPackedRepeatedStringFields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadLengthDelimited(ref memoryPosition);

            yield return lengthDelimited.AsString();
        }
    }

    public static IEnumerable<int> AsPackedRepeatedInt32Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsInt32();
        }
    }

    public static IEnumerable<long> AsPackedRepeatedInt64Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsInt64();
        }
    }

    public static IEnumerable<int> AsPackedRepeatedSInt32Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsSInt32();
        }
    }

    public static IEnumerable<long> AsPackedRepeatedSInt64Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsSInt64();
        }
    }

    public static IEnumerable<uint> AsPackedRepeatedUInt32Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsUInt32();
        }
    }

    public static IEnumerable<ulong> AsPackedRepeatedUInt64Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsUInt64();
        }
    }
}
