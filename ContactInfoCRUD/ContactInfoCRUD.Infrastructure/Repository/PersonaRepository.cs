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

        public async Task<Persona> GetByIdAsync(Guid id)
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

        public void Add(Persona persona)
        {
            try
            {
                _context.Personas.Add(persona);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la persona", ex);
            }
        }

        public void Update(Persona persona)
        {
            try
            {
                _context.Entry(persona).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la persona", ex);
            }
        }

        public void Delete(Persona persona)
        {
            try
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la persona", ex);
            }
        }
    }
}
