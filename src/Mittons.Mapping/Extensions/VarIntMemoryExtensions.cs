namespace Mittons.Mapping.Extensions;

public static class VarIntMemoryExtensions
{
    public static Memory<byte> ReadVarInt(this Memory<byte> memory, ref int memoryPosition)
    {
        byte count = 0;

        do { ++count; } while ((memory.Span[memoryPosition + count - 1] & 0x80) != 0);

        Memory<byte> result = memory.Slice(memoryPosition, count);

        memoryPosition += count;

        return result;
    }

    public static bool ToBool(this Memory<byte> memory)
        => memory.Span[0] != 0;

    public static T ToEnum<T>(this Memory<byte> memory) where T : Enum
        => (T)(object)memory.ToInt32();

    public static int ToInt32(this Memory<byte> memory)
        => memory.Length switch
        {
            1 => memory.Span[0],
            2 => (memory.Span[0] & 0x7f) | (memory.Span[1] << 7),
            3 => (memory.Span[0] & 0x7f) | ((memory.Span[1] & 0x7f) << 7) | (memory.Span[2] << 14),
            4 => (memory.Span[0] & 0x7f) | ((memory.Span[1] & 0x7f) << 7) | ((memory.Span[2] & 0x7f) << 14) | (memory.Span[3] << 21),
            5 => (memory.Span[0] & 0x7f) | ((memory.Span[1] & 0x7f) << 7) | ((memory.Span[2] & 0x7f) << 14) | ((memory.Span[3] & 0x7f) << 21) | (memory.Span[4] << 28),
            _ => throw new InvalidOperationException("VarInt is too large to fit in an Int32."),
        };

    public static long ToInt64(this Memory<byte> memory)
        => memory.Length switch
        {
            1 => (long)memory.Span[0],
            2 => ((long)memory.Span[0] & 0x7f) | ((long)memory.Span[1] << 7),
            3 => ((long)memory.Span[0] & 0x7f) | (((long)memory.Span[1] & 0x7f) << 7) | ((long)memory.Span[2] << 14),
            4 => ((long)memory.Span[0] & 0x7f) | (((long)memory.Span[1] & 0x7f) << 7) | (((long)memory.Span[2] & 0x7f) << 14) | (((long)memory.Span[3] & 0x7f) << 21),
            5 => ((long)memory.Span[0] & 0x7f) | (((long)memory.Span[1] & 0x7f) << 7) | (((long)memory.Span[2] & 0x7f) << 14) | (((long)memory.Span[3] & 0x7f) << 21) | (((long)memory.Span[4] & 0x7f) << 28),
            6 => ((long)memory.Span[0] & 0x7f) | (((long)memory.Span[1] & 0x7f) << 7) | (((long)memory.Span[2] & 0x7f) << 14) | (((long)memory.Span[3] & 0x7f) << 21) | (((long)memory.Span[4] & 0x7f) << 28) | (((long)memory.Span[5] & 0x7f) << 35),
            7 => ((long)memory.Span[0] & 0x7f) | (((long)memory.Span[1] & 0x7f) << 7) | (((long)memory.Span[2] & 0x7f) << 14) | (((long)memory.Span[3] & 0x7f) << 21) | (((long)memory.Span[4] & 0x7f) << 28) | (((long)memory.Span[5] & 0x7f) << 35) | (((long)memory.Span[6] & 0x7f) << 42),
            8 => ((long)memory.Span[0] & 0x7f) | (((long)memory.Span[1] & 0x7f) << 7) | (((long)memory.Span[2] & 0x7f) << 14) | (((long)memory.Span[3] & 0x7f) << 21) | (((long)memory.Span[4] & 0x7f) << 28) | (((long)memory.Span[5] & 0x7f) << 35) | (((long)memory.Span[6] & 0x7f) << 42) | (((long)memory.Span[7] & 0x7f) << 49),
            9 => ((long)memory.Span[0] & 0x7f) | (((long)memory.Span[1] & 0x7f) << 7) | (((long)memory.Span[2] & 0x7f) << 14) | (((long)memory.Span[3] & 0x7f) << 21) | (((long)memory.Span[4] & 0x7f) << 28) | (((long)memory.Span[5] & 0x7f) << 35) | (((long)memory.Span[6] & 0x7f) << 42) | (((long)memory.Span[7] & 0x7f) << 49) | (((long)memory.Span[8] & 0x7f) << 56),
            10 => ((long)memory.Span[0] & 0x7f) | (((long)memory.Span[1] & 0x7f) << 7) | (((long)memory.Span[2] & 0x7f) << 14) | (((long)memory.Span[3] & 0x7f) << 21) | (((long)memory.Span[4] & 0x7f) << 28) | (((long)memory.Span[5] & 0x7f) << 35) | (((long)memory.Span[6] & 0x7f) << 42) | (((long)memory.Span[7] & 0x7f) << 49) | (((long)memory.Span[8] & 0x7f) << 56) | ((long)memory.Span[9] << 63),
            _ => throw new InvalidOperationException("VarInt is too large to fit in an Int64."),
        };

    public static int ToSInt32(this Memory<byte> memory)
    {
        uint value = memory.ToUInt32();

        return (int)((value >> 1) ^ -(value & 1));
    }

    public static long ToSInt64(this Memory<byte> memory)
    {
        ulong value = memory.ToUInt64();

        return (value & 1) == 0 ? (long)(value >> 1) : (long)(value >> 1) * -1 - 1;
    }

    public static ushort ToUInt16(this Memory<byte> memory)
        => memory.Length switch
        {
            1 => memory.Span[0],
            2 => (ushort)((memory.Span[0] & 0x7f) | (memory.Span[1] << 7)),
            3 => (ushort)((memory.Span[0] & 0x7f) | ((memory.Span[1] & 0x7f) << 7) | (memory.Span[2] << 14)),
            _ => throw new InvalidOperationException("VarInt is too large to fit in an Int32."),
        };

    public static uint ToUInt32(this Memory<byte> memory)
        => memory.Length switch
        {
            1 => memory.Span[0],
            2 => 0u | ((uint)memory.Span[1] << 7) | ((uint)memory.Span[0] & 0x7f),
            3 => 0u | ((uint)memory.Span[2] << 14) | ((uint)(memory.Span[1] & 0x7f) << 7) | ((uint)memory.Span[0] & 0x7f),
            4 => 0u | ((uint)memory.Span[3] << 21) | ((uint)(memory.Span[2] & 0x7f) << 14) | ((uint)(memory.Span[1] & 0x7f) << 7) | ((uint)memory.Span[0] & 0x7f),
            5 => 0u | ((uint)memory.Span[4] << 28) | ((uint)(memory.Span[3] & 0x7f) << 21) | ((uint)(memory.Span[2] & 0x7f) << 14) | ((uint)(memory.Span[1] & 0x7f) << 7) | ((uint)memory.Span[0] & 0x7f),
            _ => throw new InvalidOperationException("VarInt is too large to fit in an Int32."),
        };

    public static ulong ToUInt64(this Memory<byte> memory)
        => memory.Length switch
        {
            1 => memory.Span[0],
            2 => 0UL | ((ulong)memory.Span[1] << 7) | ((ulong)memory.Span[0] & 0x7f),
            3 => 0UL | ((ulong)memory.Span[2] << 14) | ((ulong)(memory.Span[1] & 0x7f) << 7) | ((ulong)memory.Span[0] & 0x7f),
            4 => 0UL | ((ulong)memory.Span[3] << 21) | ((ulong)(memory.Span[2] & 0x7f) << 14) | ((ulong)(memory.Span[1] & 0x7f) << 7) | ((ulong)memory.Span[0] & 0x7f),
            5 => 0UL | ((ulong)memory.Span[4] << 28) | ((ulong)(memory.Span[3] & 0x7f) << 21) | ((ulong)(memory.Span[2] & 0x7f) << 14) | ((ulong)(memory.Span[1] & 0x7f) << 7) | ((ulong)memory.Span[0] & 0x7f),
            6 => 0UL | ((ulong)memory.Span[5] << 35) | ((ulong)(memory.Span[4] & 0x7f) << 28) | ((ulong)(memory.Span[3] & 0x7f) << 21) | ((ulong)(memory.Span[2] & 0x7f) << 14) | ((ulong)(memory.Span[1] & 0x7f) << 7) | ((ulong)memory.Span[0] & 0x7f),
            7 => 0UL | ((ulong)memory.Span[6] << 42) | ((ulong)(memory.Span[5] & 0x7f) << 35) | ((ulong)(memory.Span[4] & 0x7f) << 28) | ((ulong)(memory.Span[3] & 0x7f) << 21) | ((ulong)(memory.Span[2] & 0x7f) << 14) | ((ulong)(memory.Span[1] & 0x7f) << 7) | ((ulong)memory.Span[0] & 0x7f),
            8 => 0UL | ((ulong)memory.Span[7] << 49) | ((ulong)(memory.Span[6] & 0x7f) << 42) | ((ulong)(memory.Span[5] & 0x7f) << 35) | ((ulong)(memory.Span[4] & 0x7f) << 28) | ((ulong)(memory.Span[3] & 0x7f) << 21) | ((ulong)(memory.Span[2] & 0x7f) << 14) | ((ulong)(memory.Span[1] & 0x7f) << 7) | ((ulong)memory.Span[0] & 0x7f),
            9 => 0UL | ((ulong)memory.Span[8] << 56) | ((ulong)(memory.Span[7] & 0x7f) << 49) | ((ulong)(memory.Span[6] & 0x7f) << 42) | ((ulong)(memory.Span[5] & 0x7f) << 35) | ((ulong)(memory.Span[4] & 0x7f) << 28) | ((ulong)(memory.Span[3] & 0x7f) << 21) | ((ulong)(memory.Span[2] & 0x7f) << 14) | ((ulong)(memory.Span[1] & 0x7f) << 7) | ((ulong)memory.Span[0] & 0x7f),
            10 => 0UL | ((ulong)memory.Span[9] << 63) | ((ulong)(memory.Span[8] & 0x7f) << 56) | ((ulong)(memory.Span[7] & 0x7f) << 49) | ((ulong)(memory.Span[6] & 0x7f) << 42) | ((ulong)(memory.Span[5] & 0x7f) << 35) | ((ulong)(memory.Span[4] & 0x7f) << 28) | ((ulong)(memory.Span[3] & 0x7f) << 21) | ((ulong)(memory.Span[2] & 0x7f) << 14) | ((ulong)(memory.Span[1] & 0x7f) << 7) | ((ulong)memory.Span[0] & 0x7f),
            _ => throw new InvalidOperationException("VarInt is too large to fit in an Int64."),
        };
}
