namespace TaskApp.Infrastructure.Interfaces
{
    /// <summary>
    /// Password service interface
    /// </summary>
    public interface IPasswordService
    {
        /// <summary>
        /// Method to get hash password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string Hash(string password);

        /// <summary>
        /// Method to check the hashed password
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="BusinessException"></exception>
        bool Check(string hash, string password);
    }
}
