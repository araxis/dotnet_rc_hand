using System;
using RcHand.Application;

namespace RcHand.Infrastructure.Bluetooth.MessageHandlers
{
    public class MoveThumbFingerMessageHandler : IMessageHandler
    {
        private readonly IThumbFinger _finger;

        public MoveThumbFingerMessageHandler(IThumbFinger finger)
        {
            _finger = finger ?? throw new ArgumentNullException(nameof(finger));
        }

        public bool Handle(string message)
        {
            throw new NotImplementedException();
        }
    }
}