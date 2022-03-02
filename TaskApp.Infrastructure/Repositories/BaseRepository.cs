using Microsoft.EntityFrameworkCore;
using TaskApp.Core.Entities;
using TaskApp.Core.Interfaces.Repositories;
using TaskApp.Infrastructure.Data;

namespace TaskApp.Infrastructure.Repositories
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TaskAppContext _context;
        protected readonly DbSet<T> _entities;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(TaskAppContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        /// <summary>
        /// Method to add a record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        /// <summary>
        /// Method to delete a record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            T entity = await GetByID(id);
            _entities.Remove(entity);
        }

        /// <summary>
        /// Method to get all records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        /// <summary>
        /// Method to get a record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByID(int id)
        {
            return await _entities.FindAsync(id);
        }

        /// <summary>
        /// Method to update a record
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
