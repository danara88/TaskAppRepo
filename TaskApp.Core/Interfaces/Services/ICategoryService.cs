using TaskApp.Core.Entities;

namespace TaskApp.Core.Interfaces.Services
{
    /// <summary>
    /// Category service interface
    /// </summary>
    public interface ICategoryService
    {
       /// <summary>
       /// Method to create category
       /// </summary>
       /// <param name="category"></param>
       /// <returns></returns>
        Task CreateCategory(Category category);

       /// <summary>
       /// Method to get categories
       /// </summary>
       /// <param name="userId"></param>
       /// <returns></returns>
        List<Category> GetCategories();

        /// <summary>
        /// Method to update a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<bool> UpdateCategory(Category category);

       /// <summary>
       /// Method to delete a category by ID
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        Task<bool> DeleteCategoryById(int id);
    }
}
