using ClientsApi;
using ClientsApi.Infrastructure.Controllers;
using ClientsApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DB Context with SQL Server
builder.Services.AddDbContext<ClientsContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ClientsDb") ??
        throw new InvalidOperationException("Connection string 'ClientsDb' not found");
    options.UseSqlServer(connectionString);
});

// Configure app dependencies
builder.Services.AddAppServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configure app routes
app.MapClientRoutes();

app.Run();
