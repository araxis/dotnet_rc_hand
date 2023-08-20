using RcHand.Infrastructure.Esp32.JointControllers;

namespace RcHand
{
    public class ServoConfiguration : IServoConfiguration
    {
        public ServoConfiguration(int pwmPin, int frequency = 50, int minPulseWidth = 500, int maxPulseWidth = 2300)
        {
            PwmPin = pwmPin;
            Frequency = frequency;
            MinPulseWidth = minPulseWidth;
            MaxPulseWidth = maxPulseWidth;
        }

        public int PwmPin { get; }
        public int Frequency { get; }
        public int MinPulseWidth { get; }
        public int MaxPulseWidth { get; }

    }
}