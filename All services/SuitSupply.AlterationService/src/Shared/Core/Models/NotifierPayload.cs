// <copyright file="NotifierPayload.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.PushNotificationSystem.Domain.Commands
{
    using System;
    using System.Collections.Generic;

    public class NotifierPayload
    {
        public string ConnectionId { get; set; }

        /// <summary>
        ///     Gets and Sets CreatedBy.
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        ///     It is only applicable or considered when we want User Specific Notification for single user.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        ///     It is only applicable or considered when we want User Specific Notification for multiple users.
        /// </summary>
        public Guid[] UserIds { get; set; }

        /// <summary>
        /// It is only applicable or considered when we want User Specific Notification for multiple users based on their roles.
        /// </summary>
        public List<string> Roles { get; set; }

        /// <summary>
        ///     It is only applicable or considered when we want Filter Specific Notification.
        /// </summary>
        public List<SubscriptionFilter> SubscriptionFilters { get; set; }

        /// <summary>
        ///     It can be BroadcastReceiverType, FilterSpecificReceiverType, UserSpecificReceiverType (from
        ///     NotificationReceiverTypeCodes).
        /// </summary>
        public NotificationReceiverTypes NotificationType { get; set; }

        /// <summary>Gets or sets the type of the device.</summary>
        /// <value>The type of the device.</value>
        public string DeviceType { get; set; }

        /// <summary>Gets or sets a value indicating whether [keep silent].</summary>
        /// <value>
        ///   <c>true</c> if [keep silent]; otherwise, <c>false</c>.</value>
        public bool KeepSilent { get; set; }

        /// <summary>
        /// payload(JSON string) you want to store with offline message. This payload will not push through socket.
        /// </summary>
        public string DenormalizedPayload { get; set; }

        /// <summary>
        /// This field only considered when notification type is filterSpecific; if it is true then it will store FilterSpecificNotification to DB so that user can grab it later
        /// For UserSpecific and BroadCast all will be automatically stored; in that case this field value is not considered.
        /// </summary>
        public bool EnablePersistence { get; set; }

        /// <summary>Gets or sets a value indicating whether [save denormalized payload as string].</summary>
        /// <value>
        ///   <c>true</c> if [save denormalized payload as string]; otherwise, <c>false</c>.</value>
        public bool SaveDenormalizedPayloadAsString { get; set; }
    }
}