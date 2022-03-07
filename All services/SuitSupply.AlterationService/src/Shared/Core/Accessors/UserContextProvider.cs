// <copyright file="UserContextProvider.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Accessors
{
    using System;
    using SuitSupply.Platform.Infrastructure.Common.Security;

    public class UserContextProvider : IUserContextProvider
    {
        private readonly IContextAccessor contextAccessor;

        public UserContextProvider(IContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public UserContext GetUserContext()
        {
            return this.contextAccessor.Context.UserContext;
        }
    }
}
