using AlumniPortal.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlumniPortal.Application.Features.AlumniEventFeatures.Commands
{
    public class UpdateAlumniEventCommand : IRequest<int>
    {
        public string Id { get; set; }
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
        public class UpdateAlumniEventCommandHandler : IRequestHandler<UpdateAlumniEventCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateAlumniEventCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateAlumniEventCommand request, CancellationToken cancellationToken)
            {
                /*var cust = _context.AlumniEvents.Where(a => a.Id == request.Id).FirstOrDefault();

                if (cust == null)
                {
                    return default;
                }
                else
                {
                    cust.AlumniEventName = request.AlumniEventName;
                    cust.ContactName = request.ContactName;
                    _context.AlumniEvents.Update(cust);
                    await _context.SaveChangesAsync();
                    return cust.Id;
                }*/
                return 1;
            }
        }
    }
}
