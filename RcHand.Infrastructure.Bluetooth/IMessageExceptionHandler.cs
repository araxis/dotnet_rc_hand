using System;

namespace RcHand.Infrastructure.Bluetooth
{
    internal interface IMessageExceptionHandler
    {
        bool Handle(Exception  exception);
    }
}