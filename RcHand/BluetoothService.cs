using System;
using System.Diagnostics;
using nanoFramework.Device.Bluetooth.Spp;
using nanoFramework.Hosting;

namespace RcHand
{
    public class BluetoothService : BackgroundService
    {
        private readonly IBluetoothSpp _spp ;
        private readonly ICommandLineParser _parser;

        public BluetoothService(ICommandLineParser parser, IBluetoothSpp spp)
        {
            _parser = parser;
            _spp = spp;
            _spp.ReceivedData += SppReceivedData;
            _spp.ConnectedEvent += SppConnectedEvent;
        }

        protected override void ExecuteAsync()
        {
            _spp.Start("RcHand");
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

        private static void SppReceivedData(IBluetoothSpp sender, SppReceivedDataEventArgs readRequestEventArgs)
        {
            var message = readRequestEventArgs.DataString;
            Debug.WriteLine($"Received=>{message}");
        }
    }
}