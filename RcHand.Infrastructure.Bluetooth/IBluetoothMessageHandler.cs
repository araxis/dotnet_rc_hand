namespace RcHand.Infrastructure.Bluetooth
{
    internal interface IBluetoothMessageHandler
    {
        void Handle(string message);
    }
}