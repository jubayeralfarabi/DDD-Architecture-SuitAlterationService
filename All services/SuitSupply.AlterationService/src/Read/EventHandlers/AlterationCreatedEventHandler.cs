namespace SuitSupply.AlterationService.Read.EventHandlers
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Shohoz.DeliveryPlatform.Shop.Read.ViewModels;
    using SuitSupply.AlterationService.Domain.Events;
    using SuitSupply.Platform.Infrastructure.Core.Events;

    /// <summary>
    /// Responsible to handle AlterationCreatedEvent.
    /// </summary>
    public class AlterationCreatedEventHandler : IEventHandlerAsync<AlterationCreatedEvent>
    {
        private readonly ILogger<AlterationCreatedEventHandler> logger;

        /// <summary>Initializes a new instance of the <see cref="AlterationCreatedEventHandler" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public AlterationCreatedEventHandler(
            ILogger<AlterationCreatedEventHandler> logger)
        {
            this.logger = logger;
        }

        /// <summary>Handles the asynchronous.</summary>
        /// <param name="event">The event.</param>
        /// <returns>Task.</returns>
        public async Task HandleAsync(AlterationCreatedEvent @event)
        {
            this.logger.LogInformation($"AlterationCreatedEventHandler START with ShopCreatedEvent: {JsonConvert.SerializeObject(@event)}");

            AlterationList alterationView = new AlterationList()
            {
                Status = @event.Status,
                AlterationDetails = @event.AlterationDetails,
            };
            alterationView.SetId(@event.AlterationId);
            alterationView.RolesAllowedToRead = new string[] { "admin", "anonymous" };
            alterationView.SetDefaultValue(@event.UserContext);
            alterationView.SetDefaultRowLevelSecurity(@event.UserContext);

            this.logger.LogDebug("ViewAlterationList created");

            this.logger.LogInformation("AlterationCreatedEventHandler DONE");
        }
    }
}
