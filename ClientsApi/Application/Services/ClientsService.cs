﻿using ClientsApi.Application.Dtos;
using ClientsApi.Infrastructure.Repositories;
using Shared.Exceptions;

namespace ClientsApi.Application.Services
{
    public class ClientsService(IUnitOfWork unitOfWork, IClientsMapper mapper) : IClientsService
    {
        public async Task<List<ClientDto>> GetClients()
        {
            var clients = await unitOfWork.ClientsRepository.GetAll();
            return clients.Select(mapper.ToClientDto).ToList();
        }

        public async Task<ClientDto?> GetClient(int clientId)
        {
            var client = await unitOfWork.ClientsRepository.GetById(clientId) ??
                throw new NotFoundException($"El cliente con id '{clientId}' no existe");

            return mapper.ToClientDto(client);
        }

        public async Task<ClientDto> CreateClient(CreateClientDto dto)
        {
            // TODO: validate dto
            // TODO: validate identification exists

            var client = mapper.ToClient(dto);
            await unitOfWork.ClientsRepository.Create(client);
            await unitOfWork.Save();

            return mapper.ToClientDto(client);
        }

        public async Task<ClientDto> UpdateClient(int clientId, UpdateClientDto dto)
        {
            if (clientId != dto.Id)
                throw new ValidationException("El id del cliente no coincide con la url");

            // TODO: validate dto
            // TODO: validate identification exists

            var exists = await unitOfWork.ClientsRepository.Exists(clientId);
            if (!exists)
                throw new NotFoundException($"El cliente con id '{clientId}' no existe");

            var client = mapper.ToClient(dto);
            await unitOfWork.ClientsRepository.Update(client);
            await unitOfWork.Save();

            return mapper.ToClientDto(client);
        }

        public async Task DeleteClient(int clientId)
        {
            var exists = await unitOfWork.ClientsRepository.Exists(clientId);
            if (!exists)
                throw new NotFoundException($"El cliente con id '{clientId}' no existe");

            await unitOfWork.ClientsRepository.Delete(clientId);
            await unitOfWork.Save();
        }
    }
}