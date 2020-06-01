using PureNotificationSystem.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PureNotificationSystem.Api.Repositories
{
    public interface IPushRepository
    {
        Task<IEnumerable<PushMessage>> BrowseAsync(string deviceToken);
    }
}
