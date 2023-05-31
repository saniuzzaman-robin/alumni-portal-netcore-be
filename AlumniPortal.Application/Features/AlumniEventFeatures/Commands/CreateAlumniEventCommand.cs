using MediatR;
using AlumniPortal.Domain.Entities;
using AlumniPortal.Infrastructure.DbContext;

namespace AlumniPortal.Application.Features.AlumniEventFeatures.Commands
{
    public class CreateAlumniEventCommand : IRequest<string>
    {
        public string? Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string OrganizerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsSameDayEvent { get; set; }
        public bool? IsDressCodeMandatory { get; set; }
        public bool? IsRegistrationFeeAvailable { get; set; }
        public int? RegistrationFee { get; set; }
        public string? DressCode { get; set; }
        public string?[] Contacts { get; set; }
        public string? Location { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
    public class CreateAlumniEventCommandHandler : IRequestHandler<CreateAlumniEventCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private Guid guidOutput;

        public CreateAlumniEventCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(CreateAlumniEventCommand request, CancellationToken cancellationToken)
        {
            var alumniEvent = new AlumniEvent()
            {
                Id = Guid.TryParse(request.Id, out guidOutput) ? guidOutput : Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                OrganizerName = request.OrganizerName,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                LastUpdatedBy = request.OrganizerName,
                LastUpdatedDate = DateTime.UtcNow,
                CreatedBy = request.OrganizerName,
                CreatedDate = DateTime.UtcNow,
                IsSameDayEvent = request.IsSameDayEvent ?? false,
                IsDressCodeMandatory = request.IsDressCodeMandatory ?? false,
                IsRegistrationFeeAvailable = request.IsRegistrationFeeAvailable ?? false,
                RegistrationFee = request.RegistrationFee ?? 0,
                Contacts = request.Contacts,
                DressCode = request.DressCode,
                Location = request.Location,
                Region = request.Region,
                City = request.City,
                PostalCode = request.PostalCode,
                Country = request.Country
            };
            await _context.AlumniEvents.InsertOneAsync(alumniEvent);
            return alumniEvent.Id.ToString();
        }
    }
}
