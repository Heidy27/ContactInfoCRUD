using AutoMapper;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Application.Command;

namespace ContactInfoCRUD.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeos de Persona
            CreateMap<Persona, PersonaDto>();
            CreateMap<CrearPersonaDto, Persona>();

            // Mapeos de PersonaContacto
            CreateMap<PersonaContacto, PersonaContactoDto>();
            CreateMap<CrearPersonaContactoDto, PersonaContacto>();

            // Mapeo - Crear persona o persona contacto
            CreateMap<CrearPersonaContactoCommand, PersonaContacto>()
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Celular))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Telefono))
                .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Dirección, opt => opt.MapFrom(src => src.Direccion))
                .ForMember(dest => dest.PersonaId, opt => opt.MapFrom(src => src.PersonaId));

            // Mapeo - Actualizar persona o persona contacto 
            CreateMap<ActualizarPersonaContactoCommand, PersonaContacto>()
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.NuevoCelular))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.NuevoTelefono))
                .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.NuevoCorreo))
                .ForMember(dest => dest.Dirección, opt => opt.MapFrom(src => src.NuevaDireccion));

            // Mapeo - Comando de eliminar una persona o persona de contacto
            CreateMap<EliminarPersonaCommand, Persona>();
            CreateMap<EliminarPersonaContactoCommand, PersonaContacto>();

        }
    }
}
