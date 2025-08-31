using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

internal static class StringTableMemoryExtensions
{
    internal static IEnumerable<string?> AsStringTable(this Memory<byte> source)
    {
        int memoryPosition = 0;
        while (memoryPosition < source.Length)
        {
            ++memoryPosition;
            var temp = source.ReadNullableString(ref memoryPosition);
            yield return temp;
        }
    }
}
