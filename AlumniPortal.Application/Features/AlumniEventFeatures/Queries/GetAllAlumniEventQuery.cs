using MediatR;
using AlumniPortal.Domain.Entities;
using AlumniPortal.Infrastructure.DbContext;
using MongoDB.Driver;

namespace AlumniPortal.Application.Features.AlumniEventFeatures.Queries
{
    public class GetAllAlumniEventQuery : IRequest<IEnumerable<AlumniEvent>>
    {

        public class GetAllAlumniEventQueryHandler : IRequestHandler<GetAllAlumniEventQuery, IEnumerable<AlumniEvent>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllAlumniEventQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<AlumniEvent>> Handle(GetAllAlumniEventQuery request, CancellationToken cancellationToken)
            {
                var alumniEventList = await _context.AlumniEvents.FindAsync<AlumniEvent>(_ => true);
                return alumniEventList.ToList();
            }
        }
    }
}
