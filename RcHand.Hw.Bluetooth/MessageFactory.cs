using System;
using nanoFramework.DependencyInjection;
using RcHand.Hw.Bluetooth.Parsers;
using RcHand.Hw.Core;
using RcHand.Hw.Core.Messages;

namespace RcHand.Hw.Bluetooth
{
    public class MessageFactory :IMessageFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MessageFactory(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public IMessage CreateCommand(string message)
        {
            var tokens = message.Trim().Split(';');
            var commandLength = tokens.Length;
            if (commandLength == 0) return WrongFormatMessage.Instance;
            var mapper = GetMapper(tokens[0]);
            return mapper == null ? WrongFormatMessage.Instance : mapper.Parse(tokens);
        }

        private IMessageParser GetMapper(string commandType)
        {
            return (commandType  switch
            {
                Messages.MoveFinger=> _serviceProvider.GetRequiredService(typeof(MoveFingerMessageParser)),
                _ => null
            }) as IMessageParser;
        }
    }
}