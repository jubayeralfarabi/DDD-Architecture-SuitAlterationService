namespace SuitSupply.AlterationService.Read.EventHandlers
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SuitSupply.AlterationService.Domain.Events;
    using SuitSupply.Platform.Infrastructure.Core.Events;

    /// <summary>
    /// Responsible to handle AlterationFinishedEvent.
    /// </summary>
    public class AlterationFinishedEventHandler : IEventHandlerAsync<AlterationFinishedEvent>
    {
        private readonly ILogger<AlterationFinishedEventHandler> logger;

        /// <summary>Initializes a new instance of the <see cref="AlterationFinishedEventHandler" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public AlterationFinishedEventHandler(
            ILogger<AlterationFinishedEventHandler> logger)
        {
            this.logger = logger;
        }

        /// <summary>Handles the asynchronous.</summary>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        public async Task HandleAsync(AlterationFinishedEvent @event)
        {
            this.logger.LogInformation($"AlterationFinishedEventHandler START with ShopCreatedEvent: {JsonConvert.SerializeObject(@event)}");

            this.logger.LogDebug("ViewAlterationList created");

            this.logger.LogInformation("AlterationFinishedEventHandler DONE");
        }
    }
}
