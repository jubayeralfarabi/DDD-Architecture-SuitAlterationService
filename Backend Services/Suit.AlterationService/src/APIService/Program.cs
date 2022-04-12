using Microsoft.EntityFrameworkCore;
using Suit.Infrastructure.Repository.RDBRepository;
using Suit.Infrastructure.Repository.RDBRepository.DbContexts;
using Suit.AlterationService.Infrastructure.ServiceBus;
using Suit.Platform.Infrastructure.Extensions;
using Suit.Platform.Infrastructure.Core.Domain;
using Suit.AlterationService.Domain;
using Suit.AlterationService.Application.CommandHandlers;
using Suit.AlterationService.Application.Commands;
using Suit.Platform.Infrastructure.Core.Commands;
using Suit.AlterationService.Domain.Events;
using Suit.Platform.Infrastructure.Core.Events;
using Suit.AlterationService.Read.EventHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry();


IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
builder.Services.Configure<BusSettings>(configuration.GetSection("BusSettings"));
builder.Services.AddDbContext<AlterationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AlterationDbContext")));
builder.Services.AddCore();

builder.Services.AddScoped<ICommandHandlerAsync<CreateAlterationCommand>, CreateAlterationCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<CompletePaymentCommand>, CompletePaymentCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<StartProcessingAlterationCommand>, StartProcessingAlterationCommandHandler>();
builder.Services.AddScoped<ICommandHandlerAsync<FinishAlterationCommand>, FinishAlterationCommandHandler>();

builder.Services.AddScoped<IEventHandlerAsync<AlterationFinishedEvent>, AlterationFinishedEventHandler>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
