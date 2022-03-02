using TaskApp.Core.Entities;

namespace TaskApp.Core.Interfaces.Repositories
{
    /// <summary>
    /// Category repository interface
    /// </summary>
    public interface ICategoryRepository : IRepository<Category>
    {
        /// <summary>
        /// Method to delete a category (soft deleteion)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteCategoryById(int id);
    }
}
