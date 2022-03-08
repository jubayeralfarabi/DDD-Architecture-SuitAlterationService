namespace SuitSupply.AlterationService.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SuitSupply.AlterationService.Domain.Aggregates;
    using SuitSupply.AlterationService.Domain.Events;
    using SuitSupply.AlterationService.Domain.ValueObjects;
    using SuitSupply.Platform.Infrastructure.Core.Domain;
    using SuitSupply.Platform.Infrastructure.Core.Events;

    public class AlterationAggregate : AggregateRoot
    {
        public Guid AlterationId { get; private set; }

        public AlterationDetails[] AlterationDetails { get; private set; }

        public AlterationStatusEnum Status { get; private set; }

        public string CustomerId {get; private set;}

        public AlterationAggregate()
        {
        }

        public void CreateAlteration(Guid alterationId, AlterationDetails[] alterationDetails, string customerId, Guid coorelationId)
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

            AlterationCreatedEvent alterationCreatedEvent = new AlterationCreatedEvent(alterationId, alterationDetails, AlterationStatusEnum.UnPaid, coorelationId);

            this.AddAndApplyEvent<AlterationAggregate>(alterationCreatedEvent);
        }

        public void CompletePayment(Guid alterationId, Guid coorelationId)
        {
            List<EventMessage> errors = new List<EventMessage>() { };
            if (this.Status != AlterationStatusEnum.UnPaid) errors.Add(new EventMessage(AlterationBusinessValidationCodes.AlreadyPaid, EventMessageType.Error, new object[] { nameof(alterationId), "Already Paid." }));

            if (errors.Count > 0)
            {
                AlterationBusinessRuleViolationEvent ruleViolationEvent = new AlterationBusinessRuleViolationEvent(
                    alterationId.ToString(),
                    nameof(this.CreateAlteration),
                    null,
                    errors.ToArray());

                this.AddEvent(ruleViolationEvent);
                return;
            }

            AlterationPaymentDoneEvent alterationPaymentDoneEvent = new AlterationPaymentDoneEvent(alterationId, AlterationStatusEnum.Paid, coorelationId);

            this.AddAndApplyEvent<AlterationAggregate>(alterationPaymentDoneEvent);
        }

        public void StartProcessing(Guid alterationId, Guid coorelationId)
        {
            List<EventMessage> errors = new List<EventMessage>() { };
            if (this.Status != AlterationStatusEnum.Paid) errors.Add(new EventMessage(AlterationBusinessValidationCodes.PaymentRequired, EventMessageType.Error, new object[] { nameof(alterationId), "Alteration required payment." }));

            if (errors.Count > 0)
            {
                AlterationBusinessRuleViolationEvent ruleViolationEvent = new AlterationBusinessRuleViolationEvent(
                    alterationId.ToString(),
                    nameof(this.CreateAlteration),
                    null,
                    errors.ToArray());

                this.AddEvent(ruleViolationEvent);
                return;
            }

            AlterationStartedProcessingEvent alterationStartedProcessingEvent = new AlterationStartedProcessingEvent(alterationId, AlterationStatusEnum.TailorProcessing, coorelationId);

            this.AddAndApplyEvent<AlterationAggregate>(alterationStartedProcessingEvent);
        }

        public void FinishAlteration(Guid alterationId, Guid coorelationId)
        {
            List<EventMessage> errors = new List<EventMessage>() { };
            if (this.Status != AlterationStatusEnum.Paid) errors.Add(new EventMessage(AlterationBusinessValidationCodes.PaymentRequired, EventMessageType.Error, new object[] { nameof(alterationId), "Alteration required payment." }));

            if (errors.Count > 0)
            {
                AlterationBusinessRuleViolationEvent ruleViolationEvent = new AlterationBusinessRuleViolationEvent(
                    alterationId.ToString(),
                    nameof(this.CreateAlteration),
                    null,
                    errors.ToArray());

                this.AddEvent(ruleViolationEvent);
                return;
            }

            AlterationFinishedEvent alterationFinishedEvent = new AlterationFinishedEvent(alterationId, AlterationStatusEnum.Finished, this.CustomerId, coorelationId);

            this.AddAndApplyEvent<AlterationAggregate>(alterationFinishedEvent);
        }

        private void Apply(AlterationCreatedEvent @event)
        {
            this.Id = @event.AlterationId;
            this.AlterationDetails = @event.AlterationDetails;
            this.Status = @event.Status;
        }

        private void Apply(AlterationPaymentDoneEvent @event)
        {
            this.Status = @event.Status;
        }

        private void Apply(AlterationStartedProcessingEvent @event)
        {
            this.Status = @event.Status;
        }

        private void Apply(AlterationFinishedEvent @event)
        {
            this.Status = @event.Status;
        }
    }
}
