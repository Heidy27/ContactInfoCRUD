using ContactInfoCRUD.Application.DTOs;

namespace ContactInfoCRUD.Application.DTOs
{
    public interface IPersonaContactoService
    {
        Task<IEnumerable<PersonaContactoDto>> GetAllContactosByPersonaIdAsync(int personaId);
        Task<PersonaContactoDto> GetContactoByIdAsync(int id);
        Task<PersonaContactoDto> CreateContactoAsync(CrearPersonaContactoDto contactoDto);
        Task UpdateContactoAsync(int id, PersonaContactoDto contactoDto);
        Task DeleteContactoAsync(int id);
    }
}
