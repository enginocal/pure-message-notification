using System.Threading.Tasks;

namespace PureNotificationSystem.Common.Mongo
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}