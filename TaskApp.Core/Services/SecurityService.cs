using TaskApp.Core.Entities;
using TaskApp.Core.Enumerations;
using TaskApp.Core.Exceptions;
using TaskApp.Core.Inputs;
using TaskApp.Core.Interfaces.Repositories;
using TaskApp.Core.Interfaces.Services;

namespace TaskApp.Core.Services
{
    /// <summary>
    /// Security service
    /// </summary>
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Method to register a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task RegisterUser(User user)
        {
            user.Role = RoleTypeEnum.Customer;
            user.CreatedOn = DateTime.Now;

            user.UserName = user.UserName.ToLower();
            user.Email = user.Email.ToLower();

            bool existUserEmail = _unitOfWork.SecurityRepository.GetAll().AsQueryable()
                                        .Any(u => u.Email.ToLower() == user.Email);
            bool existUserName = _unitOfWork.SecurityRepository.GetAll().AsQueryable()
                                        .Any(u => u.UserName.ToLower() == user.UserName);

            if (existUserEmail) throw new BusinessException("The email is already registered");
            if (existUserName) throw new BusinessException("The username is already on use");

            try
            {
                await _unitOfWork.SecurityRepository.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();    
            }
            catch(System.Exception)
            {
                throw new BusinessException("Something went wrong");
            }

        }

        /// <summary>
        /// Method to get the user by username or email
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<User> GetLoginByCredentials(LoginInput input)
        {
            return await _unitOfWork.SecurityRepository.GetLoginByCredentials(input);
        }
    }
}
