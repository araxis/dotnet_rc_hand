
using System;
using Microsoft.Extensions.Logging;
using RcHand.Application;

namespace RcHand.Infrastructure.Bluetooth
{
    internal class BluetoothMessageHandler : IBluetoothMessageHandler
    {
        private readonly IJointController _jointController;
        private readonly IDelayHandler _delayHandler;
        private readonly IMessageExceptionHandler _messageExceptionHandler;
        private readonly ILogger _logger;
        public BluetoothMessageHandler(IJointController jointController, IDelayHandler delayHandler, IMessageExceptionHandler exceptionHandler, ILoggerFactory loggerFactory)
        {
            _jointController = jointController ?? throw new ArgumentNullException(nameof(jointController));
            _delayHandler = delayHandler ?? throw new ArgumentNullException(nameof(delayHandler));
            _messageExceptionHandler = exceptionHandler ?? throw new ArgumentNullException(nameof(exceptionHandler));
            if(loggerFactory is null) throw new ArgumentNullException(nameof(loggerFactory));
            _logger = loggerFactory.CreateLogger(nameof(BluetoothMessageHandler));
        }
        public void Handle(string commands)
        {
            var commandList = commands.Trim().Split(Messages.CommandSeparator);
            foreach (var command in commandList)
            {
                try
                {
                    if(command.Length<2) continue;
                    _logger.LogDebug($"Processing command: {command}");
                    var parts = command.Split(Messages.ParamSeparator);
                    switch (parts[0])
                    {
                        case Messages.MoveCommand:
                            ExecuteMoveCommand(parts);
                            break;
                        case Messages.DelayCommand:
                            ExecuteDelayCommand(parts);
                            break;
                        default:
                            throw new InvalidOperationException("Invalid command type.");
                    }
                    _logger.LogDebug($"Processed command: {command}");
                }
                catch (Exception e)
                {
                   var handled= _messageExceptionHandler.Handle(e);
                   if(!handled) return;
                }

            }
        }
        private void ExecuteMoveCommand(string[] parts)
        {
            if (parts.Length != 3)
                throw new ArgumentException("Move command must have 2 parameters: joint and degree.");

            if (!int.TryParse(parts[1], out var jointId) || !int.TryParse(parts[2], out var degree))
                throw new ArgumentException("Parameters for move command must be integers.");

            var joint = GetJointById(jointId);
            _jointController.Move(joint, degree);
        }
        private void ExecuteDelayCommand(string[] parts)
        {
            if (parts.Length != 2)
                throw new ArgumentException("Delay command must have 1 parameter: value in ms.");

            if (!int.TryParse(parts[1], out var delay))
                throw new ArgumentException("Parameter for delay command must be an integer.");

            _delayHandler.Delay(delay);
        }
        private static Joint GetJointById(int jointId) => jointId switch
        {
            0 => Joint.Thumb,
            1 => Joint.Index,
            2 => Joint.Middle,
            3 => Joint.Ring,
            4 => Joint.Little,
            _ => throw new ArgumentOutOfRangeException(nameof(jointId), "Invalid joint ID.")
        };
    }
}