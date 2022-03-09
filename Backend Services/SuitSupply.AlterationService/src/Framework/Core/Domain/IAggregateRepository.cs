namespace SuitSupply.Platform.Infrastructure.Core.Domain
{
    using System;
    using System.Threading.Tasks;

    public interface IAggregateRepository<T>
        where T : IAggregateRoot
    {
        Task SaveAsync(T aggregate);

        Task UpdateAsync(T aggregate);

        T GetById(Guid id);
    }
}