using TaskApp.Core.Entities;

namespace TaskApp.Core.Interfaces.Repositories
{
    /// <summary>
    /// Homework repository interface
    /// </summary>
    public interface IHomeworkRepository : IRepository<Homework>
    {
        /// <summary>
        /// Method to get homeworks by user ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<List<Homework>> GetHomeworksByUser(int userId);

        /// <summary>
        /// Method to delete a homework (soft deleteion)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteHomeworkById(int id);
    }
}
