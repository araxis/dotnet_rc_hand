using System;
using System.Diagnostics;
using nanoFramework.Device.Bluetooth.Spp;
using nanoFramework.Hosting;

namespace RcHand.Infrastructure.Bluetooth
{
    public class BluetoothService : BackgroundService
    {
        private readonly IBluetoothSpp _spp ;
        private readonly IBluetoothMessageHandler _messageHandler;
        public BluetoothService( IBluetoothSpp spp, IBluetoothMessageHandler messageHandler)
        {

            _spp = spp;
            _messageHandler = messageHandler;
            _spp.ReceivedData += SppReceivedData;
            _spp.ConnectedEvent += SppConnectedEvent;
        }

        protected override void ExecuteAsync()
        {
            _spp.Start("RcHand");
            Console.WriteLine("bluetooth started");
        }

        public override void Dispose()
        {
            _spp.Stop();
        }

        private void SppConnectedEvent(IBluetoothSpp sender, EventArgs e)
        {
            if (_spp.IsConnected)
            {
                _spp.SendString($"Welcome to BlueTooth Serial sample\n");
                _spp.SendString($"Send 'help' for options\n");
            }

            Debug.WriteLine($"Client connected:{sender.IsConnected}");
        }

        private void SppReceivedData(IBluetoothSpp sender, SppReceivedDataEventArgs readRequestEventArgs)
        {
            var message = readRequestEventArgs.DataString;
           _messageHandler.Handle(message);
        }
    }
}