using System;
using nanoFramework.Hosting;
using RcHand;
using RcHand.Infrastructure.Bluetooth;
using RcHand.Infrastructure.Esp32.JointControllers;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services
            .AddBluetooth()
            .AddThumbFinger(new ServoConfiguration(21))
            .AddIndexFinger(new ServoConfiguration(22))
            .AddMiddleFinger(new ServoConfiguration(23))
            .AddRingFinger(new ServoConfiguration(24))
            .AddLittleFinger(new ServoConfiguration(25));
    });

var host = builder.Build();
host.Run();

