using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AlumniPortal.Domain.Auth
{
    [CollectionName("Roles")]
    public class Role : MongoIdentityRole<Guid>
    {

    }
}
