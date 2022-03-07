// <copyright file="IBusQueueMessage.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    /// <summary>Bus queue message interface.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Bus.IMessage" />
    public interface IBusQueueMessage : IMessage
    {
        string QueueName { get; set; }

        void SetQueueName();
    }
}
