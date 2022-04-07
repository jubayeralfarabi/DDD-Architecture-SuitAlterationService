using SuitSupply.AlterationService.Domain.Aggregates;
using SuitSupply.AlterationService.Domain.Entities;
using SuitSupply.AlterationService.Domain.Events;
using SuitSupply.AlterationService.Domain.ValueObjects;
using SuitSupply.Platform.Infrastructure.Core.Events;

namespace SuitSupply.AlterationService.Domain
{
    public static class BusinessRuleValidator
    {
        public static List<EventMessage> ValidateCreateAlteration(Guid alterationId, AlterationDetails[] alterationDetails, string customerId)
        {
            List<EventMessage> businessRuleViotations = new List<EventMessage>() { };
            if (alterationId == Guid.Empty) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.PropertyIsNullEmpty, EventMessageType.Error, new object[] { nameof(alterationId), "Invalid alteration id." }));
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
            return businessRuleViotations;
        }
        
        public static List<EventMessage> ValidateCompletePayment(Guid alterationId, AlterationStatusEnum status)
        {
            List<EventMessage> businessRuleViotations = new List<EventMessage>() { };
            if (alterationId == Guid.Empty) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.PropertyIsNullEmpty, EventMessageType.Error, new object[] { nameof(alterationId), "Invalid alteration id." }));
            if (status != AlterationStatusEnum.UnPaid) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.AlreadyPaid, EventMessageType.Error, new object[] { nameof(alterationId), "Already Paid." }));

            return businessRuleViotations;
        }
        
        public static List<EventMessage> ValidateStartProcessing(Guid alterationId, AlterationStatusEnum status)
        {
            List<EventMessage> businessRuleViotations = new List<EventMessage>() { };
            if (alterationId == Guid.Empty) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.PropertyIsNullEmpty, EventMessageType.Error, new object[] { nameof(alterationId), "Invalid alteration id." }));
            if (status != AlterationStatusEnum.Paid) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.AlreadyPaid, EventMessageType.Error, new object[] { nameof(alterationId), "Already Paid." }));

            return businessRuleViotations;
        }
        
        public static List<EventMessage> ValidateFinishAlteration(Guid alterationId, AlterationStatusEnum status)
        {
            List<EventMessage> businessRuleViotations = new List<EventMessage>() { };
            if (alterationId == Guid.Empty) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.PropertyIsNullEmpty, EventMessageType.Error, new object[] { nameof(alterationId), "Invalid alteration id." }));
            if (status == AlterationStatusEnum.UnPaid) businessRuleViotations.Add(new EventMessage(AlterationBusinessValidationCodes.AlreadyPaid, EventMessageType.Error, new object[] { nameof(alterationId), "Already Paid." }));

            return businessRuleViotations;
        }

        public static AlterationBusinessRuleViolationEvent GetRuleViolationEvent(Guid alterationId, string actionName, AlterationDetails[] alterationDetails = null) 
        {
            AlterationBusinessRuleViolationEvent ruleViolationEvent = new AlterationBusinessRuleViolationEvent(
                        alterationId.ToString(),
                        actionName,
                        alterationDetails);
            return ruleViolationEvent;
        }

    }
}
