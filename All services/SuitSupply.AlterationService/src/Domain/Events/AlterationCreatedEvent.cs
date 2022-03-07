namespace SuitSupply.AlterationService.Domain.Events
{
    using System;
    using SuitSupply.AlterationService.Domain.ValueObjects;
    using SuitSupply.Platform.Infrastructure.Core.Domain;

    /// <summary>Event for Alteration Creation.</summary>
    public class AlterationCreatedEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlterationCreatedEvent"/> class.
        /// </summary>
        public AlterationCreatedEvent(Guid alterationId, AlterationDetails[] alterationDetails, Guid coorelationId)
        {
            this.AlterationDetails = alterationDetails;
            this.AlterationId = alterationId;
            this.CorrelationId = coorelationId;
        }

        public Guid AlterationId { get; private set; }

        public AlterationDetails[] AlterationDetails { get; private set; }
    }
}
