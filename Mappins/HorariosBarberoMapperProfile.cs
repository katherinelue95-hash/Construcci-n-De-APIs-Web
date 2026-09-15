using AutoMapper;
using StyleBookBarberBD.DTos;
using StyleBookBarberBD.DTOs;
using StyleBookBarberBD.Models;

namespace StyleBookBarberBD.Mappings
{
    public class HorariosBarberoMapperProfile : Profile
    {
        public HorariosBarberoMapperProfile()
        {
            CreateMap<HorariosBarbero, HorariosBarberoDTos>()
                .ForMember(dest => dest.HoraInicio, opt => opt.MapFrom(src => src.HoraInicio.ToString(@"hh\:mm")))
                .ForMember(dest => dest.HoraFin, opt => opt.MapFrom(src => src.HoraFin.ToString(@"hh\:mm")));

            CreateMap<HorariosBarberoDTos, HorariosBarbero>()
                .ForMember(dest => dest.HoraInicio, opt => opt.MapFrom(src => TimeSpan.Parse(src.HoraInicio)))
                .ForMember(dest => dest.HoraFin, opt => opt.MapFrom(src => TimeSpan.Parse(src.HoraFin)));
        }
    }
}

