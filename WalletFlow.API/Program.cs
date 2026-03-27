using Microsoft.EntityFrameworkCore;
using WalletFlow.Infrastructure.Context;
using WalletFlow.Application.Interfaces;
using WalletFlow.Application.Services;
using WalletFlow.Domain.Repositories;
using WalletFlow.Domain.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar o Entity Framework com PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WalletFlowContext>(options =>
    options.UseNpgsql(connectionString));

// 2. Registrar os Repositórios (Infra -> Domain)
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

// 3. Registrar os Serviços de Aplicação (Application)
builder.Services.AddScoped<ITransferService, TransferService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();