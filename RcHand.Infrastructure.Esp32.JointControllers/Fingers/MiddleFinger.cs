using nanoFramework.Hardware.Esp32;
using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers.Fingers
{
    public class MiddleFinger : ServoController, IThumbFinger
    {
        internal MiddleFinger(IServoConfiguration configuration) : base(configuration, DeviceFunction.PWM3)
        {
        }
    }
}