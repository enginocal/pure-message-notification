using PureNotificationSystem.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace PureNotificationSystem.Api.Repositories
{
    public class PushRepository : IPushRepository
    {
        private readonly IMongoDatabase _database;

        public PushRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<PushMessage>> BrowseAsync(string deviceToken)
            => await Collection
                .AsQueryable()
                .Where(x => x.DeviceToken == deviceToken)
                .OrderByDescending(x=>x.CreatedAt)
                .ToListAsync();

        private IMongoCollection<PushMessage> Collection
            => _database.GetCollection<PushMessage>("Messages");

    }
}
