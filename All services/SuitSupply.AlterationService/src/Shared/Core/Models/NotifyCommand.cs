// <copyright file="NotifyCommand.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.PushNotificationSystem.Domain.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Platform.Infrastructure.Core.Domain;

    public class NotifyCommand : Command
    {
        public static Uri SendEndPointUri { get; } = new Uri("queue:SuitSupply.Platform.PushNotificationSystem.Domain.Commands");

        public NotifierPayloadWithResponse Payload { get; set; }

        public static NotifyCommand CreateRoleSpecificNotificationCommand<T>(T response)
            where T : DomainEvent
        {
            NotifyCommand sendNotificationCommand = new NotifyCommand
            {
                Payload = new NotifierPayloadWithResponse
                {
                    Roles = response.UserContext.Roles.ToList(),
                    ResponseKey = typeof(T).Name,
                    NotificationType = NotificationReceiverTypes.NoReceiverType,
                    ResponseValue = JsonConvert.SerializeObject(response),
                    DenormalizedPayload = string.Empty,
                    ConnectionId = response.CorrelationId.ToString(),
                },
            };

            response.UserContext.ClientId = Guid.Empty.ToString();

            sendNotificationCommand.SetUserContext(response.UserContext);

            return sendNotificationCommand;
        }

        public static NotifyCommand CreateUserSpecificNotificationCommand<T>(T response)
            where T : DomainEvent
        {
            NotifyCommand sendNotificationCommand = new NotifyCommand
            {
                Payload = new NotifierPayloadWithResponse
                {
                    UserIds = new[] { response.UserContext.UserId },
                    ResponseKey = typeof(T).Name,
                    NotificationType = NotificationReceiverTypes.UserSpecificReceiverType,
                    ResponseValue = JsonConvert.SerializeObject(response),
                    DenormalizedPayload = string.Empty,
                    ConnectionId = response.CorrelationId.ToString(),
                },
            };

            response.UserContext.ClientId = Guid.Empty.ToString();

            sendNotificationCommand.SetUserContext(response.UserContext);

            return sendNotificationCommand;
        }

        public static NotifyCommand CreateBroadCastNotificationCommand<T>(T response)
            where T : DomainEvent
        {
            NotifyCommand sendNotificationCommand = new NotifyCommand
            {
                Payload = new NotifierPayloadWithResponse
                {
                    ResponseKey = typeof(T).Name,
                    NotificationType = NotificationReceiverTypes.BroadcastReceiverType,
                    ResponseValue = JsonConvert.SerializeObject(response),
                    DenormalizedPayload = string.Empty,
                    ConnectionId = response.CorrelationId.ToString(),
                },
            };

            response.UserContext.ClientId = Guid.Empty.ToString();

            sendNotificationCommand.SetUserContext(response.UserContext);

            return sendNotificationCommand;
        }

        public static NotifyCommand CreateFilterSpecificNotificationCommand<T>(T response, List<SubscriptionFilter> subscriptionFilters)
            where T : DomainEvent
        {
            NotifyCommand sendNotificationCommand = new NotifyCommand
            {
                Payload = new NotifierPayloadWithResponse
                {
                    ResponseKey = typeof(T).Name,
                    NotificationType = NotificationReceiverTypes.FilterSpecificReceiverType,
                    ResponseValue = JsonConvert.SerializeObject(response),
                    DenormalizedPayload = string.Empty,
                    SubscriptionFilters = subscriptionFilters,
                    ConnectionId = response.CorrelationId.ToString(),
                },
            };

            response.UserContext.ClientId = Guid.Empty.ToString();

            sendNotificationCommand.SetUserContext(response.UserContext);

            return sendNotificationCommand;
        }
    }
}