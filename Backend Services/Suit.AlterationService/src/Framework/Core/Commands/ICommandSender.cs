// <copyright file="ICommandSender.cs" company="Suit">
// Copyright © 2015-2020 Suit. All Rights Reserved.
// </copyright>

namespace Suit.Platform.Infrastructure.Core.Commands
{
    using System.Threading.Tasks;

    /// <summary>Command sender interface.</summary>
    public interface ICommandSender
    {
        Task<CommandResponse> SendAsync(Command command);
    }
}
