using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AlumniPortal.Domain.Models
{
    [CollectionName("Roles")]
    public class Role : MongoIdentityRole<Guid>
    {
        
    }
}
