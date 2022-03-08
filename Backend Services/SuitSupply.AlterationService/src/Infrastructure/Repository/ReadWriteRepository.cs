namespace SuitSupply.Infrastructure.Repository.RDBRepository
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;

    public class ReadWriteRepository<TContext> : ReadOnlyRepository<TContext>, IReadWriteRepository
     where TContext : DbContext
    {
        public ReadWriteRepository(TContext context)
            : base(context)
        {

        }

        public ChangeTracker ChangeTracker { get; set; }

        public virtual void Create<TEntity>(TEntity entity, string createdBy = null)
            where TEntity : class
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public virtual void Update<TEntity>(TEntity entity, string modifiedBy = null)
            where TEntity : class
        {
            this.context.Set<TEntity>().Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete<TEntity>(object id)
            where TEntity : class
        {
            TEntity entity = this.context.Set<TEntity>().Find(id);
            this.Delete(entity);
        }

        public virtual void Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            var dbSet = this.context.Set<TEntity>();
            if (this.context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual Task SaveAsync()
        {
            try
            {
                return this.context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(0);
        }
    }
}
