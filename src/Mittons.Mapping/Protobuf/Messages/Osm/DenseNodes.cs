using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class DenseNodes
{
    public long[] Ids { get; init; } = [];
    public DenseInfo? DenseInfo { get; init; }
    public long[] Latitudes { get; init; } = [];
    public long[] Longitudes { get; init; } = [];
    public int[] KeyValues { get; init; } = [];

    public const byte IdFieldNumber = 1;
    public const byte DenseInfoFieldNumber = 5;
    public const byte LatitudeFieldNumber = 8;
    public const byte LongitudeFieldNumber = 9;
    public const byte KeyValueFieldNumber = 10;
}

internal static class DenseNodesMemoryExtensions
{
    internal static IEnumerable<DenseNodes> AsDenseNodes(this Memory<byte> source)
    {
        throw new NotImplementedException();
    }
}
