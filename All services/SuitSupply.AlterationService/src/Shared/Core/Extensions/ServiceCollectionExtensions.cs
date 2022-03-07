﻿// <copyright file="ServiceCollectionExtensions.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Extensions
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using SuitSupply.Platform.Infrastructure.Core;
    using SuitSupply.Platform.Infrastructure.Core.Bus;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Dependencies;
    using SuitSupply.Platform.Infrastructure.Core.Domain;
    using SuitSupply.Platform.Infrastructure.Core.Events;
    using SuitSupply.Platform.Infrastructure.Core.Extensions;
    using SuitSupply.Platform.Infrastructure.Core.Queries;

    /// <summary>Service collection extensions.</summary>
    public static class ServiceCollectionExtensions
    {
        public static ICoreServiceBuilder AddCore(this IServiceCollection services, params Type[] types)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IResolver, Resolver>();
            services.AddScoped<IHandlerResolver, HandlerResolver>();
            services.AddScoped<IDispatcher, Dispatcher>();

            services.AddScoped<IDomainEventProcessor, DomainEventProcessor>();
            services.AddScoped(typeof(IDomainRepository<>), typeof(DomainRepository<>));
            services.AddSingleton<IBusMessageDispatcher, BusMessageDispatcher>();
            services.AddScoped<ICommandSender, CommandSender>();
            services.AddScoped<IEventPublisher, EventPublisher>();
            services.AddScoped<IQueryProcessor, QueryProcessor>();

            return new CoreServiceBuilder(services);
        }

        public static ICoreServiceBuilder AddDefaultBusProvider(this ICoreServiceBuilder builder)
        {
            builder.Services.AddScoped<IBusProvider, DefaultBusProvider>();
            return builder;
        }

        public static ICoreServiceBuilder AddDefaultDomainStore(this ICoreServiceBuilder builder)
        {
            builder.Services.AddScoped<IDomainStore, DefaultDomainStore>();
            return builder;
        }
    }
}