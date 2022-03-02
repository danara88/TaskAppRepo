using Microsoft.EntityFrameworkCore;
using TaskApp.Core.Entities;
using TaskApp.Core.Inputs;
using TaskApp.Core.Interfaces.Repositories;
using TaskApp.Infrastructure.Data;

namespace TaskApp.Infrastructure.Repositories
{
    /// <summary>
    /// Security repository
    /// </summary>
    public class SecurityRepository : BaseRepository<User>, ISecurityRepository
    {
        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="context"></param>
        public SecurityRepository(TaskAppContext context) : base(context) { }

        /// <summary>
        /// Method to get a user by username or email address
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<User> GetLoginByCredentials(LoginInput input)
        {
            return await _entities.FirstOrDefaultAsync(x => x.UserName == input.UserNameOrEmail.ToLower() || x.Email == input.UserNameOrEmail.ToLower());
        }
    }
}
