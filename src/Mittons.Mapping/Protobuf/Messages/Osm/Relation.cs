using System;
using System.Linq;
using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm
{
    public class Relation : IEquatable<Relation>
    {
        public long Id { get; set; }
        public uint[] Keys { get; set; } = Array.Empty<uint>();
        public uint[] Values { get; set; } = Array.Empty<uint>();
        public Info? Info { get; set; }
        public int[] RoleStringIds { get; set; } = Array.Empty<int>();
        public long[] MemberIds { get; set; } = Array.Empty<long>();
        public MemberType[] MemberTypes { get; set; } = Array.Empty<MemberType>();

        public const byte IdFieldNumber = 1;
        public const byte KeysFieldNumber = 2;
        public const byte ValuesFieldNumber = 3;
        public const byte InfoFieldNumber = 4;
        public const byte RoleStringIdsFieldNumber = 8;
        public const byte MemberIdsFieldNumber = 9;
        public const byte MemberTypesFieldNumber = 10;

        public enum MemberType
        {
            Node = 0,
            Way = 1,
            Relation = 2,
        }

        public Relation() { }

        public Relation(Memory<byte> source)
        {
            int memoryPosition = 0;
            while (memoryPosition < source.Length)
            {
                switch (source.Span[memoryPosition++] >> 3)
                {
                    case IdFieldNumber:
                        Id = source.ReadInt64(ref memoryPosition);
                        continue;
                    case KeysFieldNumber:
                        Keys = source.ReadPackedUInt32(ref memoryPosition).ToArray();
                        continue;
                    case ValuesFieldNumber:
                        Values = source.ReadPackedUInt32(ref memoryPosition).ToArray();
                        continue;
                    case InfoFieldNumber:
                        Info = source.ReadInfo(ref memoryPosition);
                        continue;
                    case RoleStringIdsFieldNumber:
                        RoleStringIds = source.ReadPackedInt32(ref memoryPosition).ToArray();
                        continue;
                    case MemberIdsFieldNumber:
                        MemberIds = source.ReadPackedDeltaCodedSInt64(ref memoryPosition).ToArray();
                        continue;
                    case MemberTypesFieldNumber:
                        MemberTypes = source.ReadPackedEnum<MemberType>(ref memoryPosition).ToArray();
                        continue;
                    default:
                        throw new InvalidOperationException($"Unknown field number [{source.Span[memoryPosition - 1] >> 3}] in Relation message.");
                }
            }
        }

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
            return new Relation(source);
        }
    }
}
