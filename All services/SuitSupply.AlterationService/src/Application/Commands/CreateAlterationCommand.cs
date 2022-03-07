namespace SuitSupply.AlterationService.Application.Commands
{
    using SuitSupply.AlterationService.Domain.ValueObjects;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Create alteration.
    /// </summary>
    public class CreateAlterationCommand : Command
    {

        public Guid AlterationId { get; set; }

        /// <summary>
        /// Gets or sets multiple Alteration details.
        /// </summary>
        public AlterationDetails[] AlterationDetails { get; set; }
    }
}