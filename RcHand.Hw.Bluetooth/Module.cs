using nanoFramework.DependencyInjection;
using nanoFramework.Device.Bluetooth.Spp;
using nanoFramework.Hosting;
using RcHand.Hw.Bluetooth.Parsers;

namespace RcHand.Hw.Bluetooth
{
    public static class Module
    {
        public static IServiceCollection AddBluetooth(this IServiceCollection services)
        {
            services.AddHostedService(typeof(BluetoothService))
                .AddSingleton(typeof(IBluetoothSpp), new NordicSpp())
                .AddSingleton(typeof(MoveFingerMessageParser))
                .AddSingleton(typeof(IBluetoothMessageHandler), typeof(BluetoothMessageHandler));
            return services;
        }
    }
}