using nanoFramework.Hardware.Esp32;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
    public interface IServoConfiguration
    {
        int PwmPin { get; }
        int Frequency { get; }
        int MinPulseWidth { get; }
        int MaxPulseWidth { get; }
    }
}