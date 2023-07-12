

namespace RcHand.Hw.Bluetooth
{
    public class BluetoothMessageHandler : IBluetoothMessageHandler
    {
        private readonly IMessageFactory _commandFactory;

        public BluetoothMessageHandler(IMessageFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public void Handle(string message)
        {
            var command = _commandFactory.CreateCommand(message);
        }


    }
}