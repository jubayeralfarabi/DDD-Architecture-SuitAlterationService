namespace SuitSupply.DeliveryPlatform.Shop.Domain.Aggregates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentValidation.Results;
    using SuitSupply.AlterationService.Domain.Aggregates;
    using SuitSupply.AlterationService.Domain.Events;
    using SuitSupply.AlterationService.Domain.ValueObjects;
    using SuitSupply.Platform.Infrastructure.Common.Security;
    using SuitSupply.Platform.Infrastructure.Core.Domain;
    using SuitSupply.Platform.Infrastructure.Core.Events;
    using SuitSupply.Platform.Infrastructure.Domain;

    /// <summary>AlterationAggregate.</summary>
    public class AlterationAggregate : AggregateRoot
    {
        public Guid AlterationId { get; private set; }

        public AlterationDetails[] AlterationDetails { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AlterationAggregate"/> class.
        /// </summary>
        public AlterationAggregate()
        {
        }

        /// <summary>
        /// Create a new shop record.
        /// </summary>
        /// <param name="dto">Create ShopDto.</param>
        public void CreateAlteration(Guid alterationId, AlterationDetails[] alterationDetails, Guid coorelationId, UserContext userContext, bool isBatchUpload = false)
        {
            List<EventMessage> errors = new List<EventMessage>() { };
            if (alterationId == Guid.Empty) errors.Add(new EventMessage(AlterationBusinessValidationCodes.PropertyIsNullEmpty, EventMessageType.Error, new object[] { nameof(alterationId), "Invalid alteration id."}));
            if (alterationDetails.Length == 0) errors.Add(new EventMessage(AlterationBusinessValidationCodes.ArrayMustHaveAnElement, EventMessageType.Error, new object[] { nameof(alterationDetails), "alteration details must have value." }));
            if (alterationDetails.Length > 0)
            {
                alterationDetails.ToList().ForEach(a =>
                {
                    if (a.AlterationValue < -5 || a.AlterationValue > 5)
                    {
                        errors.Add(new EventMessage(AlterationBusinessValidationCodes.InvalidAlterationValue, EventMessageType.Error, new object[] { nameof(alterationDetails), a.AlterationValue, "Has invalid alteration value. It should be between +/- 5." }));
                    }
                    if (!(a.AlterationName == AlterationTypeEnum.SleeveLeft.ToString()
                       || a.AlterationName == AlterationTypeEnum.SleeveRight.ToString()
                       || a.AlterationName == AlterationTypeEnum.TrouserLeft.ToString()
                       || a.AlterationName == AlterationTypeEnum.TrouserRight.ToString()))
                    {
                        errors.Add(new EventMessage(AlterationBusinessValidationCodes.InvalidAlterationType, EventMessageType.Error, new object[] { nameof(a.AlterationName), a.AlterationName, "Has invalid alteration type." }));
                    }
                });
            }

            if (errors.Count>0)
            {
                AlterationBusinessRuleViolationEvent ruleViolationEvent = new AlterationBusinessRuleViolationEvent(
                    alterationId.ToString(),
                    nameof(this.CreateAlteration),
                    alterationDetails,
                    errors.ToArray());

                this.AddEvent(ruleViolationEvent);
                return;
            }

            AlterationCreatedEvent alterationCreatedEvent = new AlterationCreatedEvent(alterationId, alterationDetails, coorelationId);

            this.SetUserContextOnEvent(alterationCreatedEvent, userContext);

            this.AddAndApplyEvent<AlterationAggregate>(alterationCreatedEvent);
        }

        private void SetUserContextOnEvent(DomainEvent ev, UserContext userContext)
        {
            ev.SetUserContext(userContext);
        }
    }
}
