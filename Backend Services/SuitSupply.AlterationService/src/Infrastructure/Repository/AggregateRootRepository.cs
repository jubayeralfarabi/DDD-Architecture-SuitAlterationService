namespace Suit.Platform.Infrastructure.Core.Domain
{
    using Suit.Infrastructure.Repository.RDBRepository;
    using Suit.Platform.Infrastructure.Core.Events;
    using Suit.Platform.Infrastructure.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class AggregateRepository<T> : IAggregateRepository<T>
        where T : AggregateRoot
    {
        private readonly IReadWriteRepository repository;
        private readonly IDispatcher dispatcher;

        public AggregateRepository(IReadWriteRepository repository, IDispatcher dispatcher)
        {
            this.repository = repository;
            this.dispatcher = dispatcher;
        }

        public async Task SaveAsync(T aggregate)
        {
            this.EnrichEvents(aggregate, aggregate.Events);

            if (aggregate.Events.Any(@event => @event is FailedToProcessEvent) == false)
            {
                aggregate.SetDefaultValue();

                this.repository.Create<T>(aggregate);
            }

            await this.PublishEventsAsync(aggregate.Events);
        }

        public async Task UpdateAsync(T aggregate)
        {
            this.EnrichEvents(aggregate, aggregate.Events);

            if (aggregate.Events.Any(@event => @event is FailedToProcessEvent) == false)
            {
                this.repository.Update<T>(aggregate);
            }

            await this.PublishEventsAsync(aggregate.Events);
        }


        public T GetById(Guid id)
        {
            return this.repository.GetById<T>(id);
        }

        private void EnrichEvents(AggregateRoot aggregateRoot, IReadOnlyCollection<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                domainEvent.TimeStamp = DateTime.UtcNow;
                domainEvent.Source = typeof(T).FullName;
            }
        }

        private async Task PublishEventsAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                await this.dispatcher.PublishAsync(domainEvent);
            }
        }
    }
}
