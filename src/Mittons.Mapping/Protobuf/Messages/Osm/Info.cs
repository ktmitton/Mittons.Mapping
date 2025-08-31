using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class Info : IEquatable<Info>
{
    public int Version { get; init; } = -1;
    public int? Timestamp { get; init; }
    public long? ChangeSet { get; init; }
    public int? UserId { get; init; }
    public int? UserStringId { get; init; }
    /// <summary>
    /// The visible flag is used to store history information. It indicates that the current object version has been
    /// created by a delete operation on the OSM API.
    /// <br />
    /// If visible is set to false, this element has been deleted.
    /// </summary>
    public bool IsVisible { get; init; } = true;

    public const byte VersionFieldNumber = 1;
    public const byte TimestampFieldNumber = 2;
    public const byte ChangeSetFieldNumber = 3;
    public const byte UserIdFieldNumber = 4;
    public const byte UserSecurityIdFieldNumber = 5;
    public const byte IsVisibleFieldNumber = 6;

    public Info() { }

    public bool Equals(Info? other)
    {
        if (other is null) return false;
        return Version == other.Version &&
               Timestamp == other.Timestamp &&
               ChangeSet == other.ChangeSet &&
               UserId == other.UserId &&
               UserStringId == other.UserStringId &&
               IsVisible == other.IsVisible;
    }
    public override int GetHashCode()
        => HashCode.Combine(Version, Timestamp, ChangeSet, UserId, UserStringId, IsVisible);
    public static bool operator ==(Info? left, Info? right) => Equals(left, right);
    public static bool operator !=(Info? left, Info? right) => !Equals(left, right);
    public override bool Equals(object? obj) => Equals(obj as Info);
}

internal static class InfoMemoryExtensions
{
    // internal static HeaderBlock AsHeaderBlock(this Memory<byte> source)
    // {
    //     return new HeaderBlock(source);
    // }
}
