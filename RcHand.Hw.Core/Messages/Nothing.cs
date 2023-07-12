namespace RcHand.Hw.Core.Messages
{
    public class Nothing : IMessage
    {
        public static Nothing Instance => new();
        private Nothing() { }
    }
}