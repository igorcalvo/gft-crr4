using CashFlow.API.Middleware;
using CashFlow.Core.Interfaces;
using CashFlow.Core.Services;
using CashFlow.Domain.Interfaces;
using CashFlow.Infrastructure.Data;
using CashFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.Storage.SQLite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();

builder.Services.AddDbContext<CashFlowDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IEntryRepository, EntryRepository>();
builder.Services.AddScoped<ICounterpartyRepository, CounterpartyRepository>();
builder.Services.AddScoped<IConsolidationRepository, ConsolidationRepository>();

builder.Services.AddScoped<IConsolidationService, ConsolidationService>();
builder.Services.AddScoped<IEntryService, EntryService>();
builder.Services.AddScoped<ICounterpartyService, CounterpartyService>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddHangfire(configuration =>
{
    configuration.UseSimpleAssemblyNameTypeSerializer()
                 .UseRecommendedSerializerSettings()
                 .UseSQLiteStorage(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddHangfireServer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseHangfireDashboard("/hangfire");

RecurringJob.AddOrUpdate<ConsolidationService>(
    "daily-consolidation",
    service => service.AddConsolidation(),
    Cron.Daily);

app.Run();
