using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class DenseNodes : IEquatable<DenseNodes>
{
    public long[] Ids { get; init; } = [];
    public Info[]? Infos { get; init; }
    public long[] Latitudes { get; init; } = [];
    public long[] Longitudes { get; init; } = [];
    public int[] KeyValues { get; init; } = [];

    public const byte IdFieldNumber = 1;
    public const byte DenseInfoFieldNumber = 5;
    public const byte LatitudeFieldNumber = 8;
    public const byte LongitudeFieldNumber = 9;
    public const byte KeyValueFieldNumber = 10;

    public DenseNodes() { }

    public DenseNodes(Memory<byte> source)
    {
        throw new NotImplementedException();
    }

    public bool Equals(DenseNodes? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Ids.SequenceEqual(other.Ids)
            && Latitudes.SequenceEqual(other.Latitudes)
            && Longitudes.SequenceEqual(other.Longitudes)
            && KeyValues.SequenceEqual(other.KeyValues)
            && (Infos ?? []).SequenceEqual(other?.Infos ?? []);
    }

    public override bool Equals(object? obj) => Equals(obj as DenseNodes);
    public static bool operator ==(DenseNodes? left, DenseNodes? right) => Equals(left, right);
    public static bool operator !=(DenseNodes? left, DenseNodes? right) => !Equals(left, right);

    public override int GetHashCode()
    {
        HashCode hash = new();

        foreach (var id in Ids)
            hash.Add(id);

        foreach (var latitude in Latitudes)
            hash.Add(latitude);

        foreach (var longitude in Longitudes)
            hash.Add(longitude);

        foreach (var key in KeyValues)
            hash.Add(key);

        foreach (var info in Infos ?? [])
            hash.Add(info);

        return hash.ToHashCode();
    }
}

internal static class DenseNodesMemoryExtensions
{
    internal static IEnumerable<Node> ReadDenseNode(this Memory<byte> source)
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
            var keyValuePairs = keyValueBuffer.ReadKeyValuePairs(ref keyValuePosition);
            int keyValuePairCount = keyValuePairs.Count == 0 ? 0 : keyValuePairs.Count / 2;

            uint[] keys = [.. keyValuePairs.Select(x => x.Key)];
            uint[] values = [.. keyValuePairs.Select(x => x.Value)];

            previousNode = new()
            {
                Id = idBuffer.ReadSInt32(ref idPosition) + (previousNode?.Id ?? 0),
                Info = infos[infoPosition++],
                Latitude = latitudeBuffer.ReadSInt64(ref latitudePosition) + (previousNode?.Latitude ?? 0),
                Longitude = longitudeBuffer.ReadSInt64(ref longitudePosition) + (previousNode?.Longitude ?? 0),
                Keys = [.. keyValuePairs.Select(x => x.Key)],
                Values = [.. keyValuePairs.Select(x => x.Value)],
            };

            yield return previousNode;
        }
    }
}
