using System.Threading;
using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
    public class DelayHandler :IDelayHandler
    {
        public void Delay(int ms) => Thread.Sleep(ms);
    }
}