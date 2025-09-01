using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class Node : IEquatable<Node>
{
    public long Id { get; init; }
    public uint[] Keys { get; init; } = [];
    public uint[] Values { get; init; } = [];
    public Info? Info { get; init; }
    public long Latitude { get; init; }
    public long Longitude { get; init; }

    public const byte IdFieldNumber = 1;
    public const byte KeysFieldNumber = 2;
    public const byte ValuesFieldNumber = 3;
    public const byte InfoFieldNumber = 4;
    public const byte LatitudeFieldNumber = 8;
    public const byte LongitudeFieldNumber = 9;

    public Node() { }

    public Node(Memory<byte> source)
    {
        int memoryPosition = 0;
        while (memoryPosition < source.Length)
        {
            switch (source.Span[memoryPosition++] >> 3)
            {
                case IdFieldNumber:
                    Id = source.ReadInt64(ref memoryPosition);
                    continue;
                case KeysFieldNumber:
                    Keys = [.. source.ReadPackedUInt32(ref memoryPosition)];
                    continue;
                case ValuesFieldNumber:
                    Values = [.. source.ReadPackedUInt32(ref memoryPosition)];
                    continue;
                case InfoFieldNumber:
                    Info = source.ReadInfo(ref memoryPosition);
                    continue;
                case LatitudeFieldNumber:
                    Latitude = source.ReadSInt64(ref memoryPosition);
                    continue;
                case LongitudeFieldNumber:
                    Longitude = source.ReadSInt64(ref memoryPosition);
                    continue;
                default:
                    throw new InvalidOperationException($"Unknown field number {source.Span[memoryPosition - 1] >> 3} encountered while reading Node from memory.");
            }
        }
    }

    public bool Equals(Node? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id == other.Id &&
               Keys.SequenceEqual(other.Keys) &&
               Values.SequenceEqual(other.Values) &&
               Info == other.Info &&
               Latitude == other.Latitude &&
               Longitude == other.Longitude;
    }

        var hash = new HashCode();
        hash.Add(Id);
        foreach (var key in Keys)
            hash.Add(key);
        foreach (var value in Values)
            hash.Add(value);
        hash.Add(Info);
        hash.Add(Latitude);
        hash.Add(Longitude);
        return hash.ToHashCode();
    }
    public static bool operator ==(Node? left, Node? right) => Equals(left, right);
    public static bool operator !=(Node? left, Node? right) => !Equals(left, right);
    public override bool Equals(object? obj) => Equals(obj as Node);
}

internal static class NodeMemoryExtensions
{
    internal static Node AsNode(this Memory<byte> source)
    {
        return new Node(source);
    }
}
