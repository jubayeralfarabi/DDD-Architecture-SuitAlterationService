using SuitSupply.AlterationService.Integration.AzureFunc;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using SuitSupply.Platform.Infrastructure.Extensions;

[assembly: FunctionsStartup(typeof(Startup))]

namespace SuitSupply.AlterationService.Integration.AzureFunc
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddCore();
        }
    }
}
