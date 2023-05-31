using AlumniPortal.Infrastructure.DbContext;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlumniPortal.Application.Features.AlumniEventFeatures.Commands
{
    public class DeleteAlumniEventByIdCommand : IRequest<int>
    {
        public string Id { get; set; }
        public class DeleteAlumniEventByIdCommandHandler : IRequestHandler<DeleteAlumniEventByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteAlumniEventByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteAlumniEventByIdCommand request, CancellationToken cancellationToken)
            {
                /* var customer = await _context.AlumniEvents.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                 if (customer == null) return default;
                 _context.AlumniEvents.Remove(customer);
                 await _context.SaveChangesAsync();
                 return customer.Id;*/
                return 1;
            }
        }
    }
}
