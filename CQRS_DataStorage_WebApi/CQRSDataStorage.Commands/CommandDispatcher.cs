using CQRSDataStorage.Commands.Abstractions;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSDataStorage.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();

            handler.Execute(command);
        }
    }
}