using System;
using System.Linq;
using System.Collections.Generic;
using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm
{
    public class DenseInfo : IEquatable<DenseInfo>
    {
        public List<int> Versions { get; set; } = new List<int>();
        public List<long> Timestamps { get; set; } = new List<long>();
        public List<long> ChangeSets { get; set; } = new List<long>();
        public List<int> UserIds { get; set; } = new List<int>();
        public List<int> UserStringIds { get; set; } = new List<int>();
        /// <summary>
        /// The visible flag is used to store history information. It indicates that the current object version has been
        /// created by a delete operation on the OSM API.
        /// <br />
        /// If visible is set to false, this element has been deleted.
        /// </summary>
        public List<bool> IsVisibles { get; set; } = new List<bool>();

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
            HashCode hash = new HashCode();

            foreach (var version in Versions)
                hash.Add(version);

            foreach (var timestamp in Timestamps)
                hash.Add(timestamp);

            foreach (var changeSet in ChangeSets)
                hash.Add(changeSet);

            foreach (var userId in UserIds)
                hash.Add(userId);

            foreach (var userStringId in UserStringIds)
                hash.Add(userStringId);

            foreach (var isVisible in IsVisibles)
                hash.Add(isVisible);

            return hash.ToHashCode();
        }
    }

    internal static class DenseInfoMemoryExtensions
    {
        internal static IEnumerable<Info> AsDenseInfo(this Memory<byte> source)
        {
            Memory<byte> versionBuffer = new Memory<byte>();
            Memory<byte> timestampBuffer = new Memory<byte>();
            Memory<byte> changeSetBuffer = new Memory<byte>();
            Memory<byte> userIdBuffer = new Memory<byte>();
            Memory<byte> userStringIdBuffer = new Memory<byte>();
            Memory<byte> isVisibleBuffer = new Memory<byte>();

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
}
