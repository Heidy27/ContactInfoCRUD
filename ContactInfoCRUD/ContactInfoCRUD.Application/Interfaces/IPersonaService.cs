using ContactInfoCRUD.Application.DTOs;


namespace ContactInfoCRUD.Application.DTOs
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDto>> GetAllPersonasAsync();
        Task<PersonaDto> GetPersonaByIdAsync(int id);
        Task<PersonaDto> CreatePersonaAsync(CrearPersonaDto personaDto);
        Task UpdatePersonaAsync(int id, PersonaDto personaDto);
        Task DeletePersonaAsync(int id);
    }
}
