namespace SuitSupply.AlterationService.Read.EventHandlers
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SuitSupply.AlterationService.Domain.Events;
    using SuitSupply.Platform.Infrastructure.Core.Events;

    /// <summary>
    /// Responsible to handle AlterationPaymentDoneEvent.
    /// </summary>
    public class AlterationPaymentDoneEventHandler : IEventHandlerAsync<AlterationPaymentDoneEvent>
    {
        private readonly ILogger<AlterationPaymentDoneEventHandler> logger;

        /// <summary>Initializes a new instance of the <see cref="AlterationPaymentDoneEventHandler" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public AlterationPaymentDoneEventHandler(
            ILogger<AlterationPaymentDoneEventHandler> logger)
        {
            this.logger = logger;
        }

        /// <summary>Handles the asynchronous.</summary>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        public async Task HandleAsync(AlterationPaymentDoneEvent @event)
        {
            this.logger.LogInformation($"AlterationPaymentDoneEventHandler START with ShopCreatedEvent: {JsonConvert.SerializeObject(@event)}");

            this.logger.LogDebug("ViewAlterationList created");

            this.logger.LogInformation("AlterationPaymentDoneEventHandler DONE");
        }
    }
}
