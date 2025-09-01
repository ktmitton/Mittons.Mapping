using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class Relation : IEquatable<Relation>
{
    public long Id { get; init; }
    public uint[] Keys { get; init; } = [];
    public uint[] Values { get; init; } = [];
    public Info? Info { get; init; }
    public int[] RoleStringIds { get; init; } = [];
    public long[] MemberIds { get; init; } = [];
    public MemberType[] MemberTypes { get; init; } = [];

    public const byte IdFieldNumber = 1;
    public const byte KeySegmentsFieldNumber = 2;
    public const byte ValuesFieldNumber = 3;
    public const byte InfoFieldNumber = 4;
    public const byte RoleSecurityIdsFieldNumber = 8;
    public const byte MemberIdsFieldNumber = 9;
    public const byte MemberTypesFieldNumber = 10;

    public enum MemberType
    {
        Node = 0,
        Way = 1,
        Relation = 2,
    }

    public Relation() { }

    public bool Equals(Relation? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id == other.Id &&
               Keys.SequenceEqual(other.Keys) &&
               Values.SequenceEqual(other.Values) &&
               Info == other.Info &&
               RoleStringIds.SequenceEqual(other.RoleStringIds) &&
               MemberIds.SequenceEqual(other.MemberIds) &&
               MemberTypes.SequenceEqual(other.MemberTypes);
    }

    public override bool Equals(object? obj) => Equals(obj as Relation);
    public override int GetHashCode()
    {
        return HashCode.Combine(
            Id,
            GetArrayHashCode(Keys),
            GetArrayHashCode(Values),
            Info,
            GetArrayHashCode(RoleStringIds),
            GetArrayHashCode(MemberIds),
            GetArrayHashCode(MemberTypes)
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
    public static bool operator ==(Relation left, Relation right) => left?.Equals(right) ?? right is null;
    public static bool operator !=(Relation left, Relation right) => !(left == right);
}

internal static class RelationMemoryExtensions
{
    internal static Relation AsRelation(this Memory<byte> source)
    {
        throw new NotImplementedException();
    }
}
