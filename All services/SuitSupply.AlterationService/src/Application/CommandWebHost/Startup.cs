// <copyright file="Startup.cs" company="SuitSupply">
// Copyright SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.AlterationService.Application.CommandWebHost
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SuitSupply.Platform.Infrastructure.Host.WebApi.Extensions;
    using SuitSupply.Platform.Infrastructure.Swagger.Extensions;
    using SuitSupply.Platform.Infrastructure.Core.Extensions;
    using SuitSupply.Platform.Infrastructure.Extensions;

    /// <summary>
    /// Startup class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">IConfiguration instance.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddJwtBearer(this.configuration);

            services
                .AddHttpComponents();
            //.AddEndpointSecurityPolicies();

            ICoreServiceBuilder builder = services.AddCore()
                .AddDefaultDomainStore()
                .AddDefaultBusProvider();

            services.AddSwaggerAuthorized(this.Configuration);
            //services.AddServiceBusProvider(this.configuration);
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            applicationBuilder.UseHttpPipeline(true);
            applicationBuilder.UseSwaggerLocal();
        }
    }
}
