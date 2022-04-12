// <copyright file="EventMessage.cs" company="Suit">
// Copyright © 2015-2020 Suit. All Rights Reserved.
// </copyright>

namespace Suit.Platform.Infrastructure.Core.Events
{
    public class EventMessage
    {
        public EventMessage()
        {
        }

        public EventMessage(int messageCode, EventMessageType messageType, object[] data)
            : this(messageCode, messageType)
        {
            this.Data = data;
        }

        public EventMessage(int messageCode, EventMessageType messageType)
        {
            this.MessageType = messageType;
            this.MessageCode = messageCode;
        }

        public int MessageCode { get; set; }

        public EventMessageType MessageType { get; set; }

        public object[] Data { get; set; }
    }
}
