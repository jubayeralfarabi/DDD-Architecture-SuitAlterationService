// <copyright file="ISecurityInfo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Common.Security
{
    public interface ISecurityInfo
    {
        UserContext UserContext { get; }

        void SetUserContext(UserContext userContext);
    }
}
