namespace Suit.AlterationService.Application.Commands
{
    using Suit.Platform.Infrastructure.Core.Commands;
    using System;

    public class FinishAlterationCommand : Command
    {
        public Guid AlterationId { get; set; }
    }
}