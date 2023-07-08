namespace RcHand
{
    public class MoveCommand : ICommand
    {
        public void Execute(string[] args)
        {
            if(args is null) return;
            if(args.Length < 3) return;
            var commandType = args[0];
            var servoNumber = args[1];
            var position = args[2];
        }
    }
}