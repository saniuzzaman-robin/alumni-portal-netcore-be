using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniPortal.Domain.Models
{
    [CollectionName("Users")]
    public class User : MongoIdentityUser<Guid>
    {
    }
}
