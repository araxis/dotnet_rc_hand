using System;
using nanoFramework.Hardware.Esp32;
using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
   internal class ConfigurationFactory : IConfigurationFactory
    {
        public ServoConfiguration GetServoConfiguration(Joint joint)
        {
            return joint.Id switch
            {
                0 => new ServoConfiguration(21,DeviceFunction.PWM1),
                1 => new ServoConfiguration(22,DeviceFunction.PWM2),
                2 => new ServoConfiguration(23,DeviceFunction.PWM3),
                3 => new ServoConfiguration(26,DeviceFunction.PWM4),
                4 => new ServoConfiguration(25,DeviceFunction.PWM5),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}