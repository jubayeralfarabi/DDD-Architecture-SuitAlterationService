namespace SuitSupply.AlterationService.Application.Commands
{
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using System;

    /// <summary>
    /// Finish Alteration.
    /// </summary>
    public class FinishAlterationCommand : Command
    {
        /// <summary>
        /// Gets or sets multiple shop record into single command.
        /// </summary>
        public Guid AlterationId { get; set; }
    }
}