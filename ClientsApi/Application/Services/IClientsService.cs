using ClientsApi.Application.Dtos;

namespace ClientsApi.Application.Services
{
    public interface IClientsService
    {
        Task<List<ClientDto>> GetClients();
        Task<ClientDto?> GetClient(int clientId);
        Task<ClientDto> CreateClient(CreateClientDto dto);
        Task<ClientDto> UpdateClient(int clientId, UpdateClientDto dto);
        Task DeleteClient(int clientId);
    }
}