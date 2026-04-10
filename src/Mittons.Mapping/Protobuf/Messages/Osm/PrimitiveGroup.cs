using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class PrimitiveGroup : IEquatable<PrimitiveGroup>
{
    public List<Node> Nodes { get; init; } = [];
    public List<Way> Ways { get; init; } = [];
    public List<Relation> Relations { get; init; } = [];
    public List<long> ChangeSets { get; init; } = [];

    public const byte NodesFieldNumber = 1;
    public const byte DenseNodesFieldNumber = 2;
    public const byte WaysFieldNumber = 3;
    public const byte RelationsFieldNumber = 4;
    public const byte ChangeSetsFieldNumber = 5;

    public bool Equals(PrimitiveGroup? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        if ((Nodes.Count != other.Nodes.Count) ||
            (Ways.Count != other.Ways.Count) ||
            (Relations.Count != other.Relations.Count) ||
            (ChangeSets.Count != other.ChangeSets.Count))
        {
            return false;
        }

        for (int i = 0; i < Nodes.Count; ++i)
        {
            if (Nodes[i] != other.Nodes[i]) return false;
        }

        for (int i = 0; i < Ways.Count; ++i)
        {
            if (Ways[i] != other.Ways[i]) return false;
        }

        for (int i = 0; i < Relations.Count; ++i)
        {
            if (Relations[i] != other.Relations[i]) return false;
        }

        for (int i = 0; i < ChangeSets.Count; ++i)
        {
            if (ChangeSets[i] != other.ChangeSets[i]) return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var node in Nodes)
            hash.Add(node);
        foreach (var ways in Ways)
            hash.Add(ways);
        foreach (var relations in Relations)
            hash.Add(relations);
        foreach (var changeSet in ChangeSets)
            hash.Add(changeSet);
        return hash.ToHashCode();
    }
    public static bool operator ==(PrimitiveGroup? left, PrimitiveGroup? right) => left?.Equals(right) ?? right is null;
    public static bool operator !=(PrimitiveGroup? left, PrimitiveGroup? right) => !(left?.Equals(right) ?? right is null);
    public override bool Equals(object? obj) => Equals(obj as PrimitiveGroup);
}

// internal static class PrimitiveGroupMemoryExtensions
// {
//     internal static IEnumerable<Node> AsDenseNodes(this Memory<byte> source)
//     {
//         Memory<byte> idBuffer = new();
//         Memory<byte> denseInfoBuffer = new();
//         Memory<byte> latitudeBuffer = new();
//         Memory<byte> longitudeBuffer = new();
//         Memory<byte> keyValueBuffer = new();

//         int memoryPosition = 0;
//         byte fieldDatatypeIdentifier;
//         int denseLength;

//         while (memoryPosition < source.Length)
//         {
//             fieldDatatypeIdentifier = source.Span[memoryPosition++];
//             denseLength = source.ReadInt32(ref memoryPosition);

//             switch (fieldDatatypeIdentifier >> 3)
//             {
//                 case DenseNodes.IdFieldNumber:
//                     idBuffer = source.Slice(memoryPosition, denseLength);
//                     break;
//                 case DenseNodes.DenseInfoFieldNumber:
//                     denseInfoBuffer = source.Slice(memoryPosition, denseLength);
//                     break;
//                 case DenseNodes.LatitudeFieldNumber:
//                     latitudeBuffer = source.Slice(memoryPosition, denseLength);
//                     break;
//                 case DenseNodes.LongitudeFieldNumber:
//                     longitudeBuffer = source.Slice(memoryPosition, denseLength);
//                     break;
//                 case DenseNodes.KeyValueFieldNumber:
//                     keyValueBuffer = source.Slice(memoryPosition, denseLength);
//                     break;
//                 default:
//                     throw new InvalidOperationException($"Unexpected field number {fieldDatatypeIdentifier >> 3} in DenseNodes.");
//             }

//             memoryPosition += denseLength;
//         }

//         int idPosition = 0;
//         int infoPosition = 0;
//         int latitudePosition = 0;
//         int longitudePosition = 0;
//         int keyValuePosition = 0;

//         Node? previousNode = null;
//         // TODO: This means the whole collection is materialized at once, what
//         //       if we instead did something like override operator+ so we could
//         //       read a dense info, then add the previous dense info to account
//         //       for the SInts? Doesn't have to be an operator overload, but
//         //       someway of updating the relative offsets.
//         Info[] infos = [.. denseInfoBuffer.AsDenseInfo()];

//         while (idPosition < idBuffer.Length)
//         {
//             List<(uint Key, uint Value)> keyValuePairs = keyValueBuffer.Length == 0 ? [] : keyValueBuffer.ReadKeyValuePairs(ref keyValuePosition);

//             previousNode = new()
//             {
//                 Id = idBuffer.ReadSInt64(ref idPosition) + (previousNode?.Id ?? 0),
//                 Info = infoPosition < infos.Length ? infos[infoPosition++] : null,
//                 Latitude = latitudeBuffer.ReadSInt64(ref latitudePosition) + (previousNode?.Latitude ?? 0),
//                 Longitude = longitudeBuffer.ReadSInt64(ref longitudePosition) + (previousNode?.Longitude ?? 0),
//                 Keys = [.. keyValuePairs.Select(x => x.Key)],
//                 Values = [.. keyValuePairs.Select(x => x.Value)],
//             };

//             yield return previousNode;
//         }
//     }
// }
