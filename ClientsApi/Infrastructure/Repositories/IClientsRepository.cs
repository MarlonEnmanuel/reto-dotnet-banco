﻿using ClientsApi.Domain;

namespace ClientsApi.Infrastructure.Repositories
{
    public interface IClientsRepository
    {
        Task<List<Client>> GetAll();
        Task<Client?> GetById(int clientId);
        Task<bool> Exists(int clientId);
        Task Create(Client client);
        Task Update(Client client);
        Task<bool> Delete(int clientId);
    }
}