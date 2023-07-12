using System;

namespace RcHand.Hw
{
    public interface IServo : IDisposable
    {
        void Calibrate(double maximumAngle, double minimumPulseWidthMicroseconds, double maximumPulseWidthMicroseconds);
        void Start();
        void Stop();
        void WriteAngle(double angle);
        void WritePulseWidth(int microseconds);
    }
}