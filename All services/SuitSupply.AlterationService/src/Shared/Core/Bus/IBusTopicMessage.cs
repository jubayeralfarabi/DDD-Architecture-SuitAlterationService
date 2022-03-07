// <copyright file="IBusTopicMessage.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    /// <summary>Bust topic message interface.</summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Bus.IMessage" />
    public interface IBusTopicMessage : IMessage
    {
        string TopicName { get; set; }
    }
}
