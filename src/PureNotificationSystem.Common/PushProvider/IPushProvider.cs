using System.Threading.Tasks;

namespace PureNotificationSystem.Common.PushProvider
{
    public interface IPushProvider
    {
        Task Send();
    }
}
