namespace ContactInfoCRUD.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
    }
}
