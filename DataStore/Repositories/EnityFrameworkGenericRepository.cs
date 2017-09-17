namespace DataStore.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    using Domain.Contracts;

    public class EnityFrameworkGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        readonly DbContext _context;
        readonly DbSet<TEntity> _dbSet;

        public EnityFrameworkGenericRepository(DbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
        {
            return this._dbSet
                .AsNoTracking()
                .Where(predicate)
                .ToList();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            var result = this._dbSet.AsNoTracking().Where(predicate).ToList();
            return result.Count == 0 ? null : result.First();
        }
        public TEntity FindById(int id)
        {
            return this._dbSet.Find(id);
        }

        public int AddNew(TEntity item)
        {
            this._dbSet.Add(item);
            this._context.SaveChanges();
            return item.Id;
        }
        public void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var  errorMessage = dbEx.EntityValidationErrors
                    .Aggregate(string.Empty, (current1, validationErrors) => validationErrors.ValidationErrors
                    .Aggregate(current1,
                        (current, validationError) => current + (Environment.NewLine + $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")));

                throw new Exception(errorMessage, dbEx);
            }

       
        }
        public void Remove(TEntity item)
        {
                item.IsDeleted = true;
                this.Update(item);
        }

      
    }
}
