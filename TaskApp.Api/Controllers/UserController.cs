using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Core.Entities;
using TaskApp.Core.Inputs;
using TaskApp.Core.Interfaces.Services;

namespace TaskApp.Api.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="userService"></param>
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>
        /// Update user profile endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/user/update_user_profile/{id}")]
        public async Task<ActionResult> UpdateUserProfile(int id, [FromForm] UpdateUserProfileInput input)
        {
            var user = _mapper.Map<User>(input);
            user.Id = id;
            await _userService.ChangeUserProfile(user, input);
            return Ok();
        }
    }
}
