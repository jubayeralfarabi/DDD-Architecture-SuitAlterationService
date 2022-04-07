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
            if (BusinessRuleValidator.ValidateCreateAlteration(alterationId, alterationDetails, customerId).Count>0)
            {
                this.AddEvent(BusinessRuleValidator.GetRuleViolationEvent(alterationId, nameof(CreateAlteration), alterationDetails));
                return;
            }

            this.Id = alterationId;
            this.AlterationDetails = alterationDetails;
            this.CustomerId = customerId;
            this.Status = AlterationStatusEnum.UnPaid;

            this.AddEventOnly<AlterationAggregate>(new AlterationCreatedEvent(alterationId, alterationDetails, AlterationStatusEnum.UnPaid));
        }

        public void CompletePayment(Guid alterationId)
        {
            if (BusinessRuleValidator.ValidateCompletePayment(alterationId, this.Status).Count > 0)
            {
                this.AddEvent(BusinessRuleValidator.GetRuleViolationEvent(alterationId, nameof(CompletePayment)));
                return;
            }

            this.Status = AlterationStatusEnum.Paid;

            this.AddEventOnly<AlterationAggregate>(new AlterationPaymentDoneEvent(alterationId, AlterationStatusEnum.Paid));
        }

        public void StartProcessing(Guid alterationId)
        {
            if (BusinessRuleValidator.ValidateStartProcessing(alterationId, this.Status).Count > 0)
            {
                this.AddEvent(BusinessRuleValidator.GetRuleViolationEvent(alterationId, nameof(StartProcessing)));
                return;
            }

            this.Status = AlterationStatusEnum.TailorProcessing;

            this.AddEventOnly<AlterationAggregate>(new AlterationStartedProcessingEvent(alterationId, AlterationStatusEnum.TailorProcessing));
        }

        public void FinishAlteration(Guid alterationId)
        {
            if (BusinessRuleValidator.ValidateFinishAlteration(alterationId, this.Status).Count > 0)
            {
                this.AddEvent(BusinessRuleValidator.GetRuleViolationEvent(alterationId, nameof(FinishAlteration)));
                return;
            }

            this.Status = AlterationStatusEnum.Finished;

            this.AddEventOnly<AlterationAggregate>(new AlterationFinishedEvent(alterationId, AlterationStatusEnum.Finished, this.CustomerId));
        }
    }
}
