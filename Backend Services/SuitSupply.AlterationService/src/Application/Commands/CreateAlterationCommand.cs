namespace SuitSupply.AlterationService.Application.Commands
{
    using SuitSupply.AlterationService.Domain.Entities;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using System;

    public class CreateAlterationCommand : Command
    {

        public Guid AlterationId { get; set; }

        public AlterationDetails[] AlterationDetails { get; set; }

        public string CustomerId { get; set; }
    }
}