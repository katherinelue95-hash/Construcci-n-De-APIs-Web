using AutoMapper;
using StyleBookBarberBD.DTos;
using StyleBookBarberBD.DTOs;
using StyleBookBarberBD.Models;

namespace StyleBookBarberBD.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // 🔹 Servicios
            CreateMap<Servicios, ServiciosDTos>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria!.NombreCategoria))
                .ReverseMap();

            // 🔹 Citas
            CreateMap<Citas, CitasDTos>().ReverseMap();

            // 🔹 Usuarios
            CreateMap<Usuarios, RegistroDTO>().ReverseMap();

            // 🔹 Barberos
            CreateMap<Barberos, BarberosDTos>()
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.Usuario!.Nombre} {src.Usuario!.Apellido}"))
                .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Usuario!.Correo))
                .ReverseMap();
        }
    }
}


