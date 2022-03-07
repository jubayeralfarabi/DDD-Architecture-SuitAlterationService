// <copyright file="BusTopicMessage.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    /// <summary>
    ///   <para>Bust tompic message abstraction.</para>
    /// </summary>
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Bus.Message" />
    /// <seealso cref="SuitSupply.Platform.Infrastructure.Core.Bus.IBusTopicMessage" />
    public abstract class BusTopicMessage : Message, IBusTopicMessage
    {
        public string TopicName { get; set; }
    }
}
