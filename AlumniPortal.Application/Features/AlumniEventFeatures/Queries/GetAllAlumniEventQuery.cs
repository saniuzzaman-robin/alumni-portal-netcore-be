using MediatR;
using AlumniPortal.Domain.Entities;
using AlumniPortal.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
                /*var customerList = await _context.AlumniEvents.ToListAsync();
                if (customerList == null)
                {
                    return null;
                }
                return customerList.AsReadOnly();*/
                return null;
            }
        }
    }
}
