using nanoFramework.Hardware.Esp32;
using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers.Fingers
{
    public class RingFinger : ServoController, IThumbFinger
    {
        internal RingFinger(IServoConfiguration configuration) : base(configuration, DeviceFunction.PWM4)
        {
        }
    }
}