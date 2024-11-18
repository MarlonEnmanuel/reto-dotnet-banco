using AccountsApi.Infrastructure.Database;
using AccountsApi.Infrastructure.Interfaces;

namespace ClientsApi.Infrastructure.Repositories
{
    public class UnitOfWork(AccountsContext context,
                            IAccountsRepository accountsRepository,
                            IMovementsRepository movementsRepository,
                            IClientsRepository clientsRepository) : IUnitOfWork
    {
        public IAccountsRepository AccountsRepository { get; } = accountsRepository;
        public IMovementsRepository MovementsRepository { get; } = movementsRepository;
        public IClientsRepository ClientsRepository { get; } = clientsRepository;


        public async Task Save()
            => await context.SaveChangesAsync();

        public void Dispose()
            => context.Dispose();
    }
}
