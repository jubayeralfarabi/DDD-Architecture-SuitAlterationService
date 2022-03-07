namespace SuitSupply.AlterationService.Read.EventHandlers
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SuitSupply.AlterationService.Domain.Events;
    using SuitSupply.Platform.Infrastructure.Core.Events;

    /// <summary>
    /// Responsible to handle AlterationStartedProcessingEvent.
    /// </summary>
    public class AlterationStartedProcessingEventHandler : IEventHandlerAsync<AlterationStartedProcessingEvent>
    {
        private readonly ILogger<AlterationStartedProcessingEventHandler> logger;

        /// <summary>Initializes a new instance of the <see cref="AlterationStartedProcessingEventHandler" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public AlterationStartedProcessingEventHandler(
            ILogger<AlterationStartedProcessingEventHandler> logger)
        {
            this.logger = logger;
        }

        /// <summary>Handles the asynchronous.</summary>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        public async Task HandleAsync(AlterationStartedProcessingEvent @event)
        {
            this.logger.LogInformation($"AlterationStartedProcessingEventHandler START with ShopCreatedEvent: {JsonConvert.SerializeObject(@event)}");

            this.logger.LogDebug("ViewAlterationList created");

            this.logger.LogInformation("AlterationStartedProcessingEventHandler DONE");
        }
    }
}
