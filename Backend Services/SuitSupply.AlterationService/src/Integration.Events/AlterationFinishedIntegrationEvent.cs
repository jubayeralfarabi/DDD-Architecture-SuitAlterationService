using SuitSupply.Platform.Infrastructure.Core.Events;

namespace SuitSupply.AlterationService.Integration.Events
{
    public class AlterationFinishedIntegrationEvent
    {
        public Guid AlterationId { get; set; }

        public string CustomerId { get; set; }
    }
}