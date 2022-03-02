using TaskApp.Core.Entities;
using TaskApp.Core.Inputs;

namespace TaskApp.Api.Helpers.AuthHelper
{
    /// <summary>
    /// Auth helper interface
    /// </summary>
    public interface IAuthHelper
    {
        /// <summary>
        /// Validates if the inserted password is correct
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<(bool, User)> IsValidUser(LoginInput input);

        /// <summary>
        /// Method to generate the JWT token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string GenerateToken(User user);
    }
}
