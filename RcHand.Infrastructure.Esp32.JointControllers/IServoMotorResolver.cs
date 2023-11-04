using Iot.Device.ServoMotor;
using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
    public interface IServoMotorResolver
    {
        ServoMotor GetAttachedMotor(Joint  joint);
    }
}