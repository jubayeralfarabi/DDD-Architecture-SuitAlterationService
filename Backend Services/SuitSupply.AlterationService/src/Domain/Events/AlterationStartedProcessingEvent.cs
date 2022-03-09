namespace SuitSupply.AlterationService.Domain.Events
{
    using System;
    using SuitSupply.AlterationService.Domain.ValueObjects;
    using SuitSupply.Platform.Infrastructure.Core.Domain;

    /// <summary>Event for Alteration Creation.</summary>
    public class AlterationStartedProcessingEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlterationCreatedEvent"/> class.
        /// </summary>
        public AlterationStartedProcessingEvent(Guid alterationId, AlterationStatusEnum status)
        {
            this.AlterationId = alterationId;
            this.Status = status;
        }

        public Guid AlterationId { get; private set; }

        public AlterationStatusEnum Status { get; private set; }
    }
}
