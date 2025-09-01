using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class Way : IEquatable<Way>
{
    public long Id { get; init; } = -1;
    public uint[]? Keys { get; init; }
    public uint[]? Values { get; init; }
    public Info? Info { get; init; }
    public long[]? References { get; init; }
    public long[]? Latitudes { get; init; }
    public long[]? Longitudes { get; init; }

    public const byte IdFieldNumber = 1;
    public const byte KeySegmentsFieldNumber = 2;
    public const byte ValuesFieldNumber = 3;
    public const byte InfoFieldNumber = 4;
    public const byte ReferencesFieldNumber = 8;
    public const byte LatitudesFieldNumber = 9;
    public const byte LongitudesFieldNumber = 10;

    public Way() { }

    public Way(Memory<byte> source)
    {
        int memoryPosition = 0;
        while (memoryPosition < source.Length)
        {
            switch (source.Span[memoryPosition++] >> 3)
            {
                case IdFieldNumber:
                    Id = source.ReadInt64(ref memoryPosition);
                    continue;
                case InfoFieldNumber:
                    Info = source.ReadInfo(ref memoryPosition);
                    continue;
                case KeySegmentsFieldNumber:
                    Keys = [.. source.ReadPackedUInt32(ref memoryPosition)];
                    break;
                case ValuesFieldNumber:
                    Values = [.. source.ReadPackedUInt32(ref memoryPosition)];
                    break;
                case ReferencesFieldNumber:
                    References = [.. source.ReadPackedDeltaCodedSInt64(ref memoryPosition)];
                    break;
                case LatitudesFieldNumber:
                    Latitudes = [.. source.ReadPackedDeltaCodedSInt64(ref memoryPosition)];
                    break;
                case LongitudesFieldNumber:
                    Longitudes = [.. source.ReadPackedDeltaCodedSInt64(ref memoryPosition)];
                    break;
                default:
                    throw new InvalidOperationException($"Unknown field number [{source.Span[memoryPosition - 1] >> 3}] in Way message.");
            }
        }
    }

    public bool Equals(Way? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id == other.Id &&
               (Keys ?? []).SequenceEqual(other.Keys ?? []) &&
               (Values ?? []).SequenceEqual(other.Values ?? []) &&
               Info == other.Info &&
               (References ?? []).SequenceEqual(other.References ?? []) &&
               (Latitudes ?? []).SequenceEqual(other.Latitudes ?? []) &&
               (Longitudes ?? []).SequenceEqual(other.Longitudes ?? []);
    }

    public override bool Equals(object? obj) => Equals(obj as Way);
    public override int GetHashCode()
    {
        return HashCode.Combine(
            Id,
            GetArrayHashCode(Keys),
            GetArrayHashCode(Values),
            Info,
            GetArrayHashCode(References),
            GetArrayHashCode(Latitudes),
            GetArrayHashCode(Longitudes)
        );
    }
    private static int GetArrayHashCode<T>(T[]? array)
    {
        if (array is null)
            return 0;
        var hash = new HashCode();
        foreach (var item in array)
        {
            hash.Add(item);
        }
        return hash.ToHashCode();
    }
    public static bool operator ==(Way left, Way right) => left?.Equals(right) ?? right is null;
    public static bool operator !=(Way left, Way right) => !(left == right);
}

internal static class WayMemoryExtensions
{
    internal static Way AsWay(this Memory<byte> source)
    {
        return new Way(source);
    }
}
