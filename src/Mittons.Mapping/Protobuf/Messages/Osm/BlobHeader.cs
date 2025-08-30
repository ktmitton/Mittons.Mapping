using Mittons.Mapping.Extensions;

namespace Mittons.Mapping.Protobuf.Messages.Osm;

public class BlobHeader
{
    /// <summary>
    /// The type of data in the subsequent Blob.
    /// </summary>
    public string Type { get; init; } = string.Empty;

    /// <summary>
    /// Arbitrary blob that may include metadata about the following blob. For example, for OSM data, it might contain a
    /// bounding box.
    /// </summary>
    /// <remarks>
    /// This is a stub intended to enable the future design of indexed *.osm.pbf files.
    /// </remarks>
    public Memory<byte>? IndexData { get; init; }

    /// <summary>
    /// The serialized size of the subsequent Blob message.
    /// </summary>
    /// <remarks>
    /// While the proto for the message is an int32, <see href="https://wiki.openstreetmap.org/wiki/PBF_Format">OSM PBF
    /// Format</see> specifies that a Blob message must be less than 64 KiB, so the maximum value for this field is the
    /// maximum value for a uint.
    /// </remarks>
    public uint DataSize { get; init; }

    private const byte TypeFieldNumber = 1;
    private const byte IndexDataFieldNumber = 2;
    private const byte DataSizeFieldNumber = 3;

    public BlobHeader(string type, Memory<byte> indexData, uint dataSize)
    {
        Type = type;
        IndexData = indexData;
        DataSize = dataSize;
    }

    public BlobHeader(string type, uint dataSize)
    {
        Type = type;
        DataSize = dataSize;
    }

    internal BlobHeader(Memory<byte> source)
    {
        int memoryPosition = 0;
        while (memoryPosition < source.Length)
        {
            switch (source.Span[memoryPosition++] >> 3)
            {
                case TypeFieldNumber:
                    Type = source.ReadLengthDelimited(ref memoryPosition).AsString();
                    break;
                case IndexDataFieldNumber:
                    IndexData = source.ReadLengthDelimited(ref memoryPosition);
                    break;
                case DataSizeFieldNumber:
                    DataSize = source.ReadVarInt(ref memoryPosition).AsUInt16();
                    break;
                default:
                    throw new InvalidOperationException($"Unknown field number [{source.Span[memoryPosition - 1] >> 3}] in BlobHeader message.");
            }
        }
    }
}

internal static class BlobHeaderMemoryExtensions
{
    internal static BlobHeader AsBlobHeader(this Memory<byte> source)
    {
        return new BlobHeader(source);
    }
}
