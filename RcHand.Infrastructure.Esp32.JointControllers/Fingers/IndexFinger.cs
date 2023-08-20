using nanoFramework.Hardware.Esp32;
using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers.Fingers
{
    public class IndexFinger : ServoController, IThumbFinger
    {
        internal IndexFinger(IServoConfiguration configuration) : base(configuration, DeviceFunction.PWM2)
        {
        }
    }
}