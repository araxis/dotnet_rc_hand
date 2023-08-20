using System;
using System.Device.Pwm;
using Iot.Device.ServoMotor;
using nanoFramework.Hardware.Esp32;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
    public abstract class ServoController
    {
        private readonly ServoMotor _motor;

        internal ServoController(IServoConfiguration configuration,DeviceFunction deviceFunction)
        {
            if (configuration is null) throw new ArgumentNullException(nameof(configuration));
            Configuration.SetPinFunction(21, deviceFunction);
            var pwmChannel = PwmChannel.CreateFromPin(21, 50);
            _motor =new ServoMotor(pwmChannel, 180, 500, 2300);
            _motor.Start();
        }

        public void Move(int degree) => _motor.WriteAngle(degree);

    }
}