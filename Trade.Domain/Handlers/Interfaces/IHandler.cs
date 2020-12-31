using Trade.Domain.Commands.Interfaces;

namespace Trade.Domain.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}