using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
    internal interface IConfigurationFactory
    {
        ServoConfiguration GetServoConfiguration(Joint joint);
    }
}