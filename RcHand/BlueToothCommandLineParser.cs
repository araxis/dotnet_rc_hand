using System;

namespace RcHand
{
    public class BlueToothCommandLineParser : ICommandLineParser
    {
        private readonly IServiceProvider _serviceProvider;

        public BlueToothCommandLineParser(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommand[] Parse(string message)
        {
            var tokens = message.Trim().Split(';');
            var commandLength = tokens.Length;
            if (commandLength == 0) return Collections.EmptyCommandList;
            var commands = new ICommand[commandLength];

            return commands;

        }

        private ICommand ParseToken(string token)
        {
            var data = token.Trim().Split('/');
            var length = data.Length;
            if(length == 0) return NopeCommand.Instance;
            var messageType = data[0];
            return messageType switch
            {
                Collections.Move => NopeCommand.Instance,
                _ => NopeCommand.Instance
            };
        }
    }
}