using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class HeaderBlock : IEquatable<HeaderBlock>
{
    public HeaderBoundingBox? BoundingBox { get; init; }
    public List<string> RequiredFeatures { get; init; } = [];
    public List<string> OptionalFeatures { get; init; } = [];
    public string? WritingProgram { get; init; }
    public string? Source { get; init; }
    public long? OsmosisReplicationTimestamp { get; init; }
    public long? OsmosisReplicationSequenceNumber { get; init; }
    public string? OsmosisReplicationBaseUrl { get; init; }

    public bool Equals(HeaderBlock? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return
            BoundingBox == other.BoundingBox &&
            RequiredFeatures.SequenceEqual(other.RequiredFeatures) &&
            OptionalFeatures.SequenceEqual(other.OptionalFeatures) &&
            WritingProgram == other.WritingProgram &&
            Source == other.Source &&
            OsmosisReplicationTimestamp == other.OsmosisReplicationTimestamp &&
            OsmosisReplicationSequenceNumber == other.OsmosisReplicationSequenceNumber &&
            OsmosisReplicationBaseUrl == other.OsmosisReplicationBaseUrl;
    }
    public static bool operator ==(HeaderBlock? left, HeaderBlock? right) => Equals(left, right);
    public static bool operator !=(HeaderBlock? left, HeaderBlock? right) => !Equals(left, right);
    public override bool Equals(object? obj) => Equals(obj as HeaderBlock);
    public override int GetHashCode() => HashCode.Combine(BoundingBox, RequiredFeatures, OptionalFeatures, WritingProgram);

    public const byte BoundingBoxFieldNumber = 1;
    public const byte RequiredFeaturesFieldNumber = 4;
    public const byte OptionalFeaturesFieldNumber = 5;
    public const byte WritingProgramFieldNumber = 16;
    public const byte SourceFieldNumber = 17;
    public const byte OsmosisReplicationTimestampFieldNumber = 32;
    public const byte OsmosisReplicationSequenceNumberFieldNumber = 33;
    public const byte OsmosisReplicationBaseUrlFieldNumber = 34;
}

internal static class HeaderBlockMemoryExtensions
{
    // internal static HeaderBlock AsHeaderBlock(this Memory<byte> source)
    // {
    //     return new HeaderBlock(source);
    // }
}
