namespace SuitSupply.AlterationService.Application.Commands
{
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using System;

    public class CompletePaymentCommand : Command
    {
        public Guid AlterationId { get; set; }
    }
}