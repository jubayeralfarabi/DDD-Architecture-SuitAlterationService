namespace Suit.AlterationService.Domain.Events
{
    using System;
    using Suit.AlterationService.Domain.ValueObjects;
    using Suit.Platform.Infrastructure.Core.Domain;

    /// <summary>Event for Alteration Creation.</summary>
    public class AlterationPaymentDoneEvent : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlterationCreatedEvent"/> class.
        /// </summary>
        public AlterationPaymentDoneEvent(Guid alterationId, AlterationStatusEnum status)
        {
            this.AlterationId = alterationId;
            this.Status = status;
        }

        public Guid AlterationId { get; private set; }

        public AlterationStatusEnum Status { get; private set; }
    }
}
