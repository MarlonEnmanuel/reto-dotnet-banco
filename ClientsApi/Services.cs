using ClientsApi.Application.Services;
using ClientsApi.Domain;
using ClientsApi.Domain.Validators;
using ClientsApi.Infrastructure.Repositories;
using FluentValidation;

namespace ClientsApi
{
    public static class Services
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IClientsRepository, DbClientsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IClientsMapper, ClientsMapper>();
            services.AddScoped<IClientsService, ClientsService>();
            services.AddScoped<IValidator<Client>, ClientValidator>();
        }
    }
}
