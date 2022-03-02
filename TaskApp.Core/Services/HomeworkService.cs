using TaskApp.Core.Entities;
using TaskApp.Core.Exceptions;
using TaskApp.Core.Interfaces.Repositories;
using TaskApp.Core.Interfaces.Services;

namespace TaskApp.Core.Services
{
    /// <summary>
    /// Homework service
    /// </summary>
    public class HomeworkService : IHomeworkService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public HomeworkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Method to create a homework
        /// </summary>
        /// <param name="homework"></param>
        /// <returns></returns>
        public async Task CreateHomework(Homework homework)
        {
            try
            {
                if (homework.Status != 0) homework.Status = 0;
                homework.CreatedOn = DateTime.Now;

                await _unitOfWork.HomeworkRepository.AddAsync(homework);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                throw new BusinessException("Something went wrong.");
            }
        }

        /// <summary>
        /// Method to get all homeworks by user ID
        /// </summary>
        /// <returns></returns>
        public async Task<List<Homework>> GetHomeworksByUser(int userId)
        {
            var homeworks = await _unitOfWork.HomeworkRepository.GetHomeworksByUser(userId);
            return homeworks;
        }

        /// <summary>
        /// Method to update a homework
        /// </summary>
        /// <param name="homework"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task<bool> UpdateHomework(Homework homework)
        {
            var existsHomework = await _unitOfWork.HomeworkRepository.GetByID(homework.Id);
            if(existsHomework != null)
            {
                existsHomework.Title = homework.Title;
                existsHomework.Content = homework.Content;
                existsHomework.Status = homework.Status;
                existsHomework.LastUpdatedOn = DateTime.Now;

                try
                {
                    _unitOfWork.HomeworkRepository.Update(existsHomework);
                    await _unitOfWork.SaveChangesAsync();

                    return true;
                }
                catch(System.Exception)
                {
                    throw new BusinessException("Something went wrong");
                }
            }
            else
            {
                throw new BusinessException("The homework does not exist");
            }
        }

        /// <summary>
        /// Method to delete a homework (soft deleteion)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task<bool> DeleteHomeworkById(int id)
        {
            Homework homework = await _unitOfWork.HomeworkRepository.GetByID(id);
            if(homework != null)
            {
                try
                {
                    var result = await _unitOfWork.HomeworkRepository.DeleteHomeworkById(homework.Id);
                    await _unitOfWork.SaveChangesAsync();
                    if(result)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }

                }
                catch(System.Exception)
                {
                    throw new BusinessException("Something went wrong");
                }
            } else
            {
                throw new BusinessException("The homework does not exist");
            }
        }

        /// <summary>
        /// Method to assign categories to a homework
        /// </summary>
        /// <param name="categoriesHomework"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task AssignCategoriesToHomework(List<CategoryHomework> categoriesHomework)
        {
            var categoriesHomeworkAll = _unitOfWork.CategoryHomeworkRepository.GetAll();
            try
            {
                foreach (var categoryHomework in categoriesHomework)
                {
                    var categoryExist = categoriesHomeworkAll.Any(ch => ch.CategoryId == categoryHomework.CategoryId && ch.HomeworkId == categoryHomework.HomeworkId);
                    if(!categoryExist)
                    {
                        await _unitOfWork.CategoryHomeworkRepository.AddAsync(categoryHomework);
                    }
                }

                await _unitOfWork.SaveChangesAsync();
            }
            catch(System.Exception)
            {
                throw new BusinessException("Something went wrong");
            }
        }
    }
}
