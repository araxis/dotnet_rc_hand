using RcHand.Hw.Core;

namespace RcHand.Hw.Bluetooth
{
    public interface IMessageFactory
    {
        IMessage CreateCommand(string message);
    }
}