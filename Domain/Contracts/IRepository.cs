
namespace Domain.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        int AddNew(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate);
        TEntity Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
