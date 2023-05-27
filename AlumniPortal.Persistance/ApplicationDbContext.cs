using AlumniPortal.Domain.Entities;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Reflection.Metadata;

namespace AlumniPortal.Persistence
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<AlumniEvent> AlumniEvents => _database.GetCollection<AlumniEvent>("AlumniEvents");
        //public IMongoCollection<Blog> Blogs => _database.GetCollection<Blog>("blogs");
    }
}

