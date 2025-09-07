using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class DenseInfo : IEquatable<DenseInfo>
{
    public List<int> Versions { get; init; } = [];
    public List<long> Timestamps { get; init; } = [];
    public List<long> ChangeSets { get; init; } = [];
    public List<int> UserIds { get; init; } = [];
    public List<int> UserStringIds { get; init; } = [];
    /// <summary>
    /// The visible flag is used to store history information. It indicates that the current object version has been
    /// created by a delete operation on the OSM API.
    /// <br />
    /// If visible is set to false, this element has been deleted.
    /// </summary>
    public List<bool> IsVisibles { get; init; } = [];

    public const byte VersionFieldNumber = 1;
    public const byte TimestampFieldNumber = 2;
    public const byte ChangeSetFieldNumber = 3;
    public const byte UserIdFieldNumber = 4;
    public const byte UserStringIdFieldNumber = 5;
    public const byte IsVisibleFieldNumber = 6;

    public bool Equals(DenseInfo? other)
    {
        if (other is null) return false;

        return
            Versions.SequenceEqual(other.Versions) &&
            Timestamps.SequenceEqual(other.Timestamps) &&
            ChangeSets.SequenceEqual(other.ChangeSets) &&
            UserIds.SequenceEqual(other.UserIds) &&
            UserStringIds.SequenceEqual(other.UserStringIds) &&
            IsVisibles.SequenceEqual(other.IsVisibles);
    }

    public override bool Equals(object? obj) => Equals(obj as DenseInfo);
    public static bool operator ==(DenseInfo? left, DenseInfo? right) => Equals(left, right);
    public static bool operator !=(DenseInfo? left, DenseInfo? right) => !Equals(left, right);

    public override int GetHashCode()
    {
        HashCode hash = new();

        foreach (var id in Versions)
            hash.Add(id);

        foreach (var latitude in Timestamps)
            hash.Add(latitude);

        foreach (var longitude in ChangeSets)
            hash.Add(longitude);

        foreach (var key in UserIds)
            hash.Add(key);

        foreach (var key in UserStringIds)
            hash.Add(key);

        foreach (var key in IsVisibles)
            hash.Add(key);

        return hash.ToHashCode();
    }
}

internal static class DenseInfoMemoryExtensions
{
    internal static IEnumerable<Info> AsDenseInfo(this Memory<byte> source)
    {
        Memory<byte> versionBuffer = new();
        Memory<byte> timestampBuffer = new();
        Memory<byte> changeSetBuffer = new();
        Memory<byte> userIdBuffer = new();
        Memory<byte> userStringIdBuffer = new();
        Memory<byte> isVisibleBuffer = new();

        int versionPosition = 0;
        int timestampPosition = 0;
        int changeSetPosition = 0;
        int userIdPosition = 0;
        int userStringIdPosition = 0;
        int isVisiblePosition = 0;

        int memoryPosition = 0;
        byte fieldDatatypeIdentifier;
        int denseLength;
        while (memoryPosition < source.Length)
        {
            fieldDatatypeIdentifier = source.Span[memoryPosition++];
            denseLength = source.ReadInt32(ref memoryPosition);

            switch (fieldDatatypeIdentifier >> 3)
            {
                case DenseInfo.VersionFieldNumber:
                    versionBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                case DenseInfo.TimestampFieldNumber:
                    timestampBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                case DenseInfo.ChangeSetFieldNumber:
                    changeSetBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                case DenseInfo.UserIdFieldNumber:
                    userIdBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                case DenseInfo.UserStringIdFieldNumber:
                    userStringIdBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                case DenseInfo.IsVisibleFieldNumber:
                    isVisibleBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown field number [{fieldDatatypeIdentifier >> 3}] in DenseInfo message.");
            }

            memoryPosition += denseLength;
        }

        Info? previousInfo = null;

        while
        (
            versionPosition < versionBuffer.Length ||
            timestampPosition < timestampBuffer.Length ||
            changeSetPosition < changeSetBuffer.Length ||
            userIdPosition < userIdBuffer.Length ||
            userStringIdPosition < userStringIdBuffer.Length ||
            isVisiblePosition < isVisibleBuffer.Length
        )
        {
            previousInfo = new Info
            (
                versionBuffer, ref versionPosition,
                timestampBuffer, ref timestampPosition,
                changeSetBuffer, ref changeSetPosition,
                userIdBuffer, ref userIdPosition,
                userStringIdBuffer, ref userStringIdPosition,
                isVisibleBuffer, ref isVisiblePosition,
                previousInfo
            );

            yield return previousInfo;
        }
    }
}
