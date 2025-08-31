using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class Info : IEquatable<Info>
{
    public int Version { get; init; } = -1;
    public long? Timestamp { get; init; }
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

    public Info(Memory<byte> source)
    {
        int memoryPosition = 0;
        while (memoryPosition < source.Length)
        {
            switch (source.Span[memoryPosition++] >> 3)
            {
                case VersionFieldNumber:
                    Version = source.ReadInt32(ref memoryPosition);
                    continue;
                case TimestampFieldNumber:
                    Timestamp = source.ReadInt32(ref memoryPosition);
                    continue;
                case ChangeSetFieldNumber:
                    ChangeSet = source.ReadInt64(ref memoryPosition);
                    continue;
                case UserIdFieldNumber:
                    UserId = source.ReadInt32(ref memoryPosition);
                    continue;
                case UserSecurityIdFieldNumber:
                    UserStringId = source.ReadInt32(ref memoryPosition);
                    continue;
                case IsVisibleFieldNumber:
                    IsVisible = source.ReadBool(ref memoryPosition);
                    continue;
                default:
                    throw new InvalidOperationException($"Unknown field number [{source.Span[memoryPosition - 1] >> 3}] in Info message.");
            }
        }
    }

    public Info
    (
        Memory<byte> versionSource, ref int versionMemoryPosition,
        Memory<byte> timestampSource, ref int timestampMemoryPosition,
        Memory<byte> changeSetSource, ref int changeSetMemoryPosition,
        Memory<byte> userIdSource, ref int userIdMemoryPosition,
        Memory<byte> userStringIdSource, ref int userStringIdMemoryPosition,
        Memory<byte> isVisibleSource, ref int isVisibleMemoryPosition,
        Info? previousInfo = null
    )
    {
        if (versionMemoryPosition < versionSource.Length)
        {
            Version = versionSource.ReadInt32(ref versionMemoryPosition);
        }
        if (timestampMemoryPosition < timestampSource.Length)
        {
            Timestamp = timestampSource.ReadSInt64(ref timestampMemoryPosition) + (previousInfo?.Timestamp ?? 0);
        }
        if (changeSetMemoryPosition < changeSetSource.Length)
        {
            ChangeSet = changeSetSource.ReadSInt64(ref changeSetMemoryPosition) + (previousInfo?.ChangeSet ?? 0);
        }
        if (userIdMemoryPosition < userIdSource.Length)
        {
            UserId = userIdSource.ReadSInt32(ref userIdMemoryPosition) + (previousInfo?.UserId ?? 0);
        }
        if (userStringIdMemoryPosition < userStringIdSource.Length)
        {
            UserStringId = userStringIdSource.ReadSInt32(ref userStringIdMemoryPosition) + (previousInfo?.UserStringId ?? 0);
        }
        if (isVisibleMemoryPosition < isVisibleSource.Length)
        {
            IsVisible = isVisibleSource.ReadBool(ref isVisibleMemoryPosition);
        }
    }

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
    internal static Info AsInfo(this Memory<byte> source)
    {
        return new Info(source);
    }
}
