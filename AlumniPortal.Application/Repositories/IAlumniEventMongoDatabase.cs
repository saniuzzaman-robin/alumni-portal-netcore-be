using MongoDB.Driver;

namespace AlumniPortal.Application.Repositories
{
    public interface IAlumniEventMongoDatabase
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
