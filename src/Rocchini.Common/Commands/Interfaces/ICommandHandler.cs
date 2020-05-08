using System.Threading.Tasks;

namespace Rocchini.Common.Commands.Interfaces
{
    public interface ICommandHandler <in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
