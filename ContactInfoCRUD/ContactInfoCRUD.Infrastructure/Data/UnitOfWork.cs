using ContactInfoCRUD.Domain.Interfaces;
using ContactInfoCRUD.Infrastructure.Data;

namespace ContactInfoCRUD.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactInfoDbContext _context;

        public UnitOfWork(ContactInfoDbContext context)
        {
            _context = context;
        }

        // Guarda los cambios en la base de datos de manera asíncrona
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Libera los recursos utilizados por el contexto de la base de datos
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
