using System;
using System.Threading.Tasks;

namespace PureNotificationSystem.Services.Push.Services
{
    public interface IPushService
    {
        Task SendAsync(Guid messageId, string textMessage, string deviceToken, DateTime createdAt);
    }
}
