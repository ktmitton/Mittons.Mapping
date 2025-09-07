using Mittons.Mapping.Extensions;
using Mittons.Mapping.IO.Streams;

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
    internal static IEnumerable<DenseNodes> AsDenseNodes(this Memory<byte> source)
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

        while (idPosition < idBuffer.Length)
        {
            Node node = new()
            {
                Id = idBuffer.ReadSInt32(ref idPosition),
                Info = denseInfoBuffer.ReadInfo(ref infoPosition),
                Latitude = latitudeBuffer.ReadSInt64(ref latitudePosition) + (previousNode?.Latitude ?? 0),
                Longitude = longitudeBuffer.ReadSInt64(ref longitudePosition) + (previousNode?.Longitude ?? 0),
                KeyValues = keyValueBuffer.ReadInt32Array(ref keyValuePosition)
            };

            yield return denseNode;
        }
    }
}
