using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class HeaderBlock : IEquatable<HeaderBlock>
{
    public HeaderBoundingBox? BoundingBox { get; init; }
    public List<string>? RequiredFeatures { get; init; }
    public List<string>? OptionalFeatures { get; init; }
    public string? WritingProgram { get; init; }
    public string? Source { get; init; }
    public long? OsmosisReplicationTimestamp { get; init; }
    public long? OsmosisReplicationSequenceNumber { get; init; }
    public string? OsmosisReplicationBaseUrl { get; init; }

    public const byte BoundingBoxFieldNumber = 1;
    public const byte RequiredFeaturesFieldNumber = 4;
    public const byte OptionalFeaturesFieldNumber = 5;
    public const byte WritingProgramFieldNumber = 16;
    public const byte SourceFieldNumber = 17;
    public const byte OsmosisReplicationTimestampFieldNumber = 32;
    public const byte OsmosisReplicationSequenceNumberFieldNumber = 33;
    public const byte OsmosisReplicationBaseUrlFieldNumber = 34;

    public HeaderBlock() { }

    public HeaderBlock(Memory<byte> source)
    {
        int memoryPosition = 0;
        while (memoryPosition < source.Length)
        {
            switch (source.ReadUInt16(ref memoryPosition) >> 3)
            {
                case BoundingBoxFieldNumber:
                    BoundingBox = source.ReadHeaderBoundingBox(ref memoryPosition);
                    continue;
                case RequiredFeaturesFieldNumber:
                    RequiredFeatures ??= [];
                    RequiredFeatures.Add(source.ReadString(ref memoryPosition));
                    continue;
                case OptionalFeaturesFieldNumber:
                    OptionalFeatures ??= [];
                    OptionalFeatures.Add(source.ReadString(ref memoryPosition));
                    continue;
                case WritingProgramFieldNumber:
                    WritingProgram = source.ReadString(ref memoryPosition);
                    continue;
                case SourceFieldNumber:
                    Source = source.ReadString(ref memoryPosition);
                    continue;
                case OsmosisReplicationTimestampFieldNumber:
                    OsmosisReplicationTimestamp = source.ReadInt64(ref memoryPosition);
                    continue;
                case OsmosisReplicationSequenceNumberFieldNumber:
                    OsmosisReplicationSequenceNumber = source.ReadInt64(ref memoryPosition);
                    continue;
                case OsmosisReplicationBaseUrlFieldNumber:
                    OsmosisReplicationBaseUrl = source.ReadString(ref memoryPosition);
                    continue;
                default:
                    throw new InvalidOperationException($"Unknown field number [{source.Span[memoryPosition - 1] >> 3}] in HeaderBlock message.");
            }
        }
    }

    public bool Equals(HeaderBlock? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return
            BoundingBox == other.BoundingBox &&
            WritingProgram == other.WritingProgram &&
            Source == other.Source &&
            OsmosisReplicationTimestamp == other.OsmosisReplicationTimestamp &&
            OsmosisReplicationSequenceNumber == other.OsmosisReplicationSequenceNumber &&
            OsmosisReplicationBaseUrl == other.OsmosisReplicationBaseUrl &&
            (RequiredFeatures ?? []).SequenceEqual(other.RequiredFeatures ?? []) &&
            (OptionalFeatures ?? []).SequenceEqual(other.OptionalFeatures ?? []);
    }
    public static bool operator ==(HeaderBlock? left, HeaderBlock? right) => Equals(left, right);
    public static bool operator !=(HeaderBlock? left, HeaderBlock? right) => !Equals(left, right);
    public override bool Equals(object? obj) => Equals(obj as HeaderBlock);
    public override int GetHashCode() => HashCode.Combine(BoundingBox, RequiredFeatures, OptionalFeatures, WritingProgram);
}

internal static class HeaderBlockMemoryExtensions
{
    internal static HeaderBlock AsHeaderBlock(this Memory<byte> source)
    {
        return new HeaderBlock(source);
    }
}
