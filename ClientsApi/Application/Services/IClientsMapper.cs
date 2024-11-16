using ClientsApi.Application.Dtos;
using ClientsApi.Domain;

namespace ClientsApi.Application.Services
{
    public interface IClientsMapper
    {
        ClientDto ToClientDto(Client client);
        Client ToClient(CreateClientDto dto);
        Client ToClient(UpdateClientDto dto);
    }
}