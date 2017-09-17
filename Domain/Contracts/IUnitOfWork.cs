namespace Domain.Contracts
{
    using System;

    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Get repository of given type
        /// </summary>
       IRepository<TEntity> GetRepoFor<TEntity>() 
            where TEntity: class,IEntity ;
            

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
}
