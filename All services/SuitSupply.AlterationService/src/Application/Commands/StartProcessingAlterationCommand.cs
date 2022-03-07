namespace SuitSupply.AlterationService.Application.Commands
{
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using System;

    /// <summary>
    /// StartProcessing Alteration.
    /// </summary>
    public class StartProcessingAlterationCommand : Command
    {
        /// <summary>
        /// Gets or sets multiple shop record into single command.
        /// </summary>
        public Guid AlterationId { get; set; }
    }
}