using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class HeaderBoundingBox : IEquatable<HeaderBoundingBox>
{
    public long Left { get; init; }
    public long Right { get; init; }
    public long Top { get; init; }
    public long Bottom { get; init; }

    public const byte LeftFieldNumber = 1;
    public const byte RightFieldNumber = 2;
    public const byte TopFieldNumber = 3;
    public const byte BottomFieldNumber = 4;

    public HeaderBoundingBox() { }

    public HeaderBoundingBox(Memory<byte> source)
    {
        int memoryPosition = 0;
        while (memoryPosition < source.Length)
        {
            switch (source.Span[memoryPosition++] >> 3)
            {
                case LeftFieldNumber:
                    Left = source.ReadVarInt(ref memoryPosition).AsSInt64();
                    continue;
                case RightFieldNumber:
                    Right = source.ReadVarInt(ref memoryPosition).AsSInt64();
                    continue;
                case TopFieldNumber:
                    Top = source.ReadVarInt(ref memoryPosition).AsSInt64();
                    continue;
                case BottomFieldNumber:
                    Bottom = source.ReadVarInt(ref memoryPosition).AsSInt64();
                    continue;
                default:
                    throw new InvalidOperationException($"Unknown field number [{source.Span[memoryPosition - 1] >> 3}] in HeaderBoundingBox message.");
            }
        }
    }

    public override int GetHashCode() => HashCode.Combine(Left, Right, Top, Bottom);
    public bool Equals(HeaderBoundingBox? other)
    {
        if (other is null) return false;
        return Left == other.Left && Right == other.Right && Top == other.Top && Bottom == other.Bottom;
    }
    public override bool Equals(object? obj) => Equals(obj as HeaderBoundingBox);
    public static bool operator ==(HeaderBoundingBox? left, HeaderBoundingBox? right) => left?.Equals(right) ?? right is null;
    public static bool operator !=(HeaderBoundingBox? left, HeaderBoundingBox? right) => !(left == right);
}

internal static class HeaderBoundingBoxMemoryExtensions
{
    internal static HeaderBoundingBox AsHeaderBoundingBox(this Memory<byte> source)
    {
        return new HeaderBoundingBox(source);
    }

    internal static HeaderBoundingBox ReadHeaderBoundingBox(this Memory<byte> source, ref int memoryPosition)
    {
        var length = source.ReadUInt16(ref memoryPosition);

        var boundingBox = source.Slice(memoryPosition, length).AsHeaderBoundingBox();

        memoryPosition += length;

        return boundingBox;
    }
}
