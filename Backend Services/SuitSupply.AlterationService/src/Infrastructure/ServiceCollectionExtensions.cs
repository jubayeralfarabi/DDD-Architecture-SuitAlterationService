namespace SuitSupply.Platform.Infrastructure.Extensions
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SuitSupply.AlterationService.Domain;
    using SuitSupply.AlterationService.Infrastructure.ServiceBus;
    using SuitSupply.Infrastructure.Repository.RDBRepository;
    using SuitSupply.Infrastructure.Repository.RDBRepository.DbContexts;
    using SuitSupply.Platform.Infrastructure.Core;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Domain;
    using SuitSupply.Platform.Infrastructure.Core.Events;

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
