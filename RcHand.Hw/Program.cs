using nanoFramework.Hosting;
using RcHand.Hw.Bluetooth;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddBluetooth();
    });

var host = builder.Build();
host.Run();
