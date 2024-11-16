using ClientsApi.Application.Dtos;
using ClientsApi.Domain;

namespace ClientsApi.Application.Services
{
    public class ClientsMapper : IClientsMapper
    {
        public ClientDto ToClientDto(Client client) => new()
        {
            Id = client.Id,
            Name = client.Name,
            Gender = client.Gender,
            Age = client.Age,
            Identification = client.Identification,
            Address = client.Address,
            PhoneNumber = client.PhoneNumber,
            Status = client.Status,
        };

        public Client ToClient(CreateClientDto dto) => new()
        {
            Name = dto.Name,
            Gender = dto.Gender,
            Age = dto.Age,
            Identification = dto.Identification,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            Password = dto.Password,
            Status = dto.Status,
        };

        public Client ToClient(UpdateClientDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Gender = dto.Gender,
            Age = dto.Age,
            Identification = dto.Identification,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber,
            Password = dto.Password,
            Status = dto.Status,
        };
    }
}
