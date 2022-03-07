// <copyright file="Resolver.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Dependencies
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using SuitSupply.Platform.Infrastructure.Core.Events;

    /// <summary>Generic resolver to resolve passed template.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Dependencies.IResolver" />
    public class Resolver : IResolver
    {
        private readonly IServiceProvider serviceProvider;

        public Resolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <summary>Resolves this instance.</summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <returns>T instance.</returns>
        public T Resolve<T>()
        {
            return this.serviceProvider.GetService<T>();
        }

        /// <summary>Resolves all.</summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <returns>Type list.</returns>
        public IEnumerable<T> ResolveAll<T>()
        {
            try
            {
                var services = this.serviceProvider.GetServices(typeof(IEventHandlerAsync<>));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return this.serviceProvider.GetServices<T>();
        }

        /// <summary>Resolves the specified type.</summary>
        /// <param name="type">The type.</param>
        /// <returns>object.</returns>
        public object Resolve(Type type)
        {
            return this.serviceProvider.GetService(type);
        }

        /// <summary>Resolves all.</summary>
        /// <param name="type">The type.</param>
        /// <returns>object list.</returns>
        public IEnumerable<object> ResolveAll(Type type)
        {
            return this.serviceProvider.GetServices(type);
        }
    }
}
