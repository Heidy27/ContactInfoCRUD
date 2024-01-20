using ContactInfoCRUD.Domain.Interfaces;
using ContactInfoCRUD.Infrastructure.Data;
using System.Threading.Tasks;

namespace ContactInfoCRUD.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactInfoDbContext _context;

        public UnitOfWork(ContactInfoDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
