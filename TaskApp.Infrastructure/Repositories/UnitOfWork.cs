using TaskApp.Core.Entities;
using TaskApp.Core.Interfaces.Repositories;
using TaskApp.Infrastructure.Data;

namespace TaskApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskAppContext _context;
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRepository<CategoryHomework> _categoryHomeworkRepository;
        private readonly IRepository<User> _userRepository;
        private readonly ISecurityRepository _securityRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(TaskAppContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to get repository
        /// </summary>
        public IHomeworkRepository HomeworkRepository => _homeworkRepository ?? new HomeworkRepository(_context);

        /// <summary>
        /// Method to get repository
        /// </summary>
        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);

        /// <summary>
        /// Method to get repository
        /// </summary>
        public IRepository<CategoryHomework> CategoryHomeworkRepository => _categoryHomeworkRepository ?? new BaseRepository<CategoryHomework>(_context);

        /// <summary>
        /// Method to get repository
        /// </summary>
        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);

        /// <summary>
        /// Method to get repository
        /// </summary>
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        /// <summary>
        /// Method to dispose
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        /// <summary>
        /// Method to save changes
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Method to save changes async
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
