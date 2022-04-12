namespace Suit.AlterationService.Application.Commands
{
    using Suit.AlterationService.Application.Commands.Models;
    using Suit.Platform.Infrastructure.Core.Commands;
    using System;

    public class CreateAlterationCommand : Command
    {

        public Guid AlterationId { get; set; }

        public AlterationDetailsApplication[] AlterationDetails { get; set; }

        public string CustomerId { get; set; }
    }
}