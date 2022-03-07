// <copyright file="ICoreServiceBuilder.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>Core Service Builder.</summary>
    public interface ICoreServiceBuilder
    {
        IServiceCollection Services { get; }
    }
}
