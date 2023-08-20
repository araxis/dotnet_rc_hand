using nanoFramework.Hardware.Esp32;
using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers.Fingers
{
    public class LittleFinger : ServoController, IThumbFinger
    {
        internal LittleFinger(IServoConfiguration configuration) : base(configuration, DeviceFunction.PWM3)
        {
        }
    }
}