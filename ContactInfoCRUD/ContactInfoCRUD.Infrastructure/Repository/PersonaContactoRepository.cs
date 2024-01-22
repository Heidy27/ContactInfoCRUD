using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Domain.Repositories;
using ContactInfoCRUD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactInfoCRUD.Infrastructure.Repositories
{
    public class PersonaContactoRepository : IPersonaContactoRepository
    {
        private readonly ContactInfoDbContext _context;

        public PersonaContactoRepository(ContactInfoDbContext context)
        {
            _context = context;
        }

        // Obtiene una persona de contacto por su ID
        public async Task<PersonaContacto> GetByIdAsync(int id)
        {
            return await _context.PersonaContactos.FindAsync(id);
        }

        // Obtiene una lista de personas de contacto por el ID de la persona asociada
        public async Task<IEnumerable<PersonaContacto>> GetByPersonaIdAsync(int personaId)
        {
            return await _context.PersonaContactos
                         .Where(pc => pc.PersonaId == personaId)
                         .Include(pc => pc.Persona)
                         .ToListAsync();
        }

        // Agrega una nueva persona de contacto a la base de datos
        public async Task AddAsync(PersonaContacto personaContacto)
        {
            await _context.PersonaContactos.AddAsync(personaContacto);
        }

        // Actualiza una persona de contacto en la base de datos
        public async Task UpdateAsync(PersonaContacto personaContacto)
        {
            _context.Entry(personaContacto).State = EntityState.Modified;
        }

        // Elimina una persona de contacto de la base de datos
        public async Task DeleteAsync(PersonaContacto personaContacto)
        {
            _context.PersonaContactos.Remove(personaContacto);
        }
    }
}
