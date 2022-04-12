using Suit.AlterationService.Integration.AzureFunc;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Suit.Platform.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Suit.Infrastructure.Repository.RDBRepository.DbContexts;
using Microsoft.EntityFrameworkCore;
using Suit.AlterationService.Application.Commands;
using Suit.AlterationService.Application.CommandHandlers;
using Suit.Platform.Infrastructure.Core.Commands;
using Suit.Platform.Infrastructure.Core.Domain;
using Suit.AlterationService.Domain;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Suit.AlterationService.Integration.AzureFunc
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
