// <copyright file="ViewModelBase.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Core.Models
{
    using System;
    using SuitSupply.Platform.Infrastructure.Common.Security;
    using SuitSupply.Platform.Infrastructure.Core.RowLevelSecurity;
    using SuitSupply.Platform.Infrastructure.Domain;

    public abstract class ViewModelBase : Entity, IRowLevelSecurity
    {
        public Guid[] IdsAllowedToRead { get; set; }

        public string[] RolesAllowedToRead { get; set; }

        public int Version { get; protected set; }

        public void SetDefaultRowLevelSecurity(UserContext context)
        {
            Guid[] currentUser = new Guid[] { context.UserId };

            this.IdsAllowedToRead = (this.IdsAllowedToRead == null || this.IdsAllowedToRead.Length == 0) ? currentUser : this.IdsAllowedToRead;
        }

        public override void SetDefaultValue(UserContext userContext)
        {
            base.SetDefaultValue(userContext);

            this.Version++;
        }
    }
}
