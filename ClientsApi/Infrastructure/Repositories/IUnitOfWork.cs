namespace ClientsApi.Infrastructure.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IClientsRepository ClientsRepository { get; }
        Task Save();
    }
}