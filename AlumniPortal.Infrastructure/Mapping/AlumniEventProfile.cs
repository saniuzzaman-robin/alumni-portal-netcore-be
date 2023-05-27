using AutoMapper;
using AlumniPortal.Domain.Entities;
using AlumniPortal.Infrastructure.ViewModel;

namespace AlumniPortal.Infrastructure.Mapping
{
    public class AlumniEventProfile : Profile
    {
        public AlumniEventProfile()
        {
            CreateMap<AlumniEventViewModel, AlumniEvent>()
                .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.AlumniEventId))
                .ReverseMap();
        }
    }
}
