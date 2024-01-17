using ContactInfoCRUD.Application.DTOs;


namespace TuProyecto.Aplicacion.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDto>> GetAllPersonasAsync();
        Task<PersonaDto> GetPersonaByIdAsync(Guid id);
        Task<PersonaDto> CreatePersonaAsync(CrearPersonaDto personaDto);
        Task UpdatePersonaAsync(Guid id, PersonaDto personaDto);
        Task DeletePersonaAsync(Guid id);
    }
}
