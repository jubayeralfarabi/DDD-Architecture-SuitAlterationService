// <copyright file="Command.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

using System;

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{

    public abstract class Command
    {
        public Guid CorrelationId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
