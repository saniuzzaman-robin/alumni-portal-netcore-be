using AlumniPortal.Domain.Entities;
using AlumniPortal.Infrastructure.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
