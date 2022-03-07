// <copyright file="IBusMessageDispatcher.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    using System.Threading.Tasks;

    /// <summary>Bus message dispatcher interface.</summary>
    public interface IBusMessageDispatcher
    {
        Task DispatchAsync<TMessage>(TMessage message)
            where TMessage : IMessage;

        Task PublishAsync<TMessage>(TMessage @event)
             where TMessage : IBusTopicMessage;

        Task SendAsync<TMessage>(TMessage command)
            where TMessage : IBusQueueMessage;
    }
}
