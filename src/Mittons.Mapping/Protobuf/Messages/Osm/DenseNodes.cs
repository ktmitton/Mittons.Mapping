using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class DenseNodes
{
    public const byte IdFieldNumber = 1;
    public const byte DenseInfoFieldNumber = 5;
    public const byte LatitudeFieldNumber = 8;
    public const byte LongitudeFieldNumber = 9;
    public const byte KeyValueFieldNumber = 10;
}

internal static class DenseNodesMemoryExtensions
{
    internal static IEnumerable<Node> AsDenseNodes(this Memory<byte> source)
    {
        Memory<byte> idBuffer = new();
        Memory<byte> denseInfoBuffer = new();
        Memory<byte> latitudeBuffer = new();
        Memory<byte> longitudeBuffer = new();
        Memory<byte> keyValueBuffer = new();

        int memoryPosition = 0;
        byte fieldDatatypeIdentifier;
        int denseLength;

        while (memoryPosition < source.Length)
        {
            fieldDatatypeIdentifier = source.Span[memoryPosition++];
            denseLength = source.ReadInt32(ref memoryPosition);

            switch (fieldDatatypeIdentifier >> 3)
            {
                case DenseNodes.IdFieldNumber:
                    idBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                case DenseNodes.DenseInfoFieldNumber:
                    denseInfoBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                case DenseNodes.LatitudeFieldNumber:
                    latitudeBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                case DenseNodes.LongitudeFieldNumber:
                    longitudeBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                case DenseNodes.KeyValueFieldNumber:
                    keyValueBuffer = source.Slice(memoryPosition, denseLength);
                    break;
                default:
                    throw new InvalidOperationException($"Unexpected field number {fieldDatatypeIdentifier >> 3} in DenseNodes.");
            }

            memoryPosition += denseLength;
        }

        int idPosition = 0;
        int infoPosition = 0;
        int latitudePosition = 0;
        int longitudePosition = 0;
        int keyValuePosition = 0;

        Node? previousNode = null;
        // TODO: This means the whole collection is materialized at once, what
        //       if we instead did something like override operator+ so we could
        //       read a dense info, then add the previous dense info to account
        //       for the SInts? Doesn't have to be an operator overload, but
        //       someway of updating the relative offsets.
        Info[] infos = [.. denseInfoBuffer.AsDenseInfo()];

        while (idPosition < idBuffer.Length)
        {
            List<(uint Key, uint Value)> keyValuePairs = keyValueBuffer.Length == 0 ? [] : keyValueBuffer.ReadKeyValuePairs(ref keyValuePosition);

            previousNode = new()
            {
                Id = idBuffer.ReadSInt64(ref idPosition) + (previousNode?.Id ?? 0),
                Info = infoPosition < infos.Length ? infos[infoPosition++] : null,
                Latitude = latitudeBuffer.ReadSInt64(ref latitudePosition) + (previousNode?.Latitude ?? 0),
                Longitude = longitudeBuffer.ReadSInt64(ref longitudePosition) + (previousNode?.Longitude ?? 0),
                Keys = [.. keyValuePairs.Select(x => x.Key)],
                Values = [.. keyValuePairs.Select(x => x.Value)],
            };

            yield return previousNode;
        }
    }
}
