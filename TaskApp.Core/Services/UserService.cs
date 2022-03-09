using TaskApp.Core.Entities;
using TaskApp.Core.Exceptions;
using TaskApp.Core.Inputs;
using TaskApp.Core.Interfaces.Repositories;
using TaskApp.Core.Interfaces.Services;

namespace TaskApp.Core.Services
{
    /// <summary>
    /// Class for user service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IBlobService _blobService;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="blobService"></param>
        public UserService(IUnitOfWork unitOfWork, IBlobService blobService)
        {
            _unitOfWork = unitOfWork;
            _blobService = blobService;
        }

        /// <summary>
        /// Method to change user profile info
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Input"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public async Task ChangeUserProfile(User user, UpdateUserProfileInput Input)
        {
            // Verify the user exists
            var userDB = await _unitOfWork.UserRepository.GetByID(user.Id);
            if (userDB == null) throw new BusinessException("The user does not exist");

            userDB.Name = user.Name;
            userDB.Surname = user.Surname;

            try
            {
                if (Input.Img != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await Input.Img.CopyToAsync(memoryStream);
                        var content = memoryStream.ToArray();
                        var extension = Path.GetExtension(Input.Img.FileName);
                        userDB.Img = await _blobService.UpdateFileAsync(content, extension, "users", userDB.Img, Input.Img.ContentType);
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
