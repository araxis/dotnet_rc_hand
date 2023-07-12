using Iot.Device.ServoMotor;
using nanoFramework.Hardware.Esp32;
using RcHand.Hw.Core;
using RcHand.Hw.Core.Messages;
using System.Device.Pwm;

namespace RcHand.Hw.Handlers
{
    public class MoveLittleMessageHandler : IMessageHandler<MoveThumb>
    {
        private readonly ServoMotor _motor;
        public MoveLittleMessageHandler()
        {
            Configuration.SetPinFunction(21, DeviceFunction.PWM1);
            var pwmChannel = PwmChannel.CreateFromPin(21, 50);
            _motor =new ServoMotor(pwmChannel, 180, 500, 2300);
            _motor.Start();
        }
        public void Execute(MoveThumb command)
        {
            _motor.WriteAngle(command.Degree);
        }
    }
}