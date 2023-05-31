using AlumniPortal.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniPortal.Infrastructure.DbContext
{
    public interface IApplicationDbContext
    {
        IMongoCollection<AlumniEvent> AlumniEvents { get; }
        //IMongoCollection<Blog> Blogs { get; }
    }
}
