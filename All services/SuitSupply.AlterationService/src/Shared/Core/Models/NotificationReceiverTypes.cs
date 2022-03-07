// <copyright file="NotificationReceiverTypes.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.PushNotificationSystem.Domain.Commands
{
    public enum NotificationReceiverTypes
    {
        NoReceiverType,
        BroadcastReceiverType,
        UserSpecificReceiverType,
        FilterSpecificReceiverType,
        UserAndRoleSpecificReceiverType,
        FilterAndRoleSpecificReceiverType,
    }
}