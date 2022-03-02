using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskApp.Core.Entities;
using TaskApp.Core.Inputs;
using TaskApp.Core.Interfaces.Services;
using TaskApp.Infrastructure.Interfaces;

namespace TaskApp.Api.Helpers.AuthHelper
{
    /// <summary>
    /// Class Auth helper
    /// </summary>
    public class AuthHelper : IAuthHelper
    {
        private readonly IPasswordService _passwordService;
        private readonly ISecurityService _securityService;
        private readonly IConfiguration _configuration;

        public AuthHelper(IPasswordService passwordService, ISecurityService securityService, IConfiguration configuration)
        {
            _passwordService = passwordService;
            _securityService = securityService;
            _configuration = configuration;
        }

        /// <summary>
        /// Validates if the inserted password is correct
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<(bool, User)> IsValidUser(LoginInput input)
        {
            User user = await _securityService.GetLoginByCredentials(input);

            if (user == null) return (false, null);

            bool isValidPassword = _passwordService.Check(user.Password, input.Password);

            return (isValidPassword, user);
        }

        /// <summary>
        /// Method to generate the JWT token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GenerateToken(User user)
        {
            // Header configuration
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding
                                            .UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            // Claims configuration
            var claims = new[]
            {
                new Claim("Sub", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Username", user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            // Payload configuration
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now, // Do not use this token before this date
                DateTime.UtcNow.AddMinutes(10) // Token expiration
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
