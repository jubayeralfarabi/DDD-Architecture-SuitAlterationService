// <copyright file="CoreServiceBuilder.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Extensions
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>Service Builder.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Extensions.ICoreServiceBuilder" />
    public class CoreServiceBuilder : ICoreServiceBuilder
    {
        public IServiceCollection Services { get; }

        public CoreServiceBuilder(IServiceCollection services)
        {
            this.Services = services ?? throw new ArgumentNullException(nameof(services));
        }
    }
}
