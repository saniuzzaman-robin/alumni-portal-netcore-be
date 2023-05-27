using System.ComponentModel.DataAnnotations;

namespace AlumniPortal.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
