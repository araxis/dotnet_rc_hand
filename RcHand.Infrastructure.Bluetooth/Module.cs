using System;
using nanoFramework.DependencyInjection;
using nanoFramework.Device.Bluetooth.Spp;
using nanoFramework.Hosting;
using RcHand.Infrastructure.Bluetooth.MessageHandlers;

namespace RcHand.Infrastructure.Bluetooth
{
    public static class Module
    {
        public static IServiceCollection AddBluetooth(this IServiceCollection services)
        {
            return services
                 .AddHostedService(typeof(BluetoothService))
                 .AddSingleton(typeof(IBluetoothSpp), new NordicSpp())
                 .AddSingleton(typeof(IBluetoothMessageHandler), typeof(BluetoothMessageHandler))
                 .AddSingleton(typeof(IMessageHandler), typeof(MoveThumbFingerMessageHandler))
                 .AddSingleton(typeof(IMessageHandler), typeof(MoveIndexFingerMessageHandler))
                 .AddSingleton(typeof(IMessageHandler), typeof(MoveMiddleFingerMessageHandler))
                 .AddSingleton(typeof(IMessageHandler), typeof(MoveRingFingerMessageHandler))
                 .AddSingleton(typeof(IMessageHandler), typeof(MoveLittleFingerMessageHandler))
                 .AddSingleton(typeof(IMessageHandler), typeof(NotFoundMessageHandler));
        }
    }
}