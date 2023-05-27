using MediatR;
using AlumniPortal.Domain.Entities;
using AlumniPortal.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace AlumniPortal.Application.Features.AlumniEventFeatures.Commands
{
    public class CreateAlumniEventCommand : IRequest<int>
    {
        public string AlumniEventName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public class CreateAlumniEventCommandHandler : IRequestHandler<CreateAlumniEventCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateAlumniEventCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateAlumniEventCommand request, CancellationToken cancellationToken)
            {
                /*var customer = new AlumniEvent();
                customer.AlumniEventName = request.AlumniEventName;
                customer.ContactName = request.ContactName;

                _context.AlumniEvents.Add(customer);
                await _context.SaveChangesAsync();
                return customer.Id;*/
                return 1;
            }
        }
    }
}
