using AutoMapper;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Domain.Entities;

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
        }
    }
}
