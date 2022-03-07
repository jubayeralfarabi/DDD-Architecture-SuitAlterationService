// <copyright file="DomainRepository.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>Generic domain repository.</summary>
    /// <typeparam name="T">Generic type.</typeparam>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Domain.IDomainRepository{T}" />
    public class DomainRepository<T> : IDomainRepository<T>
        where T : IAggregateRoot
    {
        private readonly IDomainStore domainStore;

        public DomainRepository(IDomainStore domainStore)
        {
            this.domainStore = domainStore;
        }

        /// <summary>Saves the asynchronous.</summary>
        /// <param name="aggregate">The aggregate.</param>
        /// <returns>Task.</returns>
        public Task SaveAsync(T aggregate)
        {
            return this.domainStore.SaveAsync(aggregate.Id, aggregate.Events);
        }

        /// <summary>Saves the specified aggregate.</summary>
        /// <param name="aggregate">The aggregate.</param>
        public void Save(T aggregate)
        {
            this.domainStore.Save(aggregate.Id, aggregate.Events);
        }

        /// <summary>Gets the by identifier asynchronous.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Type.</returns>
        public async Task<T> GetByIdAsync(Guid id)
        {
            var events = await this.domainStore.GetEventsAsync(id);
            var domainEvents = events as DomainEvent[] ?? events.ToArray();
            if (!domainEvents.Any())
            {
                return default;
            }

            var aggregate = Activator.CreateInstance<T>();
            aggregate.LoadsFromHistory(domainEvents);
            return aggregate;
        }

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Type.</returns>
        public T GetById(Guid id)
        {
            var events = this.domainStore.GetEvents(id);
            var domainEvents = events as DomainEvent[] ?? events.ToArray();
            if (!domainEvents.Any())
            {
                return default;
            }

            var aggregate = Activator.CreateInstance<T>();
            aggregate.LoadsFromHistory(domainEvents);
            return aggregate;
        }
    }
}
