using nanoFramework.Hosting;
using nanoFramework.DependencyInjection;
using nanoFramework.Device.Bluetooth.Spp;
using RcHand;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices(services => services
        .AddHostedService(typeof(BluetoothService))
        .AddSingleton(typeof(IBluetoothSpp),new NordicSpp())
        .AddSingleton(typeof(ICommandLineParser), typeof(BlueToothCommandLineParser)));

var host = builder.Build();
host.Run();



