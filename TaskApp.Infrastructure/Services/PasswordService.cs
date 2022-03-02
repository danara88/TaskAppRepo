using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using TaskApp.Core.Exceptions;
using TaskApp.Infrastructure.Interfaces;
using TaskApp.Infrastructure.Options;

namespace TaskApp.Infrastructure.Services
{
    /// <summary>
    /// Password service
    /// </summary>
    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions _options;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="options"></param>
        public PasswordService(IOptions<PasswordOptions> options)
        {
            _options = options.Value;
        }

        /// <summary>
        /// Method to get hash password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, _options.SaltSize, _options.Iterations))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{ _options.Iterations }.{salt}.{key}";
            };
        }

        /// <summary>
        /// Method to check the hashed password
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        public bool Check(string hash, string password)
        {
            var parts = hash.Split('.');
            if (parts.Length != 3) throw new BusinessException("Unexpected hash format");

            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] keyToCheck = algorithm.GetBytes(_options.KeySize);

                return keyToCheck.SequenceEqual(key);
            };
        }


    }
}
