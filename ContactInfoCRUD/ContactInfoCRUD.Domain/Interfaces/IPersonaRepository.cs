using ContactInfoCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactInfoCRUD.Domain.Repositories
{
    public interface IPersonaRepository
    {
        Task<Persona> GetByIdAsync(int id);
        Task<Persona> GetByCedulaAsync(string cedula);
        Task<IEnumerable<Persona>> GetAllAsync();
        Task AddAsync(Persona persona);
        Task UpdateAsync(Persona persona);
        Task DeleteAsync(Persona persona);
    }
}
