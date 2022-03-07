// <copyright file="SwaggerAuthorizeExtensions.cs" company="SuitSupply">
// Copyright © 2015-2021 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Swagger.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Builder;

    [ExcludeFromCodeCoverage]
    public static class SwaggerBuilderExtension
    {
        public static IApplicationBuilder UseSwaggerLocal(this IApplicationBuilder builder)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            builder.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });

            return builder;
        }
    }
}
