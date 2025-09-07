namespace Mittons.Mapping.IO.Streams;

// TODO: Create test cases, this was copied from an earlier prototype
public class ManagedMemoryStream(Memory<byte> memory) : Stream
{
    private readonly Memory<byte> _memory = memory;

    public override bool CanRead => true;
    public override bool CanSeek => true;
    public override bool CanWrite => false;
    public override long Length => _memory.Length;
    private int _position;
    public override long Position
    {
        get => _position;
        set => _position = (int)value;
    }

    public override void Flush()
    {
        throw new NotImplementedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        var positionalOffset = _position + offset;
        var readCount = Math.Min(count, _memory.Length - positionalOffset);

        _memory.Span.Slice(positionalOffset, readCount).CopyTo(buffer.AsSpan());

        _position += readCount;

        return readCount;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        switch (origin)
        {
            case SeekOrigin.Begin:
                Position = offset;
                break;
            case SeekOrigin.Current:
                Position += offset;
                break;
            case SeekOrigin.End:
                Position = Length + offset;
                break;
        }

        return Position;
    }

    public override void SetLength(long value)
    {
        throw new NotImplementedException();
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        throw new NotImplementedException();
    }
}
