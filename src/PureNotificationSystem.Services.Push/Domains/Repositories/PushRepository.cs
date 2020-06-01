using MongoDB.Driver;
using PureNotificationSystem.Services.Push.Domains.Models;
using System.Threading.Tasks;

namespace PureNotificationSystem.Services.Push.Domains.Repositories
{
    public class PushRepository : IPushRepository
    {
        private readonly IMongoDatabase _database;

        public PushRepository(IMongoDatabase database)
        {
            _database = database;
        }


        public async Task AddAsync(PushMessage push)
        {
            await Collection.InsertOneAsync(push);
        }

        private IMongoCollection<PushMessage> Collection
            => _database.GetCollection<PushMessage>("Messages");
    }
}
