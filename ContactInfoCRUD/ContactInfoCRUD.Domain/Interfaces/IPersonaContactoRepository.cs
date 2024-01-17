using ContactInfoCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactInfoCRUD.Domain.Repositories
{
    public interface IPersonaContactoRepository
    {
        Task<PersonaContacto> GetByIdAsync(int id);
        Task<IEnumerable<PersonaContacto>> GetByPersonaIdAsync(int personaId);
        Task AddAsync(PersonaContacto personaContacto);
        Task UpdateAsync(PersonaContacto personaContacto);
        Task DeleteAsync(PersonaContacto personaContacto);
    }
}
