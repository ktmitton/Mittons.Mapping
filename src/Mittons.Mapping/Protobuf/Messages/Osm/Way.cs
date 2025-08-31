using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class Way : IEquatable<Way>
{
    public long Id { get; init; }
    public uint[] Keys { get; init; } = [];
    public uint[] Values { get; init; } = [];
    public Info? Info { get; init; }
    public long[] References { get; init; } = [];
    public long[] Latitudes { get; init; } = [];
    public long[] Longitudes { get; init; } = [];

    public const byte IdFieldNumber = 1;
    public const byte KeySegmentsFieldNumber = 2;
    public const byte ValuesFieldNumber = 3;
    public const byte InfoFieldNumber = 4;
    public const byte ReferencesFieldNumber = 8;
    public const byte LatitudesFieldNumber = 9;
    public const byte LongitudesFieldNumber = 10;

    public Way() { }

    public bool Equals(Way? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id == other.Id &&
               Keys.SequenceEqual(other.Keys) &&
               Values.SequenceEqual(other.Values) &&
               Info == other.Info &&
               References.SequenceEqual(other.References) &&
               Latitudes.SequenceEqual(other.Latitudes) &&
               Longitudes.SequenceEqual(other.Longitudes);
    }

    public override bool Equals(object? obj) => Equals(obj as Way);
    public override int GetHashCode() => HashCode.Combine(Id, Keys, Values, Info, References, Latitudes, Longitudes);
    public static bool operator ==(Way left, Way right) => left?.Equals(right) ?? right is null;
    public static bool operator !=(Way left, Way right) => !(left == right);
}

internal static class WayMemoryExtensions
{
    // internal static HeaderBlock AsHeaderBlock(this Memory<byte> source)
    // {
    //     return new HeaderBlock(source);
    // }
}
