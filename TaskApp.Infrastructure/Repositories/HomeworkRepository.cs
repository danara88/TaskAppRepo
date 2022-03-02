using Microsoft.EntityFrameworkCore;
using TaskApp.Core.Entities;
using TaskApp.Core.Interfaces.Repositories;
using TaskApp.Infrastructure.Data;

namespace TaskApp.Infrastructure.Repositories
{
    /// <summary>
    /// Homework repository
    /// </summary>
    public class HomeworkRepository : BaseRepository<Homework>, IHomeworkRepository
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="context"></param>
        public HomeworkRepository(TaskAppContext context) : base(context) {}

        /// <summary>
        /// Method to get homeworks by user ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<Homework>> GetHomeworksByUser(int userId)
        {
            return await _entities.Where(hw => hw.UserId == userId && !hw.IsDeleted)
                                    .Include(hw => hw.User)
                                    .ToListAsync();
        }

        /// <summary>
        /// Method to delete a homework (soft deleteion)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteHomeworkById(int id)
        {
            Homework homework = await _entities.FirstOrDefaultAsync(hw => hw.Id == id);
            if (homework == null) return false;
            homework.IsDeleted = true;
            return true;
        }
    }
}
