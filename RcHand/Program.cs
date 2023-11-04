using Microsoft.Extensions.Logging;
using nanoFramework.DependencyInjection;
using nanoFramework.Hosting;
using nanoFramework.Logging.Debug;
using RcHand.Infrastructure.Bluetooth;
using RcHand.Infrastructure.Esp32.JointControllers;

//using RcHand.MessageBus;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services
            .AddSingleton(typeof(ILoggerFactory), typeof(DebugLoggerFactory))
            .AddEsp32Hardware()
            .AddBluetooth();
    });

var host = builder.Build();
host.Run();

