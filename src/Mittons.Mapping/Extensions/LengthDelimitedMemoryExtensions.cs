using System.Text;

namespace Mittons.Mapping.Extensions;

public static class ReadLengthDelimitedMemoryExtensions
{
    public static string ReadString(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsString();

    public static string? ReadNullableString(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsNullableString();

    public static byte[] ReadBytes(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsBytes();

    public static IEnumerable<string> ReadPackedRepeatedStrings(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedStringFields();

    public static IEnumerable<T> ReadPackedEnum<T>(this Memory<byte> memory, ref int memoryPosition) where T : Enum
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedEnumFields<T>();

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

    public static IEnumerable<int> ReadPackedDeltaCodedInt32(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedDeltaCodedInt32Fields();

    public static IEnumerable<long> ReadPackedDeltaCodedInt64(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedDeltaCodedInt64Fields();

    public static IEnumerable<int> ReadPackedDeltaCodedSInt32(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedDeltaCodedSInt32Fields();

    public static IEnumerable<long> ReadPackedDeltaCodedSInt64(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedDeltaCodedSInt64Fields();

    public static IEnumerable<uint> ReadPackedDeltaCodedUInt32(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedDeltaCodedUInt32Fields();

    public static IEnumerable<ulong> ReadPackedDeltaCodedUInt64(this Memory<byte> memory, ref int memoryPosition)
        => memory.ReadLengthDelimited(ref memoryPosition).AsPackedRepeatedDeltaCodedUInt64Fields();

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

    internal static string? AsNullableString(this Memory<byte> memory)
    {
        return memory.Length == 0 ? null : Encoding.UTF8.GetString(memory.Span);
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

    internal static IEnumerable<T> AsPackedRepeatedEnumFields<T>(this Memory<byte> memory) where T : Enum
    {
        int memoryPosition = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            yield return lengthDelimited.AsEnum<T>();
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

    internal static IEnumerable<int> AsPackedRepeatedDeltaCodedInt32Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        int previousValue = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            previousValue += lengthDelimited.AsInt32();

            yield return previousValue;
        }
    }

    internal static IEnumerable<long> AsPackedRepeatedDeltaCodedInt64Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        long previousValue = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            previousValue += lengthDelimited.AsInt64();

            yield return previousValue;
        }
    }

    internal static IEnumerable<int> AsPackedRepeatedDeltaCodedSInt32Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        int previousValue = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            previousValue += lengthDelimited.AsSInt32();

            yield return previousValue;
        }
    }

    internal static IEnumerable<long> AsPackedRepeatedDeltaCodedSInt64Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        long previousValue = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            previousValue += lengthDelimited.AsSInt64();

            yield return previousValue;
        }
    }

    internal static IEnumerable<uint> AsPackedRepeatedDeltaCodedUInt32Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        uint previousValue = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            previousValue += lengthDelimited.AsUInt32();

            yield return previousValue;
        }
    }

    internal static IEnumerable<ulong> AsPackedRepeatedDeltaCodedUInt64Fields(this Memory<byte> memory)
    {
        int memoryPosition = 0;

        ulong previousValue = 0;

        while (memoryPosition < memory.Length)
        {
            Memory<byte> lengthDelimited = memory.ReadVarInt(ref memoryPosition);

            previousValue += lengthDelimited.AsUInt64();

            yield return previousValue;
        }
    }
}
