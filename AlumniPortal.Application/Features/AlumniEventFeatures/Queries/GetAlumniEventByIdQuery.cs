using MediatR;
using AlumniPortal.Domain.Entities;
using AlumniPortal.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlumniPortal.Application.Features.AlumniEventFeatures.Queries
{
    public class GetAlumniEventByIdQuery : IRequest<AlumniEvent>
    {
        public string Id { get; set; }
        public class GetAlumniEventByIdQueryHandler : IRequestHandler<GetAlumniEventByIdQuery, AlumniEvent>
        {
            private readonly IApplicationDbContext _context;
            public GetAlumniEventByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<AlumniEvent> Handle(GetAlumniEventByIdQuery request, CancellationToken cancellationToken)
            {
                /*var customer = _context.AlumniEvents.Where(a => a.Id == request.Id).FirstOrDefault();
                if (customer == null) return null;
                return customer;*/
                return null;
            }
        }
    }
}
