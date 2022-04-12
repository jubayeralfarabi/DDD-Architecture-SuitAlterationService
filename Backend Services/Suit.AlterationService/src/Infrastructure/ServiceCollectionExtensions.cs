namespace Suit.Platform.Infrastructure.Extensions
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Suit.AlterationService.Domain;
    using Suit.AlterationService.Infrastructure.ServiceBus;
    using Suit.Infrastructure.Repository.RDBRepository;
    using Suit.Infrastructure.Repository.RDBRepository.DbContexts;
    using Suit.Platform.Infrastructure.Core;
    using Suit.Platform.Infrastructure.Core.Commands;
    using Suit.Platform.Infrastructure.Core.Domain;
    using Suit.Platform.Infrastructure.Core.Events;

    public static class ServiceCollectionExtensions
    {
        public static void AddCore(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddScoped<IDispatcher, Dispatcher>();

            services.AddScoped<ICommandSender, CommandSender>();
            services.AddScoped<IEventPublisher, EventPublisher>();

            services.AddScoped<IBusMessagePublisher, BusMessagePublisher>();

            services.AddScoped<IReadWriteRepository, ReadWriteRepository<DbContext>>();
            services.AddScoped<IReadOnlyRepository, ReadOnlyRepository<DbContext>>();

            services.AddScoped<DbContext, AlterationDbContext>();
            services.AddScoped<IAggregateRepository<AlterationAggregate>, AggregateRepository<AlterationAggregate>>();
        }
    }
}
