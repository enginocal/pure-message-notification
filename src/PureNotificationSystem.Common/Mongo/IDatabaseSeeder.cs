using System.Threading.Tasks;

namespace PureNotificationSystem.Common.Mongo
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}