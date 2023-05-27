using AlumniPortal.Application.Repositories;
using AlumniPortal.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace AlumniPortal.Infrastructure.Repositories
{
    public class AlumniEventRepository: IAlumniEventRepository
    {
        private readonly IMongoCollection<AlumniEvent> _collection;

        public AlumniEventRepository(IAlumniEventMongoDatabase database, IConfiguration configuration)
        {
            _collection = database.GetCollection<AlumniEvent>(configuration.GetConnectionString("AlumniEventCollectionName"));
        }

        public async Task<IReadOnlyList<AlumniEvent>> GetAsync()
        {
            var alumniEvents = await _collection.Find(_ => true).ToListAsync();
            return alumniEvents;
        }

        public async Task<AlumniEvent> GetByIdAsync(string id)
        {
            var filter = Builders<AlumniEvent>.Filter.Eq("_id", Guid.Parse(id));
            var alumniEvent = await _collection.Find(filter).FirstOrDefaultAsync();
            return alumniEvent;
        }

        public async Task CreateAsync(AlumniEvent alumniEvent)
        {
            await _collection.InsertOneAsync(alumniEvent);
        }

        public async Task UpdateAsync(AlumniEvent alumniEvent)
        {
            var filter = Builders<AlumniEvent>.Filter.Eq("_id", alumniEvent.Id);
            await _collection.ReplaceOneAsync(filter, alumniEvent);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<AlumniEvent>.Filter.Eq("_id", Guid.Parse(id));
            await _collection.DeleteOneAsync(filter);
        }

    }
}
