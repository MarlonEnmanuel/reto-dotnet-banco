using ClientsApi.Infrastructure.Database;

namespace ClientsApi.Infrastructure.Repositories
{
    public class UnitOfWork(ClientsContext context,
                            IClientsRepository clientsRepository) : IUnitOfWork
    {
        public IClientsRepository ClientsRepository { get; } = clientsRepository;

        public async Task Save()
            => await context.SaveChangesAsync();

        public void Dispose()
            => context.Dispose();
    }
}
