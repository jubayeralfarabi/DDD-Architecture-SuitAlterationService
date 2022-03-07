namespace SuitSupply.AlterationService.Application.Commands
{
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Do payment for an alteration.
    /// </summary>
    public class DoPaymentCommand : Command
    {
        /// <summary>
        /// Gets or sets multiple shop record into single command.
        /// </summary>
        public Guid AlterationId { get; set; }
    }
}