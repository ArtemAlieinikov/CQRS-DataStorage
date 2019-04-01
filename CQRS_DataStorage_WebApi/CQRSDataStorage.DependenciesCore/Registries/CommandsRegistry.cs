using CQRSDataStorage.Commands;
using CQRSDataStorage.Commands.Abstractions;
using CQRSDataStorage.Commands.Commands;
using CQRSDataStorage.Commands.Handlers;
using StructureMap;

namespace CQRSDataStorage.DependenciesCore.Registries
{
    public class CommandsRegistry : Registry
    {
        public CommandsRegistry()
        {
            For<ICommandDispatcher>().Use<CommandDispatcher>();

            For<ICommandHandler<AddEmployeeCommand>>().Use<AddEmployeeHandler>();

            For<ICommandHandler<DeleteEmployeeCommand>>().Use<DeleteEmployeeHandler>();
        }
    }
}