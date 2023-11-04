using nanoFramework.DependencyInjection;
using nanoFramework.Device.Bluetooth.Spp;
using nanoFramework.Hosting;

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
                .AddSingleton(typeof(IMessageExceptionHandler),typeof(LogExceptionHandler));
        }
    }
}