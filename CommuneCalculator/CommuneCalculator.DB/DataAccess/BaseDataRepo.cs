using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using CommuneCalculator.DB.Models;

namespace CommuneCalculator.DB.DataAccess
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class BaseDataRepo<TEntity> : IDataRepo<TEntity> where TEntity : class
    {
        /// <summary>
        ///     Base constructor
        /// </summary>
        /// <param name="context">
        ///     Context in which will be operated
        ///     gets injected by dependency injection
        /// </param>
        public BaseDataRepo(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        ///     DbContext on which will be operated
        /// </summary>
        public DbContext Context { get; set; }

        /// <summary>
        ///     Get all Entities
        /// </summary>
        /// <returns>all entities as IQueryable</returns>
        public virtual IQueryable<TEntity> All()
        {
            return Context.Set<TEntity>();
        }

        /// <summary>
        ///     Find an entity by specified id
        /// </summary>
        /// <param name="id">id to search</param>
        /// <returns>entity with specified id or null</returns>
        public virtual Optional<TEntity> FindById(object id)
        {
            return new Optional<TEntity>(Context.Set<TEntity>().Find(id));
        }

        /// <summary>
        ///     Update an entity
        /// </summary>
        /// <param name="entity">entity to be updated</param>
        public virtual void UpdateEntity(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            var attached = Context.Entry(entity);
            attached.State = EntityState.Modified;
            Context.SaveChanges();
        }

        /// <summary>
        ///     Create a new entity
        /// </summary>
        /// <param name="entity">entity to be created</param>
        /// <returns>newly created entity with database id</returns>
        public virtual TEntity CreateEntity(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            return entity;
        }

        /// <summary>
        ///     Delete an entity
        /// </summary>
        /// <param name="id">id of the entity to be deleted</param>
        public virtual void DeleteEntity(object id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                Context.Set<TEntity>().Remove(entity);
                Context.SaveChanges();
            }
        }

        /// <summary>
        ///     Delete an entity
        /// </summary>
        /// <param name="entity">entity which should be deleted</param>
        public virtual void DeleteEntity(TEntity entity)
        {
            if (entity != null)
            {
                Context.Set<TEntity>().Remove(entity);
                Context.SaveChanges();
            }
        }

        /// <summary>
        ///     Delete a range of entites
        /// </summary>
        /// <param name="entites">IEnumerable entites to be deleted</param>
        public virtual void DeleteEntityRange(IEnumerable<TEntity> entites)
        {
            var enumerable = entites as IList<TEntity> ?? entites.ToList();
            if (enumerable.Any())
            {
                Context.Set<TEntity>().RemoveRange(enumerable);
            }
            Context.SaveChanges();
        }

        /// <summary>
        ///     Checks if an entity exists
        /// </summary>
        /// <param name="id">id of the entity to check</param>
        /// <returns>boolean result of the check</returns>
        public virtual bool EntityExists(object id)
        {
            return Context.Set<TEntity>().Find(id) != null;
        }

        /// <summary>
        ///     Query entites by specified filter function
        /// </summary>
        /// <param name="queryFunc">function to use for filtering</param>
        /// <returns>IQueryable result after filtering</returns>
        public virtual IQueryable<TEntity> QueryEntity(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryFunc)
        {
            return queryFunc(Context.Set<TEntity>());
        }

        /// <summary>
        ///     Find an entity async
        /// </summary>
        /// <param name="id">Id of the entity to find</param>
        /// <returns>entity if existing or null if not</returns>
        public virtual async Task<Optional<TEntity>> FindByIdAsync(object id)
        {
            return new Optional<TEntity>(await Context.Set<TEntity>().FindAsync(id));
        }

        /// <summary>
        ///     Update an entity async
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>async void</returns>
        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///     A database command did not affect the expected number of rows. This usually indicates an optimistic
        ///     concurrency violation; that is, a row has been changed in the database since it was queried.
        /// </exception>
        /// <exception cref="DbEntityValidationException">
        ///     The save was aborted because validation of entity property values failed.
        /// </exception>
        public virtual async Task UpdateEntityAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        /// <summary>
        ///     Create an entity async
        /// </summary>
        /// <param name="entity">Entity to create</param>
        /// <returns>newly created entity</returns>
        public virtual async Task<TEntity> CreateEntityAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        ///     Delete an entity async
        /// </summary>
        /// <param name="id">Id of the entity to delete</param>
        /// <returns>async void</returns>
        public virtual async Task DeleteEntityAsync(object id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                Context.Set<TEntity>().Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        /// <summary>
        ///     Async check if entity exists
        /// </summary>
        /// <param name="id">Id of the entity to check if exists</param>
        /// <returns>boolean result of the check</returns>
        public virtual async Task<bool> EntityExistsAsync(object id)
        {
            return await Context.Set<TEntity>().FindAsync(id) != null;
        }

        /// <summary>
        ///     Imlementation for IDisposable interface
        ///     disposes entity context
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}