using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommuneCalculator.DB.Models;

namespace CommuneCalculator.DB.DataAccess
{
    /// <summary>
    ///     Repository base interface
    ///     Implements IDisposable for disposing entity context
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public interface IDataRepo<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        ///     Get all Entities
        /// </summary>
        /// <returns>all entities as IQueryable</returns>
        IQueryable<TEntity> All();

        /// <summary>
        ///     Find an entity by specified id
        /// </summary>
        /// <param name="id">id to search</param>
        /// <returns>entity with specified id or null</returns>
        Optional<TEntity> FindById(object id);

        /// <summary>
        ///     Update an entity
        /// </summary>
        /// <param name="entity">entity to be updated</param>
        void UpdateEntity(TEntity entity);

        /// <summary>
        ///     Create a new entity
        /// </summary>
        /// <param name="entity">entity to be created</param>
        /// <returns>newly created entity with database id</returns>
        TEntity CreateEntity(TEntity entity);

        /// <summary>
        ///     Delete an entity
        /// </summary>
        /// <param name="id">id of the entity to be deleted</param>
        void DeleteEntity(object id);

        /// <summary>
        ///     Delete an entity
        /// </summary>
        /// <param name="entity">entity which should be deleted</param>
        void DeleteEntity(TEntity entity);

        /// <summary>
        ///     Delete a range of entites
        /// </summary>
        /// <param name="entites">IEnumerable entites to be deleted</param>
        void DeleteEntityRange(IEnumerable<TEntity> entites);

        /// <summary>
        ///     Checks if an entity exists
        /// </summary>
        /// <param name="id">id of the entity to check</param>
        /// <returns>boolean result of the check</returns>
        bool EntityExists(object id);

        /// <summary>
        ///     Query entites by specified filter function
        /// </summary>
        /// <param name="queryFunc">function to use for filtering</param>
        /// <returns>IQueryable result after filtering</returns>
        IQueryable<TEntity> QueryEntity(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryFunc);

        /// <summary>
        ///     Find an entity async
        /// </summary>
        /// <param name="id">Id of the entity to find</param>
        /// <returns>entity if existing or null if not</returns>
        Task<Optional<TEntity>> FindByIdAsync(object id);

        /// <summary>
        ///     Update an entity async
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>async void</returns>
        Task UpdateEntityAsync(TEntity entity);

        /// <summary>
        ///     Create an entity async
        /// </summary>
        /// <param name="entity">Entity to create</param>
        /// <returns>newly created entity</returns>
        Task<TEntity> CreateEntityAsync(TEntity entity);

        /// <summary>
        ///     Delete an entity async
        /// </summary>
        /// <param name="id">Id of the entity to delete</param>
        /// <returns>async void</returns>
        Task DeleteEntityAsync(object id);

        /// <summary>
        ///     Async check if entity exists
        /// </summary>
        /// <param name="id">Id of the entity to check if exists</param>
        /// <returns>boolean result of the check</returns>
        Task<bool> EntityExistsAsync(object id);
    }
}