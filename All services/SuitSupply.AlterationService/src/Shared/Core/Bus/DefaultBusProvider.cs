// <copyright file="DefaultBusProvider.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Bus
{
    using System;
    using System.Threading.Tasks;

    public class DefaultBusProvider : IBusProvider
    {
        public Task SendQueueMessageAsync<TMessage>(TMessage message)
            where TMessage : IBusQueueMessage
        {
            throw new NotImplementedException(Consts.BusRequiredMessage);
        }

        public Task SendTopicMessageAsync<TMessage>(TMessage message)
            where TMessage : IBusTopicMessage
        {
            throw new NotImplementedException(Consts.BusRequiredMessage);
        }
    }
}
