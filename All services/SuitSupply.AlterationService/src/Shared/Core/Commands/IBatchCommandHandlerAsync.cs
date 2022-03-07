// <copyright file="IBatchCommandHandlerAsync.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SuitSupply.Platform.Infrastructure.Core.Commands;

    /// <summary>Async command handler generic interface.</summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public interface IBatchCommandHandlerAsync<in TCommand>
        where TCommand : ICommand
    {
        Task<List<CommandResponse>> HandleAsync(IEnumerable<TCommand> commands);
    }
}
