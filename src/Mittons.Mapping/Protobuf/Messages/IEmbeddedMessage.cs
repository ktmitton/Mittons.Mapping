namespace Mittons.Mapping.Protobuf.Messages;

public interface IMessage
{
    public abstract static IMessage From(Memory<byte> data);
}
