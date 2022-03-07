namespace SuitSupply.AlterationService.Application.Commands
{
    using SuitSupply.Platform.Infrastructure.Core.Commands;

    /// <summary>
    /// Finish Alteration.
    /// </summary>
    public class FinishAlterationCommand : Command
    {
        /// <summary>
        /// Gets or sets multiple shop record into single command.
        /// </summary>
        public string AlterationId { get; set; }
    }
}