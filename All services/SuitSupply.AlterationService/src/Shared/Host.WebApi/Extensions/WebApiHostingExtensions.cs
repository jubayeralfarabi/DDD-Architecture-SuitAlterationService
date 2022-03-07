// <copyright file="WebApiHostingExtensions.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Host.WebApi.Extensions
{
    using System;
    using System.Text.Json.Serialization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using SuitSupply.Platform.Infrastructure.Host.WebApi.Middlewares;

    public static class WebApiHostingExtensions
    {
        public static IApplicationBuilder UseHttpPipeline(
            this IApplicationBuilder applicationBuilder,
            bool enableAuthorization = false)
        {
            applicationBuilder.UseRouting();

            applicationBuilder.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            applicationBuilder.UseCors((corsPolicyBuilder) =>
                   corsPolicyBuilder
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((string origin) => true)
                   .AllowCredentials()
                   .SetPreflightMaxAge(TimeSpan.FromDays(365)));

            if (enableAuthorization)
            {
                //applicationBuilder.UseAuthentication();
                //applicationBuilder.UseAuthorization();
            }

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "Default",
                   pattern: "{controller}/{action}/{id?}");
                endpoints.MapHealthChecks("/health");
            });

            return applicationBuilder;
        }

        public static IMvcCoreBuilder AddHttpComponents(this IServiceCollection services)
        {
            services.AddRouting();

            services.AddHealthChecks();

            return services.AddMvcCore((options) =>
            {
            })
            .AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
                jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            })
            .AddNewtonsoftJson()
            .AddCors();
        }
    }
}
