using Microsoft.EntityFrameworkCore;
using SuitSupply.Infrastructure.Repository.RDBRepository;
using SuitSupply.Infrastructure.Repository.RDBRepository.DbContexts;
using SuitSupply.AlterationService.Infrastructure.ServiceBus;
using SuitSupply.Platform.Infrastructure.Extensions;
using SuitSupply.Platform.Infrastructure.Core.Domain;
using SuitSupply.AlterationService.Domain;
using SuitSupply.AlterationService.Application.CommandHandlers;
using SuitSupply.AlterationService.Application.Commands;
using SuitSupply.Platform.Infrastructure.Core.Commands;
using SuitSupply.AlterationService.Domain.Events;
using SuitSupply.Platform.Infrastructure.Core.Events;
using SuitSupply.AlterationService.Read.EventHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCore();
builder.Services.AddApplicationInsightsTelemetry();


IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
builder.Services.Configure<BusSettings>(configuration.GetSection("BusSettings"));

builder.Services.AddDbContext<AlterationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AlterationDbContext")));
builder.Services.AddScoped<DbContext, AlterationDbContext>();
builder.Services.AddScoped<IAggregateRepository<AlterationAggregate>, AggregateRepository<AlterationAggregate>>();

builder.Services.AddScoped<ICommandHandlerAsync<CreateAlterationCommand>, CreateAlterationCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<CompletePaymentCommand>, CompletePaymentCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<StartProcessingAlterationCommand>, StartProcessingAlterationCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<FinishAlterationCommand>, FinishAlterationCommandHandler>();

builder.Services.AddScoped<IEventHandlerAsync<AlterationFinishedEvent>, AlterationFinishedEventHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
