using TaskApp.Core.Entities;

namespace TaskApp.Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface for unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        IHomeworkRepository HomeworkRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IRepository<CategoryHomework> CategoryHomeworkRepository { get; }

        ISecurityRepository SecurityRepository { get; }

        void Dispose();

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
