namespace RcHand.Infrastructure.Bluetooth
{

    public interface IMessageHandler
    {
        bool Handle(string message);
    }
}