using TaskApp.Core.Entities;

namespace TaskApp.Core.Interfaces.Services
{
    /// <summary>
    /// Interface for homework service
    /// </summary>
    public interface IHomeworkService
    {
        /// <summary>
        /// Method to create a homework
        /// </summary>
        /// <param name="homework"></param>
        /// <returns></returns>
        Task CreateHomework(Homework homework);

        /// <summary>
        /// Method to get all homeworks by user ID
        /// </summary>
        /// <returns></returns>
        Task<List<Homework>> GetHomeworksByUser(int userId);

        /// <summary>
        /// Method to update a homework
        /// </summary>
        /// <param name="homework"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        Task<bool> UpdateHomework(Homework homework);

        /// <summary>
        /// Method to delete a homework (soft deleteion)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        Task<bool> DeleteHomeworkById(int id);

        /// <summary>
        /// Method to assign categories to a homework
        /// </summary>
        /// <param name="categoriesHomework"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        Task AssignCategoriesToHomework(List<CategoryHomework> categoriesHomework);
    }
}
