// <copyright file="ICommand.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    using SuitSupply.Platform.Infrastructure.Core.Bus;

    /// <summary>Command Interface.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Bus.IMessage" />
    public interface ICommand : IMessage
    {
        bool? PublishEvents { get; set; }

        bool? ValidateCommand { get; set; }
    }
}
