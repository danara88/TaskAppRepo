using TaskApp.Core.Entities;
using TaskApp.Core.Exceptions;
using TaskApp.Core.Interfaces.Repositories;
using TaskApp.Core.Interfaces.Services;

namespace TaskApp.Core.Services
{
    /// <summary>
    /// Category service
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Method to create a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task CreateCategory(Category category)
        {
            try
            {
                category.CreatedOn = DateTime.Now;

                await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw new BusinessException("Something went wrong.");
            }
        }

        /// <summary>
        /// Method to delete a category by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteCategoryById(int id)
        {
            Category category = await _unitOfWork.CategoryRepository.GetByID(id);
            if (category != null)
            {
                // Verify if the category is assigned to any homework
                bool assignedToHomework = _unitOfWork.CategoryHomeworkRepository.GetAll()
                                                     .Any(ch => ch.CategoryId == category.Id && !ch.Homework.IsDeleted);
                if (assignedToHomework)
                {
                    throw new BusinessException("Error! The category is assigned to homeworks");
                }

                try
                {
                    var result = await _unitOfWork.CategoryRepository.DeleteCategoryById(category.Id);
                    await _unitOfWork.SaveChangesAsync();
                    if (result)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (System.Exception)
                {
                    throw new BusinessException("Something went wrong");
                }
            }
            else
            {
                throw new BusinessException("The category does not exist");
            }
        }

        /// <summary>
        /// Method to get categories
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Category> GetCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll()
                                .AsQueryable().Where(c => !c.IsDeleted).ToList();
            return categories;
        }

        /// <summary>
        /// Method to update a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateCategory(Category category)
        {
            var existCategory = await _unitOfWork.CategoryRepository.GetByID(category.Id);
            if(existCategory != null)
            {
                existCategory.Name = category.Name;
                existCategory.LastUpdatedOn = DateTime.Now;
                try
                {
                    _unitOfWork.CategoryRepository.Update(existCategory);
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
                catch (System.Exception)
                {
                    throw new BusinessException("Something went wrong");
                }
            }
            else
            {
                throw new BusinessException("The category does not exist");
            }
        }
    }
}
