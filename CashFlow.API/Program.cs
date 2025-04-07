using CashFlow.API.Middleware;
using CashFlow.Core.Interfaces;
using CashFlow.Core.Services;
using CashFlow.Domain.Interfaces;
using CashFlow.Infrastructure.Data;
using CashFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CashFlowDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IEntryRepository, EntryRepository>();
builder.Services.AddScoped<ICounterpartyRepository, CounterpartyRepository>();
builder.Services.AddScoped<IConsolidationRepository, ConsolidationRepository>();

builder.Services.AddScoped<IConsolidationService, ConsolidationService>();
builder.Services.AddScoped<IEntryService, EntryService>();
builder.Services.AddScoped<ICounterpartyService, CounterpartyService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
