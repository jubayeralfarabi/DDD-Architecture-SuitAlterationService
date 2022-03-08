namespace SuitSupply.Platform.Infrastructure.Core.Models
{
    using System;
    using SuitSupply.Platform.Infrastructure.Domain;

    public abstract class ViewModelBase : Entity
    {
        public Guid[] IdsAllowedToRead { get; set; }

        public string[] RolesAllowedToRead { get; set; }

        public int Version { get; protected set; }
    }
}
