
using System;
using nanoFramework.DependencyInjection;

namespace RcHand.Infrastructure.Bluetooth
{
    public class BluetoothMessageHandler : IBluetoothMessageHandler
    {
        private readonly IMessageHandler[] _handlers;
        private readonly IServiceProvider _serviceProvider;
        public BluetoothMessageHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _handlers = GetHandlers();
        }

        public void Handle(string message)
        {
            var token = message.Trim();
            var commandLength = token.Length;
            if(commandLength ==0) return;
            for (var i = 0; i < _handlers.Length; i++)
            {
                var handler = _handlers[i];
                if(handler.Handle(message)) break;
            }

        }

        private IMessageHandler[] GetHandlers()
        {
            var services =_serviceProvider.GetServices(typeof(IMessageHandler));
            var count = services.Length;
            if (count == 0)
            {
                return new IMessageHandler[0];
            }
            var result = new IMessageHandler[count];
            for (var i = 0; i < count; i++)
            {
                result[i] = (IMessageHandler) services[i];
            }
            return result;
        }

    }
}