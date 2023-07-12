namespace RcHand.Hw.Core
{
    public interface IMessageHandler<in TMessage> where TMessage:IMessage
    {
        void Execute(TMessage command);
    }
}