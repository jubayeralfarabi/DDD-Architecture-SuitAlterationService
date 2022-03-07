// <copyright file="ICommandHandler.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    /// <summary>CommandHandler Generic interface.</summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        CommandResponse Handle(TCommand command);
    }
}
