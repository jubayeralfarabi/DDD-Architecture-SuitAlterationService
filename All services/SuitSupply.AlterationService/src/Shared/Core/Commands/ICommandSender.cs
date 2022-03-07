// <copyright file="ICommandSender.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Commands
{
    using System.Threading.Tasks;

    /// <summary>Command sender interface.</summary>
    public interface ICommandSender
    {
        Task<CommandResponse> SendAsync(ICommand command);

        CommandResponse Send(ICommand command);
    }
}
