using ContactInfoCRUD.Domain.Entities;

namespace ContactInfoCRUD.Domain.Repositories
{
    public interface IPersonaRepository
    {
        Task<Persona> GetByIdAsync(Guid id);
        Task<Persona> GetByCedulaAsync(string cedula);
        Task<IEnumerable<Persona>> GetAllAsync();
        void Add(Persona persona);
        void Update(Persona persona);
        void Delete(Persona persona);
    }
}
