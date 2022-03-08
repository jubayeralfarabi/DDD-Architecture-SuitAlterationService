using SuitSupply.AlterationService.Integration.AzureFunc;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using SuitSupply.Platform.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SuitSupply.Infrastructure.Repository.RDBRepository.DbContexts;
using Microsoft.EntityFrameworkCore;
using SuitSupply.AlterationService.Application.Commands;
using SuitSupply.AlterationService.Application.CommandHandlers;
using SuitSupply.Platform.Infrastructure.Core.Commands;
using SuitSupply.Platform.Infrastructure.Core.Domain;
using SuitSupply.AlterationService.Domain;

[assembly: FunctionsStartup(typeof(Startup))]

namespace SuitSupply.AlterationService.Integration.AzureFunc
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddApplicationInsightsTelemetry();
            builder.Services.AddCore();

            builder.Services.AddDbContext<AlterationDbContext>(options => options.UseSqlServer(_configuration.GetValue<string>("AlterationDbContext")));
            builder.Services.AddScoped<DbContext, AlterationDbContext>();
            builder.Services.AddScoped<IAggregateRepository<AlterationAggregate>, AggregateRepository<AlterationAggregate>>();

            builder.Services.AddScoped<ICommandHandlerAsync<CompletePaymentCommand>, CompletePaymentCommandHandler>();
        }
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            var context = builder.GetContext();
            builder.ConfigurationBuilder
                .SetBasePath(context.ApplicationRootPath)
                .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            _configuration = builder.ConfigurationBuilder.Build();
        }

        private IConfiguration _configuration;
    }
}
