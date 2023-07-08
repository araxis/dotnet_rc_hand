using System.Collections;

namespace RcHand
{
    public interface ICommandLineParser
    {
        ICommand[] Parse(string command);
    }
}