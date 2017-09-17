namespace DataStore.Infrastructure
{
    using Domain.Contracts;
    using Domain.Entities;
    using System;

    using DataStore.Repositories;

    public class UnitOfWorkImplementation : IUnitOfWork
    {
        //repositories
        private readonly Lazy<IRepository<Customer>> cusomerRepositoryInstanceHolder;
        public UnitOfWorkImplementation()
        {
            this.cusomerRepositoryInstanceHolder = new Lazy<IRepository<Customer>>(() => new CustomerRepository());
        }

        public IRepository<TEntity> GetRepoFor<TEntity>()
            where TEntity : class, IEntity
        {

            var entityType = typeof(TEntity);

            //repos with nested objects
            if (entityType.IsOfType<Customer>())
                return this.cusomerRepositoryInstanceHolder.Value.As<IRepository<TEntity>>();

            return null;
        }

        public int Commit()
        {
            ///Implement commit
            return 0;
        }

        /// <summary>
        /// IDisposable
        /// </summary>
        #region IDisposable implementation

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ///IMPLEMENT DISPOSE
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable implementation
    }
}
