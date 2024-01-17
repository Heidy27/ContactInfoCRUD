using ContactInfoCRUD.Domain.Entities;

namespace TuProyecto.Dominio.Interfaces
{
    public interface IPersonaContactoRepository
    {
        Task<PersonaContacto> GetByIdAsync(Guid id);
        Task<IEnumerable<PersonaContacto>> GetByPersonaIdAsync(Guid personaId);
        void Add(PersonaContacto personaContacto);
        void Update(PersonaContacto personaContacto);
        void Delete(PersonaContacto personaContacto);
    }
}
