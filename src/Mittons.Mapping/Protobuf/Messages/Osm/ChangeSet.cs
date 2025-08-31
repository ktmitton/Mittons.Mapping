using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

internal static class ChangeSetMemoryExtensions
{
    internal static long AsChangeSet(this Memory<byte> source)
    {
        int memoryPosition = 0;
        return source.ReadInt64(ref memoryPosition);
    }
}
