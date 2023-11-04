using System;
using Microsoft.Extensions.Logging;

namespace RcHand.Infrastructure.Bluetooth
{
    internal class LogExceptionHandler : IMessageExceptionHandler
    {
        private readonly ILogger _logger;

        public LogExceptionHandler(ILoggerFactory loggerFactory)
        {
            if(loggerFactory == null) throw new ArgumentNullException(nameof(loggerFactory));
            _logger = loggerFactory.CreateLogger(nameof(LogExceptionHandler));
        }

        public bool Handle(Exception exception)
        {
            _logger.LogError(exception.Message,exception);
            return true;
        }
    }
}