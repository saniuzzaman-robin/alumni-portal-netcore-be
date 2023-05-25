using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlumniPortal.Domain.Models
{
    public class AlumniEvent
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Manager { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsSameDayEvent { get; set; }
        public bool? IsDressCodeMandatory { get; set; }
        public bool? IsRegistrationFeeAvailable { get; set; }
        public int? RegistrationFee { get; set; }
        public string? DressCode { get; set; }

    }
}
