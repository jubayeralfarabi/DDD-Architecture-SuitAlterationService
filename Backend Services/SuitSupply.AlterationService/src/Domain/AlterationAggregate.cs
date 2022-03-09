namespace SuitSupply.AlterationService.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SuitSupply.AlterationService.Domain.Aggregates;
    using SuitSupply.AlterationService.Domain.Entities;
    using SuitSupply.AlterationService.Domain.Events;
    using SuitSupply.AlterationService.Domain.ValueObjects;
    using SuitSupply.Platform.Infrastructure.Core.Domain;
    using SuitSupply.Platform.Infrastructure.Core.Events;

    public class AlterationAggregate : AggregateRoot
    {
        public ICollection<AlterationDetails> AlterationDetails { get; private  set; }

        public AlterationStatusEnum Status { get; private set; }

        public string CustomerId {get; private set;}

        public AlterationAggregate()
        {
        }

        public void CreateAlteration(Guid alterationId, AlterationDetails[] alterationDetails, string customerId)
        {
            List<EventMessage> businessRuleViotations = new List<EventMessage>() { };
            if (alterationId == Guid.Empty) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.PropertyIsNullEmpty, EventMessageType.Error, new object[] { nameof(alterationId), "Invalid alteration id."}));
            if (alterationDetails == null || !alterationDetails.Any()) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.ArrayMustHaveAnElement, EventMessageType.Error, new object[] { nameof(alterationDetails), "alteration details must have value." }));
            if (alterationDetails != null && alterationDetails.Any())
            {
                alterationDetails.ToList().ForEach(a =>
                {
                    if (a.AlterationValue < -5 || a.AlterationValue > 5)
                    {
                        businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.InvalidAlterationValue, EventMessageType.Error, new object[] { nameof(alterationDetails), a.AlterationValue, "Has invalid alteration value. It should be between +/- 5." }));
                    }
                    if (!Enum.IsDefined<AlterationTypeEnum>(a.AlterationName))
                    {
                        businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.InvalidAlterationType, EventMessageType.Error, new object[] { nameof(a.AlterationName), a.AlterationName, "Has invalid alteration type." }));
                    }
                });
            }
            if (string.IsNullOrEmpty(customerId)) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.PropertyIsNullEmpty, EventMessageType.Error, new object[] { nameof(alterationId), "Invalid customer id." }));


            if (businessRuleViotations.Count>0)
            {
                AlterationBusinessRuleViolationEvent ruleViolationEvent = new AlterationBusinessRuleViolationEvent(
                    alterationId.ToString(),
                    nameof(this.CreateAlteration),
                    alterationDetails,
                    businessRuleViotations.ToArray());

                this.AddEvent(ruleViolationEvent);
                return;
            }

            this.Id = alterationId;
            this.AlterationDetails = alterationDetails;
            this.CustomerId = customerId;
            this.Status = AlterationStatusEnum.UnPaid;

            this.AddEventOnly<AlterationAggregate>(new AlterationCreatedEvent(alterationId, alterationDetails, AlterationStatusEnum.UnPaid);
        }

        public void CompletePayment(Guid alterationId)
        {
            List<EventMessage> businessRuleViotations = new List<EventMessage>() { };
            if (this.Status != AlterationStatusEnum.UnPaid) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.AlreadyPaid, EventMessageType.Error, new object[] { nameof(alterationId), "Already Paid." }));

            if (businessRuleViotations.Count > 0)
            {
                AlterationBusinessRuleViolationEvent ruleViolationEvent = new AlterationBusinessRuleViolationEvent(
                    alterationId.ToString(),
                    nameof(this.CreateAlteration),
                    null,
                    businessRuleViotations.ToArray());

                this.AddEvent(ruleViolationEvent);
                return;
            }

            this.Status = AlterationStatusEnum.Paid;

            this.AddEventOnly<AlterationAggregate>(new AlterationPaymentDoneEvent(alterationId, AlterationStatusEnum.Paid));
        }

        public void StartProcessing(Guid alterationId)
        {
            List<EventMessage> businessRuleViotations = new List<EventMessage>() { };
            if (this.Status != AlterationStatusEnum.Paid) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.PaymentRequired, EventMessageType.Error, new object[] { nameof(alterationId), "Alteration required payment." }));

            if (businessRuleViotations.Count > 0)
            {
                AlterationBusinessRuleViolationEvent ruleViolationEvent = new AlterationBusinessRuleViolationEvent(
                    alterationId.ToString(),
                    nameof(this.CreateAlteration),
                    null,
                    businessRuleViotations.ToArray());

                this.AddEvent(ruleViolationEvent);
                return;
            }

            this.Status = AlterationStatusEnum.TailorProcessing;

            this.AddEventOnly<AlterationAggregate>(new AlterationStartedProcessingEvent(alterationId, AlterationStatusEnum.TailorProcessing));
        }

        public void FinishAlteration(Guid alterationId)
        {
            List<EventMessage> businessRuleViotations = new List<EventMessage>() { };
            if (this.Status == AlterationStatusEnum.UnPaid) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.PaymentRequired, EventMessageType.Error, new object[] { nameof(alterationId), "Alteration required payment." }));

            if (businessRuleViotations.Count > 0)
            {
                AlterationBusinessRuleViolationEvent ruleViolationEvent = new AlterationBusinessRuleViolationEvent(
                    alterationId.ToString(),
                    nameof(this.CreateAlteration),
                    null,
                    businessRuleViotations.ToArray());

                this.AddEvent(ruleViolationEvent);
                return;
            }

            this.Status = AlterationStatusEnum.Finished;

            this.AddEventOnly<AlterationAggregate>(new AlterationFinishedEvent(alterationId, AlterationStatusEnum.Finished, this.CustomerId));
        }
    }
}
