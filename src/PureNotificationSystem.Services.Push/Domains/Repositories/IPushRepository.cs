using PureNotificationSystem.Services.Push.Domains.Models;
using System.Threading.Tasks;

namespace PureNotificationSystem.Services.Push.Domains.Repositories
{
    public interface IPushRepository
    {
        Task AddAsync(PushMessage push);

    }
}
