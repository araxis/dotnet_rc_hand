namespace RcHand
{
    public class NopeCommand:ICommand
    {
        public static ICommand Instance => new NopeCommand();

        private NopeCommand() { }
        public void Execute(string[] args) { }
    }
}