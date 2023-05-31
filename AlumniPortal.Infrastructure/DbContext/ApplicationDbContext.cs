using AlumniPortal.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniPortal.Infrastructure.DbContext
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
