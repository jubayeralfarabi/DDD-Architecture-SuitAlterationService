namespace SuitSupply.Platform.Infrastructure.Core.Events
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    public class EventPublisher : IEventPublisher
    {
        private readonly IServiceProvider serviceProvider;

        public EventPublisher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task PublishAsync<TEvent>(TEvent @event)
            where TEvent : IEvent
        {
            if (@event == null)
            {
                throw new ArgumentNullException(nameof(@event));
            }

            var handler = (IEventHandlerAsync<TEvent>) this.serviceProvider.GetService<IEventHandlerAsync<TEvent>>();
            if(handler!=null)await handler.HandleAsync(@event);
        }
    }
}
