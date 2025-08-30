using BenchmarkDotNet.Order;
using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Benchmarks.Extensions;

/// <summary>
/// Benchmarks for measuring the performance of memory extensions for reading variable-length integers.
/// </summary>
/// <remarks>
/// Reasons for tests:
/// <br />- There are some UInt32 fields in the osm pbf definition that can't exceed the maximum value of a ushort, is
/// it quicker to read them as Int16 instead of UInt32?
/// </remarks>
[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class VarIntMemoryExtensionsBenchmarks
{
    [Benchmark]
    public void BenchmarkToUInt16()
    {
        Memory<byte> data = new byte[] { 0x01, 0x02 };
        var result = data.AsUInt16();
    }

    [Benchmark]
    public void BenchmarkToUInt32()
    {
        Memory<byte> data = new byte[] { 0x01, 0x02, 0x03, 0x04 };
        var result = data.AsUInt32();
    }

    [Benchmark]
    public void BenchmarkToUInt64()
    {
        Memory<byte> data = new byte[] { 0x01, 0x02, 0x03, 0x04 };
        var result = data.AsUInt64();
    }
}
