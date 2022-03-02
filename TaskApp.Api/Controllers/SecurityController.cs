using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Api.Helpers.AuthHelper;
using TaskApp.Core.DTOs;
using TaskApp.Core.Entities;
using TaskApp.Core.Inputs;
using TaskApp.Core.Interfaces.Services;
using TaskApp.Infrastructure.Interfaces;

namespace TaskApp.Api.Controllers
{
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IPasswordService _passwordService;
        private readonly IAuthHelper _authHelper;
        private readonly IMapper _mapper;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="securityService"></param>
        /// <param name="mapper"></param>
        /// <param name="passwordservice"></param>
        /// <param name="authHelper"></param>
        public SecurityController(
            ISecurityService securityService, 
            IMapper mapper, IPasswordService passwordservice, 
            IAuthHelper authHelper)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordservice;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Register user endpoint
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/register")]
        public async Task<ActionResult> Register([FromBody] SecurityDto input)
        {
            var user = _mapper.Map<User>(input);

            user.Password = _passwordService.Hash(user.Password);

            await _securityService.RegisterUser(user);

            return Ok();
        }

        /// <summary>
        /// Login user endpoint
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/login")]
        public async Task<ActionResult> LogIn([FromBody] LoginInput input)
        {
            var validateCredentials = await _authHelper.IsValidUser(input);
            if (validateCredentials.Item1)
            {
                string token = _authHelper.GenerateToken(validateCredentials.Item2);
                return Ok(new { token });
            }
            else
            {
                return NotFound();
            }
        }

    }
}
