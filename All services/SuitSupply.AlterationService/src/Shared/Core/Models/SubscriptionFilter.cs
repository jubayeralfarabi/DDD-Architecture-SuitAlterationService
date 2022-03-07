// <copyright file="SubscriptionFilter.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.PushNotificationSystem.Domain.Commands
{
    public class SubscriptionFilter
    {
        public string Context { get; set; }

        public string ActionName { get; set; }

        public string Value { get; set; }
    }
}