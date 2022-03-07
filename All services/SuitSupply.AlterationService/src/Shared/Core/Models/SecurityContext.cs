// <copyright file="SecurityContext.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Models
{
    using SuitSupply.Platform.Infrastructure.Common.Security;

    public class SecurityContext
    {
        public SecurityContext(string messageId, UserContext userContext)
        {
            this.MessageId = messageId;
            this.UserContext = userContext;
        }

        public string MessageId { get; }

        public UserContext UserContext { get; }
    }
}
