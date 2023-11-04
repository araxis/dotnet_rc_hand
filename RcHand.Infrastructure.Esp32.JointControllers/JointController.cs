using System;
using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
    public class JointController:IJointController
    {
        private readonly IServoMotorResolver _motorResolver;

        public JointController(IServoMotorResolver motorResolver)
        {
            _motorResolver = motorResolver ?? throw new ArgumentNullException(nameof(motorResolver));
        }
        public void Move(Joint joint, int angle)
        {
            var motor = _motorResolver.GetAttachedMotor(joint);
            motor.WriteAngle(angle);
        }
    }
}