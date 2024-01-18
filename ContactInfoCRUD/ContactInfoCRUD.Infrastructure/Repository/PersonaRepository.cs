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

        public async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<Persona> GetByCedulaAsync(string cedula)
        {
            return await _context.Personas.FirstOrDefaultAsync(p => p.Cedula == cedula);
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task AddAsync(Persona persona)
        {
            try
            {
                await _context.Personas.AddAsync(persona);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la persona", ex);
            }
        }

        public async Task UpdateAsync(Persona persona)
        {
            try
            {
                _context.Entry(persona).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la persona", ex);
            }
        }

        public async Task DeleteAsync(Persona persona)
        {
            try
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la persona", ex);
            }
        }
    }
}
