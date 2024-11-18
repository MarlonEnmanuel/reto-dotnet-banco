using AccountsApi.Application.Dtos;
using AccountsApi.Infrastructure.Interfaces;
using Shared.Exceptions;
using Shared.Enums;
using AccountsApi.Domain;
using AccountsApi.Application.Interfaces;

namespace AccountsApi.Application.Services
{
    public class ReportsService(IUnitOfWork unitOfWork) : IReportsService
    {
        public async Task<List<ReportDetailDto>> GetReport(ReportQueryDto query)
        {
            if (query.ClientId == null)
                throw new BadRequestException("El cliente es requerido");

            if (query.StartDate != null &&
                query.EndDate != null &&
                query.StartDate > query.EndDate)
                throw new BadRequestException("Rango de fechas incorrecto");


            var client = await unitOfWork.ClientsRepository.GetById(query.ClientId.Value) ??
                throw new BadRequestException("Cliente no encontrado");

            var movements = await unitOfWork.MovementsRepository
                                            .Search(m => m.Account.ClientId == query.ClientId &&
                                                        (query.StartDate == null || m.DateTime >= query.StartDate) &&
                                                        (query.EndDate == null || m.DateTime <= query.EndDate));

            return movements.OrderBy(m => m.Account.Number)
                            .ThenBy(m => m.DateTime)
                            .Select(m => ToReportDetailDto(client, m))
                            .ToList();
        }

        private ReportDetailDto ToReportDetailDto(Client client, Movement movement)
        {
            return new ReportDetailDto
            {
                Date = movement.DateTime.ToString("yyyy/MM/dd HH:mm:ss"),
                ClientName = client.Name,
                AccountNumber = movement.Account.Number,
                AccountType = movement.Account.Type.GetDescription(),
                Status = movement.Account.Status,
                MovementId = movement.Id,
                InitialBalance = movement.Balance - movement.Amount,
                Amount = movement.Amount,
                AvailableBalance = movement.Balance,
                Detail = movement.Description,
            };
        }
    }
}
