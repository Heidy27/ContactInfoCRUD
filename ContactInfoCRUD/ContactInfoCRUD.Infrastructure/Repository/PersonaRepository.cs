using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Domain.Repositories;
using ContactInfoCRUD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactInfoCRUD.Infrastructure.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly ContactInfoDbContext _context;

        public PersonaRepository(ContactInfoDbContext context)
        {
            _context = context;
        }

        // Obtiene una persona por su ID
        public async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        // Obtiene una persona por su número de cédula
        public async Task<Persona> GetByCedulaAsync(string cedula)
        {
            return await _context.Personas.FirstOrDefaultAsync(p => p.Cedula == cedula);
        }

        // Obtiene todas las personas en la base de datos
        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        // Agrega una nueva persona a la base de datos
        public async Task AddAsync(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
        }

        // Actualiza una persona en la base de datos
        public async Task UpdateAsync(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
        }

        // Elimina una persona de la base de datos
        public async Task DeleteAsync(Persona persona)
        {
            _context.Personas.Remove(persona);
        }

    }
}
