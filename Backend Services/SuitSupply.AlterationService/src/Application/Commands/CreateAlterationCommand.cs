namespace SuitSupply.AlterationService.Application.Commands
{
    using SuitSupply.AlterationService.Application.Commands.Models;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using System;

    public class CreateAlterationCommand : Command
    {

        public Guid AlterationId { get; set; }

        public AlterationDetailsApplication[] AlterationDetails { get; set; }

        public string CustomerId { get; set; }
    }
}