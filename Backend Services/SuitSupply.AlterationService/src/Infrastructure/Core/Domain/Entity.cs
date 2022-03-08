// <copyright file="Entity.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Domain
{
    using System;

    public abstract class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        public Guid CreatedBy { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public string Language { get; protected set; }

        public DateTime LastUpdatedDate { get; protected set; }

        public Guid LastUpdatedBy { get; protected set; }

        public Guid TenantId { get; protected set; }

        public string[] Tags { get; protected set; }

        public Guid VerticalId { get; protected set; }

        public string ServiceId { get; protected set; }

        public bool IsMarkedToDelete { get; protected set; }

        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }

        protected Entity(Guid id)
        {
            if (id == Guid.Empty)
            {
                id = Guid.NewGuid();
            }

            this.Id = id;
        }

        public void SetId(Guid id)
        {
            this.Id = id;
        }
    }
}
