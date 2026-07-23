using System;
using System.Collections.Generic;
using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm
{
    public class PrimitiveGroup : IEquatable<PrimitiveGroup>
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Way> Ways { get; set; } = new List<Way>();
        public List<Relation> Relations { get; set; } = new List<Relation>();
        public List<long> ChangeSets { get; set; } = new List<long>();

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

    internal static class PrimitiveGroupMemoryExtensions
    {
        private static IEnumerable<long> AsChangeSets(this Memory<byte> source)
        {
            int memoryPosition = 0;

            while (memoryPosition < source.Length)
            {
                // Eat up the first byte, which just says what type the content is, which we already know
                ++memoryPosition;
                yield return source.ReadInt64(ref memoryPosition);
            }
        }

        private static IEnumerable<Node> AsNodes(this Memory<byte> source)
        {
            int memoryPosition = 0;

            while (memoryPosition < source.Length)
            {
                // Eat up the first byte, which just says what type the content is, which we already know
                ++memoryPosition;

                var denseLength = source.ReadInt32(ref memoryPosition);

                yield return source.Slice(memoryPosition, denseLength).AsNode();
            }
        }

        private static IEnumerable<Relation> AsRelations(this Memory<byte> source)
        {
            int memoryPosition = 0;

            while (memoryPosition < source.Length)
            {
                // Eat up the first byte, which just says what type the content is, which we already know
                ++memoryPosition;
                yield return source.AsRelation(ref memoryPosition);
            }
        }

        private static IEnumerable<Way> AsWays(this Memory<byte> source)
        {
            int memoryPosition = 0;

            while (memoryPosition < source.Length)
            {
                // Eat up the first byte, which just says what type the content is, which we already know
                ++memoryPosition;
                yield return source.AsWay(ref memoryPosition);
            }
        }

        internal static PrimitiveGroup AsPrimitiveGroup(this Memory<byte> source)
        {
            Memory<byte> nodesBuffer = new();
            Memory<byte> denseNodesBuffer = new();
            Memory<byte> waysBuffer = new();
            Memory<byte> relationsBuffer = new();
            Memory<byte> changeSetsBuffer = new();

            int memoryPosition = 0;
            byte fieldDatatypeIdentifier;
            int denseLength;

            while (memoryPosition < source.Length)
            {
                fieldDatatypeIdentifier = source.Span[memoryPosition++];
                denseLength = source.ReadInt32(ref memoryPosition);

                switch (fieldDatatypeIdentifier >> 3)
                {
                    case PrimitiveGroup.NodesFieldNumber:
                        nodesBuffer = source.Slice(memoryPosition, denseLength);
                        break;
                    case PrimitiveGroup.DenseNodesFieldNumber:
                        denseNodesBuffer = source.Slice(memoryPosition, denseLength);
                        break;
                    case PrimitiveGroup.WaysFieldNumber:
                        waysBuffer = source.Slice(memoryPosition, denseLength);
                        break;
                    case PrimitiveGroup.RelationsFieldNumber:
                        relationsBuffer = source.Slice(memoryPosition, denseLength);
                        break;
                    case PrimitiveGroup.ChangeSetsFieldNumber:
                        changeSetsBuffer = source.Slice(memoryPosition, denseLength);
                        break;
                    default:
                        throw new InvalidOperationException($"Unexpected field number {fieldDatatypeIdentifier >> 3} in DenseNodes.");
                }

                memoryPosition += denseLength;
            }

            PrimitiveGroup group = new PrimitiveGroup();

            if (nodesBuffer.Length > 0)
            {
                group.Nodes.AddRange(nodesBuffer.AsNodes());
            }

            if (denseNodesBuffer.Length > 0)
            {
                group.Nodes.AddRange(denseNodesBuffer.AsDenseNodes());
            }

            if (waysBuffer.Length > 0)
            {
                group.Ways.AddRange(waysBuffer.AsWays());
            }

            if (relationsBuffer.Length > 0)
            {
                group.Relations.AddRange(relationsBuffer.AsRelations());
            }

            if (changeSetsBuffer.Length > 0)
            {
                group.ChangeSets.AddRange(changeSetsBuffer.AsChangeSets());
            }

            return group;
        }
    }
}
