using AlumniPortal.Application.Repositories;
using Microsoft.Extensions.Configuration;

namespace AlumniPortal.Infrastructure.DbContext
{
    using MongoDB.Driver;

    public class AlumniEventMongoDatabase : IAlumniEventMongoDatabase
    {
        private readonly MongoClient _client;
        private readonly string _databaseName;

        public AlumniEventMongoDatabase(IConfiguration configuration)
        {
            _client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _databaseName = configuration.GetConnectionString("AlumniDatabaseName");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _client.GetDatabase(_databaseName, new MongoDatabaseSettings
            {
                GuidRepresentation = MongoDB.Bson.GuidRepresentation.Standard
            }).GetCollection<T>(name);
        }
    }
}
