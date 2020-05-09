using System.Threading.Tasks;

namespace Rocchini.Common.Events.Interfaces
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}
