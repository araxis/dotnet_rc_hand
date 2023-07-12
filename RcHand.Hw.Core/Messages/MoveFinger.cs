namespace RcHand.Hw.Core.Messages
{
    public abstract class MoveFinger : IMessage
    {
        protected MoveFinger(int degree)
        {
            Degree = degree;
        }
        public int Degree { get; private set; }

    }
}
