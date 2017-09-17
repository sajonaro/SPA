namespace DataStore.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Domain.Contracts;

    /// <summary>
    /// Implementation of generic repository allowing to define child elements to load
    /// to be able to get the whole graph
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public  abstract class GetWithIncludeRepositoryBase<TEntity>: IRepository<TEntity> where TEntity:class, IEntity
    {
        private readonly DbSet<TEntity> dbSet; 
        private readonly IRepository<TEntity> genericRepo;

        /// <summary>
        /// child properties to load
        /// </summary>
        protected Expression<Func<TEntity, object>>[] IncludePropertiesToOverride { get; set; }

        protected GetWithIncludeRepositoryBase(DbSet<TEntity> dbSet,IRepository<TEntity> repository)
        {
            this.dbSet = dbSet;
            this.genericRepo = repository;
        }

        private IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate)
        {
            IQueryable<TEntity> query = this.dbSet.AsNoTracking();

            return 
                 this.IncludePropertiesToOverride
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty)) 
                .Where(predicate)
                .ToList();
        }


        #region IRepository<TEntity> members

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return this.GetWithInclude(predicate);
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return this.GetWithInclude(predicate).ToList().FirstOrDefault();
        }
        public TEntity FindById(int id)
        {
            return this.Get(p => p.Id == id);
        }

        public int AddNew(TEntity item)
        {
            return this.genericRepo.AddNew(item);
        }
        public void Update(TEntity item)
        {
            this.genericRepo.Update(item);
        }
        public void Remove(TEntity item)
        {
            this.genericRepo.Remove(item);
        }

        #endregion IRepository<TEntity> members
    }
}
