using SuitSupply.AlterationService.Integration.AzureFunc;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using SuitSupply.Platform.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace SuitSupply.AlterationService.Integration.AzureFunc
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddApplicationInsightsTelemetry();
            builder.Services.AddCore();
        }
    }
}
