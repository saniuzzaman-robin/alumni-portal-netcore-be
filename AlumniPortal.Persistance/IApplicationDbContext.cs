using AlumniPortal.Domain.Entities;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace AlumniPortal.Persistence
{
    public interface IApplicationDbContext
    {
        IMongoCollection<AlumniEvent> AlumniEvents { get; }
        //IMongoCollection<Blog> Blogs { get; }
    }
}
