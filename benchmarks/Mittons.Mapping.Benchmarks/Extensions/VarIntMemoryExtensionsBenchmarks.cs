using BenchmarkDotNet.Order;
using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Benchmarks.Extensions;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class VarIntMemoryExtensionsBenchmarks
{
    [Benchmark]
    public void BenchmarkToUInt16()
    {
        Memory<byte> data = new byte[] { 0x01, 0x02 };
        var result = data.ToUInt16();
    }

    [Benchmark]
    public void BenchmarkToUInt32()
    {
        Memory<byte> data = new byte[] { 0x01, 0x02, 0x03, 0x04 };
        var result = data.ToUInt32();
    }

    [Benchmark]
    public void BenchmarkToUInt64()
    {
        Memory<byte> data = new byte[] { 0x01, 0x02, 0x03, 0x04 };
        var result = data.ToUInt64();
    }
}
