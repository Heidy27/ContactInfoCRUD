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

        public async Task<PersonaContacto> GetByIdAsync(int id)
        {
            return await _context.PersonaContactos.FindAsync(id);
        }

        public async Task<IEnumerable<PersonaContacto>> GetByPersonaIdAsync(int personaId)
        {
            return await _context.PersonaContactos
                                 .Where(pc => pc.PersonaId == personaId)
                                 .ToListAsync();
        }

        public async Task AddAsync(PersonaContacto personaContacto)
        {
            try
            {
                await _context.PersonaContactos.AddAsync(personaContacto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el contacto de la persona", ex);
            }
        }

        public async Task UpdateAsync(PersonaContacto personaContacto)
        {
            try
            {
                _context.Entry(personaContacto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el contacto de la persona", ex);
            }
        }

        public async Task DeleteAsync(PersonaContacto personaContacto)
        {
            try
            {
                _context.PersonaContactos.Remove(personaContacto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el contacto de la persona", ex);
            }
        }
    }
}
