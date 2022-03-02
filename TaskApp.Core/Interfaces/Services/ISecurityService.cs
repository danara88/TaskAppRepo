using TaskApp.Core.Entities;
using TaskApp.Core.Inputs;

namespace TaskApp.Core.Interfaces.Services
{
    /// <summary>
    /// Interface for security service
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// Method to register a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task RegisterUser(User user);

        /// <summary>
        /// Method to get the user by username or email
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<User> GetLoginByCredentials(LoginInput input);
    }
}
