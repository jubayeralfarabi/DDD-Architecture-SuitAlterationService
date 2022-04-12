namespace Suit.AlterationService.Read.EventHandlers
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Suit.AlterationService.Domain.Events;
    using Suit.AlterationService.Infrastructure.ServiceBus;
    using Suit.AlterationService.Integration.Events;
    using Suit.Platform.Infrastructure.Core.Events;

    public class AlterationFinishedEventHandler : IEventHandlerAsync<AlterationFinishedEvent>
    {
        private readonly ILogger<AlterationFinishedEventHandler> logger;
        private readonly IBusMessagePublisher busMessagePublisher;

        public AlterationFinishedEventHandler(
            IBusMessagePublisher busMessagePublisher,
            ILogger<AlterationFinishedEventHandler> logger)
        {
            this.logger = logger;
            this.busMessagePublisher = busMessagePublisher;
        }

        public async Task HandleAsync(AlterationFinishedEvent @event)
        {
            this.logger.LogInformation($"AlterationFinishedEventHandler START with ShopCreatedEvent: {JsonConvert.SerializeObject(@event)}");

            await this.busMessagePublisher.SendAsync(new AlterationFinishedIntegrationEvent
            {
                CustomerId = @event.CustomerId,
                AlterationId = @event.AlterationId,
            });

            this.logger.LogInformation("AlterationFinishedEventHandler DONE");
        }
    }
}
