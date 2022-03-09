using TaskApp.Core.Entities;
using TaskApp.Core.Inputs;

namespace TaskApp.Core.Interfaces.Services
{
    /// <summary>
    /// Interface for user service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Method to change user profile info
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Input"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public Task ChangeUserProfile(User user, UpdateUserProfileInput Input);
    }
}
