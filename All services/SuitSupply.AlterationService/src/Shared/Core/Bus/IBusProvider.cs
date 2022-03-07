// <copyright file="IBusProvider.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// IBusProvider.
    /// </summary>
    public interface IBusProvider
    {
        /// <summary>
        /// Sends the queue message asynchronously.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="message">The message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SendQueueMessageAsync<TMessage>(TMessage message)
            where TMessage : IBusQueueMessage;

        /// <summary>
        /// Sends the topic message asynchronously.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="message">The message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SendTopicMessageAsync<TMessage>(TMessage message)
            where TMessage : IBusTopicMessage;
    }
}
