using TaskApp.Core.Entities;

namespace TaskApp.Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface for Base Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Method to get a record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByID(int id);

        /// <summary>
        /// Method to get all records
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Method to add a record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Method to update a record
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Method to delete a record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
