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
    public const byte LatitudeFieldNumber = 5;
    public const byte LongitudeFieldNumber = 6;

    public Node() { }

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

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Keys, Values, Info, Latitude, Longitude);
    }
    public static bool operator ==(Node? left, Node? right) => Equals(left, right);
    public static bool operator !=(Node? left, Node? right) => !Equals(left, right);
    public override bool Equals(object? obj) => Equals(obj as Node);
}
