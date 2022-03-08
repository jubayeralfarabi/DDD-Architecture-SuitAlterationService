// <copyright file="ICommandHandlerAsync.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Core.Commands;

    /// <summary>Async command handler generic interface.</summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public interface ICommandHandlerAsync<in TCommand>
        where TCommand : Command
    {
        Task<CommandResponse> HandleAsync(TCommand command);
    }
}
