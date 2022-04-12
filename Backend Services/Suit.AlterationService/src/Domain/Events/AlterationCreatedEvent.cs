namespace Suit.AlterationService.Domain.Events
{
    using System;
    using Suit.AlterationService.Domain.ValueObjects;
    using Suit.AlterationService.Domain.Entities;
    using Suit.Platform.Infrastructure.Core.Domain;

    /// <summary>Event for Alteration Creation.</summary>
    public class AlterationCreatedEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlterationCreatedEvent"/> class.
        /// </summary>
        public AlterationCreatedEvent(Guid alterationId, AlterationDetails[] alterationDetails, AlterationStatusEnum status)
        {
            this.AlterationDetails = alterationDetails;
            this.AlterationId = alterationId;
            this.Status = status;
        }

        public Guid AlterationId { get; private set; }

        public AlterationDetails[] AlterationDetails { get; private set; }

        public AlterationStatusEnum Status { get; private set; }
    }
}
