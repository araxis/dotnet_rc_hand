using RcHand.Hw.Core;

namespace RcHand.Hw.Bluetooth.Parsers
{
    public interface IMessageParser
    {
        IMessage Parse(string[] token);
    }
}