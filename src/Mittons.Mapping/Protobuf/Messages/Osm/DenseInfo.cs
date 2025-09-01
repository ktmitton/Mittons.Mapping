using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class DenseInfo
{
    public List<int> Versions { get; init; } = [];
    public List<long> Timestamps { get; init; } = [];
    public List<long> ChangeSets { get; init; } = [];
    public List<int> UserIds { get; init; } = [];
    public List<int> UserSecurityIds { get; init; } = [];
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
