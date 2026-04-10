// using System.IO.Compression;
using System;
using System.IO;
using System.IO.Compression;
using Mittons.Mapping.Extensions;
using Mittons.Mapping.IO.Streams;
using ZLibDotNet;

namespace Mittons.Mapping.Protobuf.Messages.Osm
{
    public class Blob
    {
        private uint? _uncompressedSize;

        /// <summary>
        /// When compressed, this is the size of the uncompressed data.
        /// </summary>
        public uint UncompressedSize
        {
            get
            {
                if (_uncompressedSize.HasValue)
                {
                    return _uncompressedSize.Value;
                }

                return (uint)MessageData.Length;
            }

            set => _uncompressedSize = value;
        }

        /// <summary>
        /// The data in the message, it may be compressed or uncompressed.
        /// </summary>
        public Memory<byte> MessageData { get; set; }

        public Memory<byte> GetUncompressedData(byte[] buffer)
        {
            switch (CompressionAlgorithm)
            {
                case CompressionAlgorithm.Raw:
                    return MessageData;
                case CompressionAlgorithm.ZLib:
                    {
                        ZLib zlib = new ZLib();
                        ZStream zStream = new ZStream()
                        {
                            Input = MessageData.Span,
                            Output = buffer
                        };

                        _ = zlib.InflateInit(ref zStream);
                        _ = zlib.Inflate(ref zStream, ZLib.Z_SYNC_FLUSH);

                        return buffer;
                    }
                case CompressionAlgorithm.Lzma:
                case CompressionAlgorithm.Bzip2:
                case CompressionAlgorithm.Lz4:
                case CompressionAlgorithm.Zstd:
                    throw new NotImplementedException("GetUncompressedData with buffer is only implemented for ZLib compressed blobs.");
                default:
                    throw new InvalidOperationException("Uncompressed data is not available for compressed blobs.");
            }
        }

        internal CompressionAlgorithm CompressionAlgorithm { get; set; }

        public const byte RawDataFieldNumber = 1;
        public const byte RawSizeFieldNumber = 2;
        public const byte ZLibDataFieldNumber = 3;
        public const byte LzmaDataFieldNumber = 4;
        [Obsolete("Bzip2 compression was deprecated in 2010.")]
        public const byte Bzip2DataFieldNumber = 5;
        public const byte Lz4DataFieldNumber = 6;
        public const byte ZstdDataFieldNumber = 7;

        public Blob(Memory<byte> source)
        {
            int memoryPosition = 0;
            while (memoryPosition < source.Length)
            {
                switch (source.Span[memoryPosition++] >> 3)
                {
                    case RawSizeFieldNumber:
                        CompressionAlgorithm = CompressionAlgorithm.Raw;
                        UncompressedSize = source.ReadUInt32(ref memoryPosition);
                        continue;
                    case RawDataFieldNumber:
                        CompressionAlgorithm = CompressionAlgorithm.Raw;
                        break;
                    case ZLibDataFieldNumber:
                        CompressionAlgorithm = CompressionAlgorithm.ZLib;
                        break;
                    case LzmaDataFieldNumber:
                        CompressionAlgorithm = CompressionAlgorithm.Lzma;
                        break;
                    #pragma warning disable CS0618 // Type or member is obsolete
                    case Bzip2DataFieldNumber:
                        CompressionAlgorithm = CompressionAlgorithm.Bzip2;
                        break;
                    #pragma warning restore CS0618 // Type or member is obsolete
                    case Lz4DataFieldNumber:
                        CompressionAlgorithm = CompressionAlgorithm.Lz4;
                        break;
                    case ZstdDataFieldNumber:
                        CompressionAlgorithm = CompressionAlgorithm.Zstd;
                        break;
                    default:
                        throw new InvalidOperationException($"Unknown field number [{source.Span[memoryPosition - 1] >> 3}] in Blob message.");
                }

                MessageData = source.ReadLengthDelimited(ref memoryPosition);
            }
        }
    }

    internal enum CompressionAlgorithm
    {
        Raw,
        ZLib,
        Lzma,
        Bzip2,
        Lz4,
        Zstd
    }

    internal static class BlobMemoryExtensions
    {
        internal static Blob AsBlob(this Memory<byte> source)
        {
            return new Blob(source);
        }
    }
}
