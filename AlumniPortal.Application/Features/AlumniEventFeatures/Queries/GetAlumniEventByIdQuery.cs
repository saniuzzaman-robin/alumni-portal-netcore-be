using MediatR;
using AlumniPortal.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlumniPortal.Infrastructure.DbContext;
using MongoDB.Driver;

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
                var filter = Builders<AlumniEvent>.Filter.Eq("_id", Guid.Parse(request.Id));
                var alumniEvent = await _context.AlumniEvents.Find(filter).FirstOrDefaultAsync();
                return alumniEvent;
            }
        }
    }
}
