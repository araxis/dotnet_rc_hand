namespace RcHand.Infrastructure.Bluetooth
{
    public interface IBluetoothMessageHandler
    {
        void Handle(string message);
    }
}