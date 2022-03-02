using Microsoft.EntityFrameworkCore;
using TaskApp.Core.Entities;
using TaskApp.Core.Interfaces.Repositories;
using TaskApp.Infrastructure.Data;

namespace TaskApp.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="context"></param>
        public CategoryRepository(TaskAppContext context) : base(context) { }

        /// <summary>
        /// Method to delete a category (soft deleteion)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCategoryById(int id)
        {
            Category category = await _entities.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return false;
            category.IsDeleted = true;
            return true;
        }
    }
}
