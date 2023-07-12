namespace RcHand.Hw.Core.Messages
{
    public class WrongFormatMessage : IMessage
    {
        public static readonly WrongFormatMessage Instance = new();
        private WrongFormatMessage()
        {

        }
    }
}