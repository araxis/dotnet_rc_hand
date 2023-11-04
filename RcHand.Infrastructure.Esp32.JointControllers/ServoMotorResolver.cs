using System;
using Iot.Device.ServoMotor;
using RcHand.Application;
using System.Device.Pwm;
using nanoFramework.Hardware.Esp32;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
    internal class ServoMotorResolver : IServoMotorResolver
    {
        private readonly IConfigurationFactory _configurationFactory;
        private readonly ServoMotor _thumbMotor;
        private readonly ServoMotor _indexMotor;
        private readonly ServoMotor _middleMotor;
        private readonly ServoMotor _ringMotor;
        private readonly ServoMotor _littleMotor;
        public ServoMotorResolver(IConfigurationFactory configurationFactory)
        {
            _configurationFactory = configurationFactory;
            _thumbMotor = CreateMotor(Joint.Thumb);
            _indexMotor = CreateMotor(Joint.Index);
            _middleMotor = CreateMotor(Joint.Middle);
            _ringMotor = CreateMotor(Joint.Ring);
            _littleMotor = CreateMotor(Joint.Little);
        }

        public ServoMotor GetAttachedMotor(Joint joint)
        {
            var motor = joint.Id switch
            {
                0 => _thumbMotor,
                1 => _indexMotor,
                2 => _middleMotor,
                3 => _ringMotor,
                4 => _littleMotor,
                _ => throw new ArgumentOutOfRangeException()
            };
            motor.Start();
            return motor;
        }

        private  ServoMotor CreateMotor(Joint joint)
        {
            var configuration = _configurationFactory.GetServoConfiguration(joint);
            Configuration.SetPinFunction(configuration.PwmPin, configuration.DeviceFunction);
            var pwmChannel = PwmChannel.CreateFromPin(configuration.PwmPin, configuration.Frequency);
            return new ServoMotor(pwmChannel, configuration.MaxAngle, configuration.MinPulseWidth, configuration.MaxPulseWidth);
        }
    }
}