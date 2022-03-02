using TaskApp.Core.Entities;
using TaskApp.Core.Inputs;

namespace TaskApp.Core.Interfaces.Repositories
{
    /// <summary>
    /// Security repository interface
    /// </summary>
    public interface ISecurityRepository : IRepository<User>
    {
        /// <summary>
        /// Method to get a user by username or email address
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<User> GetLoginByCredentials(LoginInput input);
    }
}
