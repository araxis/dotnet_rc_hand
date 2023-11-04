using nanoFramework.Hardware.Esp32;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
    internal class ServoConfiguration
    {
        public ServoConfiguration(int pwmPin,DeviceFunction deviceFunction,int maxAngle = 180, int frequency = 50, int minPulseWidth = 500, int maxPulseWidth = 2300)
        {
            this.PwmPin = pwmPin;
            this.DeviceFunction = deviceFunction;
            this.MaxAngle = maxAngle;
            this.Frequency = frequency;
            this.MinPulseWidth = minPulseWidth;
            this.MaxPulseWidth = maxPulseWidth;
        }

        public int PwmPin { get; }
        public DeviceFunction DeviceFunction { get; }
        public int MaxAngle { get; }
        public int Frequency { get; }
        public int MinPulseWidth { get; }
        public int MaxPulseWidth { get; }
    }
}