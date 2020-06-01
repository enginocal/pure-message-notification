using System.Threading.Tasks;

namespace PureNotificationSystem.Common.Events
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T @event);
    }
}