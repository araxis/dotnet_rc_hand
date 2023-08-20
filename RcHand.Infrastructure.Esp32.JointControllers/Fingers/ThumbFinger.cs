using nanoFramework.Hardware.Esp32;
using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers.Fingers
{
    public class ThumbFinger : ServoController, IThumbFinger
    {
        internal ThumbFinger(IServoConfiguration configuration) : base(configuration, DeviceFunction.PWM1)
        {
        }
    }
}